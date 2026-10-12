namespace bt_12_10_4._8
{
    public class Student
    {
        public string StudentId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public Student() { }

        public Student(string studentId, string fullName, int age, string gender)
        {
            StudentId = studentId;
            FullName = fullName;
            Age = age;
            Gender = gender;
        }
    }
}
