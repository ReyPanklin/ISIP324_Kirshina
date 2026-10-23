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
                    if (value.Split(' ').Length < 3)
                    {
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
                    }
                    else
                    {
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
                    if (!value.Contains("@") || !value.Contains("."))
                    {
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
            private List<Course> courses = new List<Course>();
            public List<Course> Courses
            {
                get => courses;
            }
            public Teacher(string fio, int age, string email, string phone, int teacherID)
                : base(fio, age, email, phone)
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
                : base(fio, age, email, phone)
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
            public Course(string name, string description, Teacher teacher)
            {
                Name = name;
                Description = description;
                Teacher = teacher;
            }
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
                        case "2":
                            TeacherMenu();
                            break;
                        case "3":
                            CourseMenu();
                            break;
                        case "4":
                            ShowAllLists();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неправильный выбор!");
                            return;
                    }
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
                        case "2":
                            ShowStudents();
                            break;
                        case "3":
                            StCourseAttend();
                            break;
                        case "4":
                            ShowCoursesOfSt();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неправильный выбор!");
                            return;
                    }
                }
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
                }
                catch (Exception)
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
            void ShowStudents()
            {
                Console.WriteLine("Все студенты:");
                if (students.Count == 0)
                {
                    Console.WriteLine("Список студентов пуст");
                    return;
                }
                foreach (var student in students)
                {
                    student.ShowInfo();
                    Console.WriteLine("____________________");
                }
            }
            void StCourseAttend()
            {
                Console.WriteLine("Запись студента на курс");
                if (students.Count == 0)
                {
                    Console.WriteLine("Список студентов пуст");
                    return;
                }
                if (courses.Count == 0)
                {
                    Console.WriteLine("Список курсов пуст");
                    return;
                }
                Console.WriteLine("Выберите студента:");
                for (int i = 0; i < students.Count; i++)
                {
                     Console.WriteLine($"{i + 1}. {students[i].Fio}");
                }
                int studentIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine("Выберите курс:");
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {courses[i].Name}");
                }
                int courseIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                students[studentIndex].EnrollInCourses(courses[courseIndex]);
                Console.WriteLine("Студент успешно записан на курс!");
            }
            void ShowCoursesOfSt()
            {
                Console.WriteLine("Курсы студента");
                if (students.Count == 0)
                {
                    Console.WriteLine("Список студентов пуст");
                    return;
                }
                Console.WriteLine("Выберите студента:");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {students[i].Fio}");
                }
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                students[index].ShowInfo();
            }
            void TeacherMenu()
            {
                while (true)
                {
                    Console.WriteLine("Система управления преподавателями:");
                    Console.WriteLine("1. Добавить преподавателя");
                    Console.WriteLine("2. Показать всех преподавателей");
                    Console.WriteLine("3. Назначить преподавателя на курс");
                    Console.WriteLine("0. Выход");
                    Console.Write("Выберите вариант: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddTeacher();
                            break;
                        case "2":
                            ShowTeachers();
                            break;
                        case "3":
                            AssignTeacherToCourse();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неправильный выбор!");
                            return;
                    }
                }
            }
            void AddTeacher()
            {
                Console.WriteLine("Добавление учителя:");
                Console.WriteLine("Введите данные об учителе в следующем формате: ФИО; возраст; email; номер телефона");
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
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка: Возраст должен быть числом!");
                    return;
                }
                try
                {
                    Teacher teacher = new Teacher(fio, age, email, phone, 0);
                    teachers.Add(teacher);
                    Console.WriteLine($"Студент {fio} был успешно создан!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка валидации: {ex.Message}");
                }
            }
            void ShowTeachers()
            {
                Console.WriteLine("Все преподавателм:");
                if (teachers.Count == 0)
                {
                    Console.WriteLine("Список преподавателей пуст");
                    return;
                }
                foreach (var teacher in teachers)
                {
                    teacher.ShowInfo();
                    Console.WriteLine("____________________");
                }
            }
            void AssignTeacherToCourse()
            {
                Console.WriteLine("Назначение преподавателя на курс");
                if (teachers.Count == 0)
                {
                    Console.WriteLine("Список учителей пуст");
                    return;
                }
                if (courses.Count == 0)
                {
                    Console.WriteLine("Список курсов пуст");
                    return;
                }
                Console.WriteLine("Выберите преподавателя:");
                for (int i = 0; i < teachers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {teachers[i].Fio}");
                }
                int teacherIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.WriteLine("Выберите курс:");
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {courses[i].Name}");
                }
                int courseIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                students[teacherIndex].EnrollInCourses(courses[courseIndex]);
                Console.WriteLine("Преподаватель успешно назначен на курс!");
            }
            void CourseMenu()
            {
                while (true)
                {
                    Console.WriteLine("Система управления курсами:");
                    Console.WriteLine("1. Добавить курс");
                    Console.WriteLine("2. Показать все курсы");
                    Console.WriteLine("3. Показать детали курса");
                    Console.WriteLine("4. Вывести студентов курса");
                    Console.WriteLine("0. Выход");
                    Console.Write("Выберите вариант: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddCourse();
                            break;
                        case "2":
                            ShowCourses();
                            break;
                        case "3":
                            ShowCourseDetails();
                            break;
                        case "4":
                            ShowCourseStudents();
                            return;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Неправильный выбор!");
                            return;
                    }
                }
            }
            void AddCourse()
            {
                Console.WriteLine("Добавление курса:");
                Console.WriteLine("Введите данные курсе в следующем формате: название; описание");
                Console.Write("Ваш ввод: ");

                string input = Console.ReadLine();

                string[] parts = input.Split(';');

                if (parts.Length != 2)
                {
                    Console.WriteLine("Неправильный формат ввода. Следуйте шаблону!");
                    return;
                }

                string name = parts[0].Trim();
                string description = parts[1].Trim();

                if (teachers.Count == 0)
                {
                    Console.WriteLine("Список преподавателей пуст");
                    return;
                }

                Console.WriteLine("Выберите преподавателя для курса:");
                for (int i = 0; i < teachers.Count; i++)
                {
                    Console.WriteLine($"{i+1}. {teachers[i].Fio}");
                }

                int teacherIndex = Convert.ToInt32(Console.ReadLine());
                Teacher selectedTeacher = teachers[teacherIndex];
                try
                {
                    Course course = new Course(name, description, selectedTeacher);
                    courses.Add(course);
                    selectedTeacher.AssignToCourse(course);
                    Console.WriteLine($"Курс {name} был успешно создан!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка валидации: {ex.Message}");
                }
            }
            void ShowCourses()
            {
                Console.WriteLine("Все курсы:");
                if (courses.Count == 0)
                {
                    Console.WriteLine("Список курсов пуст");
                    return;
                }
                foreach (var course in courses)
                {
                    Console.WriteLine($"Название: {course.Name}");
                    Console.WriteLine($"Описание: {course.Description}");
                    Console.WriteLine($"Преподаватель: {course.Teacher.Fio}");
                    Console.WriteLine($"Студентов: {course.Students.Count}");
                    Console.WriteLine("____________________________");
                }
            }
            void ShowCourseDetails()
            {
                Console.WriteLine("Детали курса");
                if (courses.Count == 0)
                {
                    Console.WriteLine("Список курсов пуст");
                    return;
                }

                Console.WriteLine("Выберите курс:");
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {courses[i].Name}");
                }
                int index = Convert.ToInt32(Console.ReadLine()) - 1;

                var course = courses[index];
                Console.WriteLine($"Название: {course.Name}");
                Console.WriteLine($"Описание: {course.Description}");
                Console.WriteLine($"Преподаватель: {course.Teacher.Fio}");
                Console.WriteLine($"Студентов записано: {course.Students.Count}");
            }
            void ShowCourseStudents()
            {
                Console.WriteLine("Студенты на курсе");
                if (courses.Count == 0)
                {
                    Console.WriteLine("Список курсов пуст");
                    return;
                }
                Console.WriteLine("Выберите курс:");
                for (int i = 0; i < courses.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {courses[i].Name}");
                }

                int courseIndex = Convert.ToInt32(Console.ReadLine()) - 1;
                Course selectedCourse = courses[courseIndex];

                Console.WriteLine($"Курс: {selectedCourse.Name}");
                Console.WriteLine($"Преподаватель: {selectedCourse.Teacher.Fio}");
                Console.WriteLine($"Описание: {selectedCourse.Description}");
                Console.WriteLine("Список студентов:");

                var enrolledStudents = students.Where(s => s.Courses.Contains(selectedCourse)).ToList();

                if (enrolledStudents.Count == 0)
                {
                    Console.WriteLine("На курсе пока нет студентов.");
                }
                else
                {
                    foreach (var student in enrolledStudents)
                    {
                        Console.WriteLine($"{student.Fio}");
                    }
                }
            }
            void ShowAllLists()
            {
                Console.WriteLine("ВСЕ СПИСКИ");

                if (students.Count == 0)
                {
                    Console.WriteLine("Список студентов пуст");

                }
                else
                {
                    Console.WriteLine("Студенты:");
                    foreach (var s in students)
                    {
                        Console.WriteLine(s.Fio);
                    }
                }
                if (teachers.Count == 0)
                {
                    Console.WriteLine("Список преподавателей пуст");
                }
                else { 
                    Console.WriteLine("Преподаватели:");
                    foreach (var t in teachers)
                    {
                        Console.WriteLine(t.Fio);
                    }
                }
                if (courses.Count == 0)
                {
                    Console.WriteLine("Список курсов пуст");
                }
                else {
                    Console.WriteLine("Курсы:");
                    foreach (var c in courses)
                    {
                        Console.WriteLine(c.Name);
                    }
                }
            }
        }
    }
}


