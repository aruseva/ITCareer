﻿using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism
{
    // my namespace
    using Courses;

    /// <summary>
    /// Inheritance and Polymorphism main program class.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Inheritance and Polymorphism main program method.
        /// </summary>
        static void Main(string[] args)
        {
            LocalCourse localCourse = new LocalCourse("Databases");
            Console.WriteLine(localCourse);

            localCourse.Lab = "Enterprise";
            Console.WriteLine(localCourse);

            localCourse.Students = new List<string>() { "Peter", "Maria" };
            Console.WriteLine(localCourse);

            localCourse.TeacherName = "Svetlin Nakov";
            localCourse.Students.Add("Milena");
            localCourse.Students.Add("Todor");
            Console.WriteLine(localCourse);

            OffsiteCourse offsiteCourse = new OffsiteCourse(
                "PHP and WordPress Development", "Mario Peshev",
                new List<string>() { "Thomas", "Ani", "Steve" });
            Console.WriteLine(offsiteCourse);
        }
    }
}
