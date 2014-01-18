using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eUniversity.Business.Domain.Entities.eUniversity;
using eUniversity.Business.Helpers.Enums;

namespace eUniversity.Data
{
    public class EUniversityDataBaseInitializer : DropCreateDatabaseIfModelChanges<EUniversityDbContext>
    {
        protected override void Seed(EUniversityDbContext context)
        {
            var studentRole = new Role { RoleName = RoleEnum.Student.ToString(), RoleType = RoleEnum.Student };
            var student = new User
            {
                UserName = "user1",
                Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",
                Roles = new List<Role>() { studentRole },
            };
            context.Roles.Add(studentRole);
            context.Roles.Add(new Role { RoleName = RoleEnum.Professor.ToString(), RoleType = RoleEnum.Professor });
            context.Roles.Add(new Role { RoleName = RoleEnum.Admin.ToString(), RoleType = RoleEnum.Admin });

            context.Users.Add(student);
            context.SaveChanges();

            var user = context.Users.First();
            user.Profile = new StudentProfile() { FirstName = "sda", GroupName = "dasdsa" };
            context.SaveChanges();
        }
    }
}