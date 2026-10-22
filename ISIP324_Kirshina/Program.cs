using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static ISIP324_Kirshina.Program;

namespace ISIP324_Kirshina
{
    internal class Program
    {
        public abstract class Person
        {
            private string fio;
            private int age;
            private string email;
            private string phone;
            protected Person(string fio, int age, string email, string phone)
            {
                Fio = fio;
                Age = age;
                Email = email;
                Phone = phone;
            }
            public string Fio
            {
                get => fio;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("ФИО не может быть пустым");
                    }
                    if (value.Split(' ').Length < 3){
                        throw new Exception("ФИО должно содержать фамилию, имя и отчество");
                    }
                    fio = value;
                }
            }
            public int Age
            {
                get => age;
                set
                {
                    if (value > 0 && value < 100)
                    {
                        age = value;
                    } else {
                        throw new Exception("Некорректный ввод возраста.");
                    }
                }
            }
            public string Email
            {
                get => email;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Email не может быть пустым.");
                    }
                    if (!value.Contains("@") || !value.Contains(".")) {
                        throw new Exception("Некорректный ввод email.");
                    }
                    email = value;
                }
            }
            public string Phone
            {
                get => phone;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Телефон не может быть пустым");
                    }
                    phone = value;
                }
            }
            public virtual void ShowInfo()
            {
                Console.WriteLine($"ФИО: {Fio}");
                Console.WriteLine($"Возраст: {Age}");
                Console.WriteLine($"Email: {Email}");
                Console.WriteLine($"Телефон: {Phone}");
            }
        }
        public class Teacher : Person
        {
            private static int nextTeacherID = 1;
            private int teacherID;
            private List <Course> courses = new List <Course> ();
            public List<Course> Courses
            {
                get => courses;
            }
            public Teacher(string fio, int age, string email, string phone, int teacherID)
                :base(fio, age, email, phone)
            {
                this.teacherID = nextTeacherID;
                nextTeacherID++;
            }
            public void AssignToCourse(Course course)
            {
                if (course == null)
                {
                    throw new Exception("Курс не может быть пустым.");
                }
                if (!courses.Contains(course))
                {
                    courses.Add(course);
                }
            }
            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"ID преподавателя: {teacherID}");
                Console.WriteLine($"Ведёт курсов: {courses.Count}");
                if (courses.Count > 0)
                {
                    Console.WriteLine("Курсы:");
                    foreach (var course in courses)
                    {
                        Console.WriteLine($" - {course.Name}");
                    }
                }
                else
                {
                    Console.WriteLine("У преподавателя нет курсов.");
                }
            }
        }
        public class Student : Person
        {
            private static int nextStudentID = 1;
            private int studentID;
            private List<Course> courses = new List<Course>();
            public List<Course> Courses
            {
                get => courses;
            }
            public Student(string fio, int age, string email, string phone, int studentID)
                :base(fio, age, email, phone)
            {
                this.studentID = nextStudentID;
                nextStudentID++;
            }
            public void EnrollInCourses(Course course)
            {
                if (course == null)
                {
                    throw new Exception("Курс не может быть пустым.");
                }
                if (!courses.Contains(course))
                {
                    courses.Add(course);
                }
            }
            public override void ShowInfo()
            {
                base.ShowInfo();
                Console.WriteLine($"ID студента: {studentID}");
                Console.WriteLine($"Записан на курсов: {courses.Count}");
                if (courses.Count > 0)
                {
                    Console.WriteLine("Курсы:");
                    foreach (var course in courses)
                    {
                        Console.WriteLine($" - {course.Name}");
                    }
                }
            }
        }
        public class Course
        {
            private string name;
            private string description;
            private Teacher teacher;
            private List<Student> students = new List<Student>();
            public string Name
            {
                get => name;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Название курса не может быть пустым.");
                    }
                    name = value;
                }
            }
            public string Description
            {
                get => description;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        throw new Exception("Описание курса не может быть пустым.");
                    }
                    description = value;
                }
            }
            public Teacher Teacher
            {
                get => teacher;
                set
                {
                    if (value == null)
                    {
                        throw new Exception("Преподователь не может быть пустым.");
                    }
                    teacher = value;
                }
            }
            public List<Student> Students
            {
                get => students;
                private set => students = value;
            }
        }
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            List<Teacher> teachers = new List<Teacher>();
            List<Course> courses = new List<Course>();
            ShowMenu();
            void ShowMenu()
            {
                while (true)
                {
                    Console.WriteLine("Меню:");
                    Console.WriteLine("1. Управление студентами");
                    Console.WriteLine("2. Управление преподавателями");
                    Console.WriteLine("3. Управление курсами");
                    Console.WriteLine("4. Показать все списки");
                    Console.WriteLine("0. Выход");
                    Console.Write("Выберите вариант: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            StudentMenu();
                            break;
                        //case "2":
                        //    TeacherMenu();
                        //    break;
                        //case "3":
                        //    CourseMenu();
                        //    break;
                        //case "4":
                        //    ShowLists();
                            //break;
                        case "0":
                            return;
                        //default:
                        //    Console.WriteLine("Неправильный выбор!");
                    }
                }
                void StudentMenu()
                {
                    while (true)
                    {
                        Console.WriteLine("Система управления студентами:");
                        Console.WriteLine("1. Добавить студента");
                        Console.WriteLine("2. Показать всех студентов");
                        Console.WriteLine("3. Записать студента на курс");
                        Console.WriteLine("4. Показать все курсы указанного студента");
                        Console.WriteLine("0. Выход");
                        Console.Write("Выберите вариант: ");
                        string choice = Console.ReadLine();

                        switch (choice)
                        {
                            case "1":
                                AddStudent();
                                break;
                            //case "2":
                            //    ShowStudents();
                            //    break;
                            //case "3":
                            //    StCourseAttend();
                            //    break;
                            //case "4":
                            //    ShowCoursesOfSt();
                            case "0":
                                return;
                                //default:
                                //    Console.WriteLine("Неправильный выбор!");
                        }
                        void AddStudent()
                        {
                            Console.WriteLine("Добавление студента:");
                            Console.WriteLine("Введите данные о студенте в следующем формате: ФИО; возраст; email; номер телефона");
                            Console.Write("Ваш ввод: ");

                            string input = Console.ReadLine();

                            string[] parts = input.Split(';');

                            if (parts.Length != 4)
                            {
                                Console.WriteLine("Неправильный формат ввода. Следуйте шаблону!");
                                return;
                            }

                            string fio = parts[0].Trim();
                            string ageString = parts[1].Trim();
                            string email = parts[2].Trim();
                            string phone = parts[3].Trim();

                            int age;
                            try
                            {
                                age = Convert.ToInt32(ageString);
                            } catch (Exception)
                            {
                                Console.WriteLine("Ошибка: Возраст должен быть числом!");
                                return;
                            }
                            try
                            {
                                Student student = new Student(fio, age, email, phone, 0);
                                students.Add(student);
                                Console.WriteLine($"Студент {fio} был успешно создан!");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ошибка валидации: {ex.Message}");
                            }
                        }
                    }
                }
            }
        }
    }
}
