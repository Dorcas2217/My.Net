using Microsoft.AspNetCore.Mvc;

namespace Student_API_Controller.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private StudentList _studentList;

        public StudentController()
        {
            _studentList = new StudentList();
        }

        [HttpGet("/students")]
        public IEnumerable<Student> GetAll()
        {
            return _studentList.Students();
        }

        [HttpGet("/students/{id}")]
        public Student Get(int id)
        {
            return _studentList.GetStudent(id);
        }

        [HttpPost("/students/add")]
        public void Post([FromBody] Student student)
        {
            _studentList.AddStudent(student);
        }
    }
}
