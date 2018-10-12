using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lssn_6
{
    class Student
    {

        public string firstName, lastName, university, faculty, department, city;
        public int course, group, age;

        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.age = age;
            this.course = course;
            this.group = group;
            this.city = city;
        }

        //  Метод для сортировки по курсу и возрасту
        public static int MyDelegat(Student st1, Student st2)
        {
            return (100 * st1.course + st1.age) - (100 * st2.course + st2.age);
        }
    }
}
