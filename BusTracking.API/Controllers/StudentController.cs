using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;
		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}
		[HttpGet("GetAllStudents")]
		public IEnumerable<Student?> GetAllStudents()
		{
			return _studentService.GetAllStudents();
		}
		[HttpGet("GetStudentById/{id}")]
		public Student? GetStudentById(int id)
		{
			return _studentService.GetStudentById(id);
		}
		[HttpPost("CreateStudent")]
		public int CreateStudent(Student student)
		{
			return _studentService.CreateStudent(student);
		}
		[HttpPut("UpdateStudent")]
		public void UpdateStudent(Student student)
		{
			_studentService.UpdateStudent(student);
		}
		[HttpDelete("DeleteStudent/{id}")]
		public void DeleteStudent(int id)
		{
			_studentService.DeleteStudent(id);
		}
		[HttpPost("UploadStudentImage")]
		public Student UploadStudentImage()
		{
			IFormFile formFile = Request.Form.Files[0];
			string fileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
			string fullPath = Path.Combine("Images/Students", fileName);
			using (FileStream stream = new FileStream(fullPath, FileMode.Create))
			{
				formFile.CopyTo(stream);
			}
			return new Student { Image = fileName };
		}
	}
}
