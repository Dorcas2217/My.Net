namespace Student_API_Controller
{
    public class StudentList
    {
        private List<Student> _students;

        public StudentList()
        {
            _students = new List<Student>()
            {
                new Student(1, "Paul", "Ochoa", new DateTime(1950, 12, 1)),
                new Student(2, "Daisy", "Drathey", new DateTime(1970, 12, 1)),
                new Student(3, "Elie", "Coptaire", new DateTime(1980, 12, 1))
            };
        }

        public List<Student> Students()
        {
            return _students;
        }
        public void AddStudent(Student student)
        {
            _students.Add(student);
        }
        public Student GetStudent(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }
    }
}
