using System.Collections.Generic;
using System.IO;
using StudentSystem.Models;

namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.ContextKey = "StudentSystem";

        }

        protected override void Seed(StudentSystem.Data.StudentSystemContext context)
        {
            //Very long. Please don't be mean. I don't have time to refactor it. It's working :)
            if (!context.Students.Any())
            {
                using (var reader = new StreamReader("../../../../Students.txt"))
                {
                    var line = reader.ReadLine();

                    line = reader.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(',');
                        var name = data[0];
                        var phone = data[1];
                        var regDate = DateTime.Parse(data[2]);
                        var birthDate = DateTime.Parse(data[3]);


                        context.Students.AddOrUpdate(new Student()
                        {
                            Name = name,
                            PhoneNumber = phone,
                            RegisterDate = regDate,
                            BirthDate = birthDate
                        });

                        line = reader.ReadLine();
                    }
                    context.SaveChanges();
                }
            }

            if (!context.Resources.Any())
            {

                using (var reader = new StreamReader("../../../../Resources.txt"))
                {
                    var line = reader.ReadLine();

                    line = reader.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(',');
                        var name = data[0];
                        var type = (ResourceType)int.Parse(data[1]);
                        var url = data[2];


                        context.Resources.AddOrUpdate(new Resource()
                        {
                            Name = name,
                            Type = type,
                            Url = url
                        });

                        line = reader.ReadLine();
                    }
                    context.SaveChanges();
                }
            }

            if (!context.Homeworks.Any())
            {
                using (var reader = new StreamReader("../../../../Homeworks.txt"))
                {
                    var rand = new Random();
                    var students = context.Students.ToArray();

                    var line = reader.ReadLine();

                    line = reader.ReadLine();
                    while (line != null)
                    {
                        var data = line.Split(',');

                        var content = data[0];
                        var type = (ContentType)int.Parse(data[1]);
                        var submissionDate = DateTime.Parse(data[2]);

                        context.Homeworks.AddOrUpdate(new Homework()
                        {
                            Content = content,
                            Type = type,
                            SubmissionDate = submissionDate,
                            Student = students[rand.Next(0, students.Length)]
                        });

                        line = reader.ReadLine();
                    }
                    context.SaveChanges();
                }
            }

            if (!context.Courses.Any())
            {

                var resources = context.Resources.ToArray();
                var homeworks = context.Homeworks.ToArray();
                var students = context.Students.ToArray();
                var rand = new Random();

                using (var reader = new StreamReader("../../../../Courses.txt"))
                {
                    
                    var line = reader.ReadLine();

                    line = reader.ReadLine();
                    while (line != null)
                    {

                        var data = line.Split(',');

                        var name = data[0];
                        var description = data[1];
                        var startDate = DateTime.Parse(data[2]);
                        var endDate = DateTime.Parse(data[3]);
                        var price = decimal.Parse(data[4]);

                        var countStudents = rand.Next(1, students.Length);
                        var listStudents = new List<Student>();
                        for (int i = 0; i < countStudents; i++)
                        {
                            var student = students[rand.Next(1, students.Length)];
                            if (listStudents.Any(s => s.StudentID == student.StudentID))
                            {
                                continue;
                            }
                            listStudents.Add(student);
                        }

                        var countResources = rand.Next(1, resources.Length);
                        var listResources = new List<Resource>();
                        for (int i = 0; i < countResources; i++)
                        {
                            var resource = resources[rand.Next(0, resources.Length)];
                            if (listResources.Any(r => r.ResourceID == resource.ResourceID))
                            {
                                continue;
                            }
                            listResources.Add(resource);
                        }

                        var countHomeworks = rand.Next(1, homeworks.Length);
                        var listHomeworks = new List<Homework>();
                        for (int i = 0; i < countHomeworks; i++)
                        {
                            var homework = homeworks[rand.Next(0, homeworks.Length)];
                            if (listHomeworks.Any(h => h.HomeworkID == homework.HomeworkID))
                            {
                                continue;
                            }
                            listHomeworks.Add(homework);
                        }

                        context.Courses.AddOrUpdate(new Course()
                        {
                            Name = name,
                            Description = description,
                            StartDate = startDate,
                            EndDate = endDate,
                            Price = price,
                            Homeworks = listHomeworks,
                            Resources = listResources,
                            Students = listStudents
                        });

                        line = reader.ReadLine();
                    }
                    context.SaveChanges();
                }

                var courses = context.Courses.ToArray();

               
                foreach (var student in context.Students)
                {
                    var countCourses = rand.Next(1, courses.Length);
                    var listCourses = new List<Course>();
                    for (int i = 0; i < countCourses; i++)
                    {
                        var course = courses[rand.Next(0, courses.Length)];
                        if (listCourses.Any(r => r.CourseID == course.CourseID))
                        {
                            continue;
                        }
                        listCourses.Add(course);
                    }
                    student.Courses = listCourses;
                }
                context.SaveChanges();
            }
        }
    }
}

