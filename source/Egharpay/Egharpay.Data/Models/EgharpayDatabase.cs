


namespace Egharpay.Data.Models
{
    using System.Data.Entity;
    using Entity;

    public partial class EgharpayDatabase : OrganisationDbContext
    {
        public EgharpayDatabase() : base("name=EgharpayDatabase")
        {
        }

        public virtual DbSet<PersonnelGrid> PersonnelGrids { get; set; }
        public virtual DbSet<AspNetUsersAlertSchedule> AspNetUsersAlertSchedules { get; set; }
        public virtual DbSet<Host> Hosts { get; set; }
        public virtual DbSet<Organisation> Organisations { get; set; }
        public virtual DbSet<Personnel> Personnels { get; set; }
        public virtual DbSet<UserAuthorisationFilter> UserAuthorisationFilters { get; set; }
        public virtual DbSet<Centre> Centres { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentType> DocumentTypes { get; set; }
        public virtual DbSet<Template> Templates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Hosts)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Organisation>()
                .HasMany(e => e.Personnels)
                .WithRequired(e => e.Organisation)
                .WillCascadeOnDelete(false);



            modelBuilder.Entity<Personnel>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.NINumber)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.BankAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.BankSortCode)
                .IsUnicode(false);

            modelBuilder.Entity<Personnel>()
                .Property(e => e.BankTelephone)
                .IsUnicode(false);

            modelBuilder.Entity<Centre>()
                  .Property(e => e.CentreCode)
                  .IsUnicode(false);

            modelBuilder.Entity<Centre>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Document>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .Property(e => e.BasePath)
                .IsUnicode(false);

            modelBuilder.Entity<DocumentType>()
                .HasMany(e => e.Documents)
                .WithRequired(e => e.DocumentType)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<Centre>()
                .Property(e => e.CentreCode)
                .IsUnicode(false);

            modelBuilder.Entity<Centre>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PersonnelGrid>()
               .Property(e => e.Telephone)
               .IsUnicode(false);

            modelBuilder.Entity<PersonnelGrid>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<PersonnelGrid>()
                .Property(e => e.NINumber)
                .IsUnicode(false);

            modelBuilder.Entity<PersonnelGrid>()
                .Property(e => e.BankAccountNumber)
                .IsUnicode(false);

            modelBuilder.Entity<PersonnelGrid>()
                .Property(e => e.BankSortCode)
                .IsUnicode(false);

            modelBuilder.Entity<PersonnelGrid>()
                .Property(e => e.BankTelephone)
                .IsUnicode(false);

            modelBuilder.Entity<PersonnelGrid>()
                .Property(e => e.Email)
                .IsUnicode(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
