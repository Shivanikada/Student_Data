﻿namespace StudentData.Models
{
    public class UpdateStudentView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Fee { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Department { get; set; }
    }
}
