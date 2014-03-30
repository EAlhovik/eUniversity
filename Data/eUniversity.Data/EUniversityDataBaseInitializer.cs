using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data
{
    public class EUniversityDataBaseInitializer : DropCreateDatabaseIfModelChanges<EUniversityDbContext>
    {
        protected override void Seed(EUniversityDbContext context)
        {
            var studentRole = new Role { RoleName = RoleEnum.Student.ToString(), RoleType = RoleEnum.Student };
            var professorRole = new Role { RoleName = RoleEnum.Professor.ToString(), RoleType = RoleEnum.Professor };
            var student = new User
            {
                Email = "user1@user1.com",
                Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",
                Roles = new List<Role>() { studentRole },
                Created = DateTime.Now,
                CreatedBy = "System"
            };
            var professor = new User
            {
                Email = "professor1@professor1.com",
                Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",
                Roles = new List<Role>() { professorRole },
                Created = DateTime.Now,
                CreatedBy = "System"
            };
            context.Roles.Add(studentRole);

            context.Roles.Add(professorRole);
            context.Roles.Add(new Role { RoleName = RoleEnum.Admin.ToString(), RoleType = RoleEnum.Admin });

            context.Users.Add(student);
            context.Users.Add(professor);
            context.SaveChanges();

            var user = context.Users.First();
            user.Profile = new StudentProfile() { FirstName = "sda", GroupName = "dasdsa" };
            context.SaveChanges();

            var speciality = new Speciality()
            {
                Specializations = new List<Specialization>()
                {
                    new Specialization()
                    {
                        Сurricula = new List<Curriculum>()
                        {
                            new Curriculum()
                            {
                                DateOfEnactment = DateTime.Today,
                                Semesters = new List<Semester>()
                                {
                                    new Semester(){Sequential = 1},
                                    new Semester(){Sequential = 2},
                                    new Semester(){Sequential = 3},
                                    new Semester(){Sequential = 4},
                                    new Semester(){Sequential = 5},
                                    new Semester(){Sequential = 6},
                                    new Semester(){Sequential = 7},
                                    new Semester(){Sequential = 8},
                                }
                            }
                        },
                        Created =  DateTime.Now,
                        Name = "the first specialization"
                    },
                },
                Created = DateTime.Now,
                Name = "First speciality"
            };
            context.Specialities.Add(speciality);
            context.SaveChanges();

            var t = context.Curricula.ToList();
        }
    }
}