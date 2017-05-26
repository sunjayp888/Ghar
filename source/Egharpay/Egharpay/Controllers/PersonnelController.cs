﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Egharpay.Attributes;
using Egharpay.Business.Interfaces;
using Egharpay.Entity;
using Egharpay.Entity.Dto;
using Egharpay.Extensions;
using Egharpay.Models;
using Egharpay.Models.Authorization;

namespace Egharpay.Controllers
{
    [Authorize]
    public class PersonnelController : BaseController
    {
        private ApplicationRoleManager _roleManager;
        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        public PersonnelController(IEgharpayBusinessService hrBusinessService) : base(hrBusinessService)
        {
        }

        // GET: Personnel
        [AuthorizePersonnel(Roles = "Admin,User")]
        public ActionResult Index()
        {
            return View(new BaseViewModel());
        }

        // GET: Personnel/Profile/{id}
        [AuthorizePersonnel(Roles = "Admin,User")]
        public new ActionResult Profile(int id)
        {
            var organisationId = UserOrganisationId;
            var personnelId = UserPersonnelId;
            var personnel = EgharpayBusinessService.RetrievePersonnel(UserOrganisationId, id);
            if (personnel == null)
            {
                return HttpNotFound();
            }

            var isAdmin = User.IsInAnyRoles("Admin");
            List<int> selectedCompanyIds = null;
            List<int> selectedDepartmentIds = null;
            List<int> selectedDivisionIds = null;
            if (!isAdmin)
            {
            }
            var viewModel = new PersonnelProfileViewModel
            {
                Personnel = personnel,
                Permissions = EgharpayBusinessService.RetrievePersonnelPermissions(isAdmin, UserOrganisationId, UserPersonnelId, id),
                //PhotoBytes = EgharpayBusinessService.RetrievePhoto(organisationId, id)
            };
            return View(viewModel);
        }


        // GET: Personnel/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var centres = EgharpayBusinessService.RetrieveCentres(UserOrganisationId, e => true);
            var viewModel = new PersonnelProfileViewModel
            {
                
                Centres = new SelectList(centres, "CentreId", "Name"),
                Personnel = new Personnel
                {
                    OrganisationId = UserOrganisationId,
                    DOB = DateTime.Today,
                    Title = "Mr",
                    Forenames = "A",
                    Surname = "B",
                    Email = string.Format("{0}@hr.com", Guid.NewGuid()),
                    Address1 = "Address1",
                    Postcode = "POST CODE",
                    Telephone = "12345678",
                    NINumber = "NZ1234567",
                },
            };
            return View(viewModel);
        }

        // POST: Personnel/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonnelProfileViewModel personnelViewModel)
        {
            // check if user with this email already exists for the current organisation
            var centres = EgharpayBusinessService.RetrieveCentres(UserOrganisationId, e => true);
            var userExists = UserManager.FindByEmail(personnelViewModel.Personnel.Email);
            personnelViewModel.Centres = new SelectList(centres, "CentreId", "Name");
            if (userExists != null)
                ModelState.AddModelError("", string.Format("An account already exists for the email address {0}", personnelViewModel.Personnel.Email));

            if (ModelState.IsValid)
            {
                //Create Personnel
                personnelViewModel.Personnel.CentreId = personnelViewModel.Personnel.CentreId == 0? UserCentreId:personnelViewModel.Personnel.CentreId;
                personnelViewModel.Personnel = EgharpayBusinessService.CreatePersonnel(UserOrganisationId, personnelViewModel.Personnel);
                //var trainer =  EgharpayBusinessService.CreateTrainer
                //create personnel
                //var personnel = new Personnel(){set all mandatory field like forename }
                //CreateTrainerUserAndRole(personnel)

                var result = CreateUserAndRole(personnelViewModel.Personnel);
                if (result.Succeeded)
                    return RedirectToAction("Index");

                //delete the orphaned personnel & employment records
                EgharpayBusinessService.DeletePersonnel(UserOrganisationId, personnelViewModel.Personnel.PersonnelId);
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            return View(personnelViewModel);
        }

        private IdentityResult CreateUserAndRole(Personnel personnel)
        {
            var createUser = new ApplicationUser
            {
                UserName = personnel.Email,
                Email = personnel.Email,
                OrganisationId = UserOrganisationId,
                PersonnelId = personnel.PersonnelId,
                CentreId = personnel.CentreId
            };

            var roleId = RoleManager.Roles.FirstOrDefault(r => r.Name == "User").Id;
            createUser.Roles.Add(new IdentityUserRole { UserId = createUser.Id, RoleId = roleId });

            var result = UserManager.Create(createUser, "Password1!");
            return result;
        }

        //private IdentityResult CreateTrainerUserAndRole(Personnel personnel)
        //{
        //    var createUser = new ApplicationUser
        //    {
        //        UserName = personnel.Email,
        //        Email = personnel.Email,
        //        OrganisationId = UserOrganisationId,
        //        PersonnelId = personnel.PersonnelId,
        //        CentreId = personnel.CentreId
        //    };

        //    var roleId = RoleManager.Roles.FirstOrDefault(r => r.Name == "Admin").Id;
        //    createUser.Roles.Add(new IdentityUserRole { UserId = createUser.Id, RoleId = roleId });

        //    var result = UserManager.Create(createUser, "Password1!");
        //    return result;
        //}

        // GET: Personnel/Edit/{id}
        [AuthorizePersonnel(Roles = "Admin,User")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var personnel = EgharpayBusinessService.RetrievePersonnel(UserOrganisationId, id.Value);
            if (personnel == null)
            {
                return HttpNotFound();
            }
            var centres = EgharpayBusinessService.RetrieveCentres(UserOrganisationId, e => true);
           
            personnel.Email = UserManager.FindByPersonnelId(personnel.PersonnelId)?.Email;
            var viewModel = new PersonnelProfileViewModel
            {
                Centres = new SelectList(centres, "CentreId", "Name"),
                Personnel = personnel
            };
            return View(viewModel);
        }

        // POST: Personnels/Edit/{id}
        [AuthorizePersonnel(Roles = "Admin,User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonnelProfileViewModel personnelViewModel)
        {
            if (ModelState.IsValid)
            {

                personnelViewModel.Personnel = EgharpayBusinessService.UpdatePersonnel(UserOrganisationId, personnelViewModel.Personnel);

                var editUser = UserManager.FindByPersonnelId(personnelViewModel.Personnel.PersonnelId);
                editUser.Email = personnelViewModel.Personnel.Email;

                var result = UserManager.Update(editUser);
                if (result.Succeeded)
                    return RedirectToAction("Index");

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }
            var viewModel = new PersonnelProfileViewModel
            {
                Personnel = personnelViewModel.Personnel
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult UploadPhoto(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {

                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(file.ContentLength);
                        }
                        //EgharpayBusinessService.UploadPhoto(UserOrganisationId, id.Value,  fileData);
                    }
                }
                return this.JsonNet("");
            }
            catch (Exception ex)
            {
                return this.JsonNet(ex);
            }

        }

        [HttpPost]
        public ActionResult DeletePhoto(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                //EgharpayBusinessService.DeletePhoto(UserOrganisationId, id.Value);
                return this.JsonNet("");
            }
            catch (Exception ex)
            {
                return this.JsonNet(ex);
            }

        }

        [HttpPost]
        public ActionResult List(Paging paging, List<OrderBy> orderBy)
        {
            return this.JsonNet(EgharpayBusinessService.RetrievePersonnel(UserOrganisationId, UserCentreId, orderBy, paging));
        }

        [HttpPost]
        public ActionResult Search(string searchKeyword, Paging paging, List<OrderBy> orderBy)
        {
            return this.JsonNet(EgharpayBusinessService.RetrievePersonnelBySearchKeyword(UserOrganisationId, searchKeyword, orderBy, paging));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_roleManager != null)
                {
                    _roleManager.Dispose();
                    _roleManager = null;
                }
            }

            base.Dispose(disposing);
        }
    }
}