using AttendanceClient.Dto.Schedule;
using AttendanceClient.Service;
using AttendanceClient.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Security.Claims;

namespace AttendanceClient.Pages.Schedule
{
	[Authorize]
	public class IndexModel : PageModel
	{
		[BindProperty]
		public int week { get; set; }
		[BindProperty]
		public int year { get; set; } = DateTime.Now.Year;
		public List<string> schedulesWeek { get; set; }
		public List<int> scheduleYear { get; set; }
		public List<ScheduleDTO> Schedules { get; set; } = new List<ScheduleDTO>();

		private ScheduleService ScheduleService;

		public IndexModel(ScheduleService scheduleService)
		{
			ScheduleService = scheduleService;
		}

		public async Task OnGet()
		{
			DateTime dt = DateTime.Now;
			Calendar cal = new CultureInfo("en-US").Calendar;
			week = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
			await GetData();
		}

		public async Task OnPost()
		{
			await GetData();
		}

		public async Task GetData()
		{

			schedulesWeek = ScheduleLogic.GetAllWeeksInYear(DateTime.Now.Year);
			scheduleYear = new List<int>();
			for (int i = DateTime.Now.Year - 2; i <= DateTime.Now.Year + 1; i++)
			{
				scheduleYear.Add(i);
			}

			string role = User.Claims.First(claim => claim.Type == ClaimTypes.Role).Value;
			string id = User.Claims.First(claim => claim.Type == "Id").Value;
			if (role == "TEACHER")
			{
				Schedules = await ScheduleService.GetTeacherSchedule(week, year, Int32.Parse(id));
			}
			else if (role == "STUDENT")
			{
				Schedules = await ScheduleService.GetStudentSchedule(week, year, Int32.Parse(id));
			}



		}
	}
}
