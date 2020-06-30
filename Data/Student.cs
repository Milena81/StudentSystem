namespace StudentSystem.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Student
    {
        public int Id { get; set; }
        //we put Required when the field is not null, because string is null by default
        [Required]  
        public string Name { get; set; }

        public string Phone { get; set; }

        //DateTime is not Null by default
        public DateTime RegistrationDate { get; set; }

        //because it is optional field, we put ? after the DateTime? type
        public DateTime? Birthday { get; set; }

        //connect to table StudentCourse
        public List<StudentCourse> Courses { get; set; } = new List<StudentCourse>();

        public List<Homework> Homeworks { get; set; } = new List<Homework>();
    }
}
