using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Data.Configuration;

namespace eUniversity.Data
{
    /// <summary>
    /// Represents db context for eticket models
    /// </summary>
    public class EUniversityDbContext : DbContext
    {
        static EUniversityDbContext()
        {
            Database.SetInitializer(new EUniversityDataBaseInitializer());
        }

        public EUniversityDbContext(string connectionStringName)
            : base(connectionStringName)
        {
        }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        public IDbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public IDbSet<Role> Roles { get; set; }

        /// <summary>
        /// Gets or sets the specialities.
        /// </summary>
        public IDbSet<Speciality> Specialities { get; set; }

        /// <summary>
        /// Gets or sets the specializations.
        /// </summary>
        public IDbSet<Specialization> Specializations { get; set; }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        public IDbSet<StudentProfile> StudentProfiles { get; set; }

        /// <summary>
        /// Gets or sets the professor profiles.
        /// </summary>
        public IDbSet<ProfessorProfile> ProfessorProfiles { get; set; }

        /// <summary>
        /// Gets or sets the сurricula.
        /// </summary>
        public IDbSet<Curriculum> Curricula { get; set; }

        /// <summary>
        /// Gets or sets the semesters.
        /// </summary>
        public IDbSet<Semester> Semesters { get; set; }

        /// <summary>
        /// Gets or sets the subjects.
        /// </summary>
        public IDbSet<Subject> Subjects { get; set; }

        /// <summary>
        /// Gets or sets the themes.
        /// </summary>
        public IDbSet<Theme> Themes { get; set; } 


        /// <summary>
        /// Action that launches on model creating
        /// </summary>
        /// <param name="modelBuilder">Is used to map CLR classes to database scheme</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // http://stackoverflow.com/questions/7924758/entity-framework-creates-a-plural-table-name-but-the-view-expects-a-singular-ta
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Mappings
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new SpecialityConfiguration());
            modelBuilder.Configurations.Add(new SpecializationConfiguration());
            modelBuilder.Configurations.Add(new StudentProfileConfiguration());
            modelBuilder.Configurations.Add(new ProfessorProfileConfiguration());
            modelBuilder.Configurations.Add(new CurriculumConfiguration());
            modelBuilder.Configurations.Add(new SemesterConfiguration());
            modelBuilder.Configurations.Add(new SubjectConfiguration());
            modelBuilder.Configurations.Add(new ThemeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}