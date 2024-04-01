namespace StudentData.Models.Domain
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long Fee { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Department { get; set;}

    }
}
