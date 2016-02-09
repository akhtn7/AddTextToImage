using System.Data.Entity;
using AddTextToImage.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AddTextToImage.Data.Context
{
    class Db : DbContext
    {
        public Db() : base("EFDbContext") 
        {
            //Database.SetInitializer<EFDbContext>(null);
        }


        public DbSet<FontInfo> Fonts { get; set; }

        public DbSet<ModelItem> ModelItems { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<SampleItem> SampleItems { get; set; }

        public DbSet<Sample> Samples { get; set; }

        public DbSet<TextTemplate> TextTemplates { get; set; }

        public DbSet<TextGallery> TextGalleries { get; set; }

        public DbSet<ClipartTemplate> ClipartTemplates { get; set; }

        public DbSet<ClipartGallery> ClipartGalleries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}
