using AttendanceClient.Dto.StudentCourse;
using AttendanceClient.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttendanceClient.Pages.Report
{
    public class IndexModel : PageModel
	{
		private StudentCourseService studentCourseService;

		public IndexModel(StudentCourseService studentCourseService)
		{
			this.studentCourseService = studentCourseService;
		}

		public List<StudentCourseDTO> StudentCourses { get; set; }
		public async Task OnGet()
		{

		}

		public async Task GetData()
		{
			string id = User.Claims.First(claim => claim.Type == "Id").Value;
			StudentCourses = await studentCourseService.ListStudentCourse(Int32.Parse(id));
		}
	}
}
