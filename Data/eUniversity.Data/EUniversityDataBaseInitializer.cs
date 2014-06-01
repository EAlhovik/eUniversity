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

            var professor = new User
            {
                Email = "professor1@professor1.com",
                Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",
                Roles = new List<Role>() { professorRole },
                Created = DateTime.Now,
                CreatedBy = "System"
            };

            context.Roles.Add(professorRole);
            context.Roles.Add(new Role { RoleName = RoleEnum.Admin.ToString(), RoleType = RoleEnum.Admin });

            context.Users.Add(professor);
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
                                DateOfEnactment = new DateTime(2009,08,15),
                                Created = DateTime.Now,
                                CreatedBy = "System",
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
                        Name = "1-40 01 01 05",
                        Description = "Моделирование и компьютерное проектирование программно-аппаратных комплексов",
                        Groups = new List<Group>()
                        {
                            new Group()
                            {
                                Created = DateTime.Now,
                                CreatedBy = "System",
                                Name = "107229",
                                DateOfAdmission = new DateTime(2009,08,15),
                                Students = new List<StudentProfile>()
                                {
                                    new StudentProfile()
                                    {
                                        FirstName = "Женя",
                                        LastName = "Альховик",
                                        DateOfAdmission = new DateTime(2009,08,15),
                                        User = new User()
                                        {
                                            Email = "tartar@tartar.com",
                                            Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",
                                            Roles = new List<Role>() { studentRole },
                                            Created = DateTime.Now,
                                            CreatedBy = "System"
                                        }
                                    }
                                }
                            }
                        }
                    },
                },
                Created = DateTime.Now,
                Name = "1-40 01 01",
                Description = "Программное обеспечение информационных технологий"
            };
            context.Specialities.Add(speciality);
            context.SaveChanges();
            var group = context.Groups.First();
            group.Students = new List<StudentProfile>()
            {
                context.StudentProfiles.First()
            };

            context.SaveChanges();
            var t = context.Curricula.ToList();
        }
    }
}