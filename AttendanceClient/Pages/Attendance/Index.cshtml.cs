using AttendanceClient.Dto.Schedule;
using AttendanceClient.Dto.StudentSchedules;
using AttendanceClient.Service;
using AttendanceMananagmentProject.Dto.StudentSchedules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AttendanceClient.Pages.Attendance
{
	public class IndexModel : PageModel
	{
		[BindProperty(SupportsGet = true)]
		public int ScheduleId { get; set; }

        public ScheduleDTO Schedule { get; set; }

        [BindProperty]
        public int[] Statuses { get; set; }

		[BindProperty]
        public int[] sid { get; set; }

        public AttendanceService attendanceService { get; set; }

		public IndexModel(AttendanceService attendanceService)
		{
			this.attendanceService = attendanceService;
		}

		public async Task OnGet()
		{
			await GetData();
		}

		public async Task OnPost()
		{
			StudentScheduleListDto request = new StudentScheduleListDto
			{
				Statuses = this.Statuses.Select(ss => (Status) ss).ToList(),
				StudentId = this.sid.ToList(),
				ScheduleId = this.ScheduleId
			};
			attendanceService.AttendListStudent(request);
			await GetData();
		}

		public async Task GetData()
		{
			Schedule = await attendanceService.GetScheduleAttendance(ScheduleId);
			Statuses = Schedule.StudentSchedules.Select(ss => ((int)ss.Status)).ToArray();
		}
	}
}
