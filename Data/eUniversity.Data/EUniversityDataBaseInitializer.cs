using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using eUniversity.Business.Domain.Entities.Base;
using eUniversity.Business.Domain.Entities.Enums;
using eUniversity.Business.Domain.Entities.eUniversity;

namespace eUniversity.Data
{
    public class EUniversityDataBaseInitializer : DropCreateDatabaseIfModelChanges<EUniversityDbContext>
    {
        protected override void Seed(EUniversityDbContext context)
        {
            const string createdBy = "System";
            var studentRole = new Role { RoleName = RoleEnum.Student.ToString(), RoleType = RoleEnum.Student };
            var professorRole = new Role { RoleName = RoleEnum.Professor.ToString(), RoleType = RoleEnum.Professor };

            var professor = new User
            {
                Email = "professor1@professor1.com",
                Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",
                Roles = new List<Role>() { professorRole },
                Created = DateTime.Now,
                CreatedBy = createdBy
            };

            context.Roles.Add(professorRole);
            context.Roles.Add(new Role { RoleName = RoleEnum.Admin.ToString(), RoleType = RoleEnum.Admin });

            context.Users.Add(professor);
            context.SaveChanges();



            var subject = new Subject()
            {
                Id = 1,
                Name = "Diplom",
                SubjectType = SubjectTypeEnum.Diplom
            };

            var themes = new List<Theme>
            {
                new Theme(){ Name = "Web-приложение системы банковской оплаты PayPal", Description = "Web-приложение системы банковской оплаты PayPal",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Программный модуль для тестирования знаний в системе управления учеб-ным процессом", Description = "Программный модуль для тестирования знаний в системе управления учеб-ным процессом",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Система мониторинга узлов корпоративной сети", Description = "Система мониторинга узлов корпоративной сети",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Приложение “Арендная история клиентов агентств недвижимости города Минска”", Description = "Приложение “Арендная история клиентов агентств недвижимости города Минска”",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Мобильное приложение по поиску людей для совместного путешествия или отдыха", Description = "Мобильное приложение по поиску людей для совместного путешествия или отдыха",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Web-приложение для фотостудии", Description = "Web-приложение для фотостудии",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Клиентская часть портала-каталога “Justy.by”", Description = "Клиентская часть портала-каталога “Justy.by”",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Программное обеспечение учебно-методического комплекса", Description = "Программное обеспечение учебно-методического комплекса по дисциплине “Компьютерные сети”",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Применение нейронных сетей", Description = "Применение нейронных сетей для прогнозирования курса акций на фондо-вом рынке",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Оптимизация технологий программирования эволюционным методом", Description = "Оптимизация технологий программирования эволюционным методом",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
                new Theme(){ Name = "Программный модуль управления ошибками при разработке проектов", Description = "Программный модуль управления ошибками при разработке проектов",Subjects = new List<Subject>(){subject},Created = DateTime.Now, CreatedBy = createdBy},
            };

            var students219 = new List<StudentProfile>
            {
                new StudentProfile
                {
                    FirstName = "Николай", LastName = "Арефьев",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[0]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now,CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Ольга", LastName = "Барковская",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[1]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now,CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Алексей", LastName = "Безручко",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[2]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now,CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Артур", LastName = "Бойко",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[3]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now, CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Алексей", LastName = "Боровец",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[4]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now, CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Левон", LastName = "Бутунцев",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[5]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now, CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Дмитрий", LastName = "Вовна",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[6]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now, CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Евгений", LastName = "Гаврилов",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[7]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now, CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Алексей", LastName = "Доморенок",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[8]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now, CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Арсений", LastName = "Ждановский",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[9]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now, CreatedBy = createdBy}
                },
                new StudentProfile
                {
                    FirstName = "Елена", LastName = "Завистовская",
                    Themes = new List<StudentTheme> {new StudentTheme{SubjectId = subject.Id,Theme = themes[10]}  }, DateOfAdmission = new DateTime(2009,08,15),
                    User = new User{Email = "tartar@tartar.com",Password = "E3C70ADF5F1C30DB24407E6A85ECF9120F45660E",Roles = new List<Role>() { studentRole },Created = DateTime.Now, CreatedBy = createdBy}
                },
            };
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
                                CreatedBy = createdBy,
                                Semesters = new List<Semester>()
                                {
                                    new Semester{Sequential = 1},
                                    new Semester{Sequential = 2},
                                    new Semester{Sequential = 3},
                                    new Semester{Sequential = 4},
                                    new Semester{Sequential = 5},
                                    new Semester{Sequential = 6},
                                    new Semester{Sequential = 7},
                                    new Semester
                                    {
                                        Sequential = 8,
                                        Subjects = new List<Subject>()
                                        {
                                            subject
                                        }
                                    },
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
                                CreatedBy = createdBy,
                                Name = "107219",
                                DateOfAdmission = new DateTime(2009,08,15),
                                Students = students219
                            },
                            new Group()
                            {
                                Created = DateTime.Now,
                                CreatedBy = createdBy,
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
                                            CreatedBy = createdBy
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

            /*            var group = context.Groups.First();
                        group.Students = new List<StudentProfile>()
                        {
                            context.StudentProfiles.First()
                        };

                        context.SaveChanges();*/
            var t = context.Curricula.ToList();
        }
    }
}