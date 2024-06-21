using AttendanceClient.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace AttendanceClient.Pages.Schedule
{

	[Authorize(Roles = "ADMIN")]
	public class ImportModel : PageModel
	{

		private ScheduleService scheduleService;
		public string result { get; set; }
		public ImportModel(ScheduleService scheduleService)
		{
			this.scheduleService = scheduleService;
		}

		public void OnGet()
		{
		}

		public async Task<FileResult> OnPost(IFormFile Upload)
		{
			try
			{

				HttpResponseMessage response = await scheduleService.UploadCourse(Upload);
				result = "Upload successfully";

				return File(response.Content.ReadAsStream(), "text/csv", "Course.csv");


			}
			catch (Exception ex)
			{

				result = "Import failed";
			}

			return File(Encoding.UTF8.GetBytes(result.ToString()), "text/csv", "Course.csv");


		}
	}
}
