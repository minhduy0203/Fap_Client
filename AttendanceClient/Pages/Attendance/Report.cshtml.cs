using AttendanceClient.Dto.StudentCourse;
using AttendanceClient.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttendanceClient.Pages.Attendance
{
	public class ReportModel : PageModel
	{
		private StudentCourseService studentCourseService;
		public List<StudentCourseDTO> StudentCourses { get; set; }
		public StudentCourseDTO StudentCourseDTO { get; set; }
		public string Message { get; set; }
		[BindProperty(SupportsGet =true)]
		public int CourseId { get; set; }

		public ReportModel(StudentCourseService studentCourseService)
		{
			this.studentCourseService = studentCourseService;
		}

		public async Task OnGet()
		{
			await GetData();
		}

		public async Task GetData()
		{
			try
			{
				int id = Int32.Parse(User.Claims.First(claim => claim.Type == "Id").Value);
				StudentCourses = await studentCourseService.ListStudentCourse(id);
				if (CourseId != 0)
					StudentCourseDTO = await studentCourseService.GetStudentCourse(id, CourseId);
			}
			catch (Exception ex)
			{

				Message = ex.Message;
			}

		}
	}
}
