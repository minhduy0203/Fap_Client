using AttendanceClient.Dto.Schedule;

namespace AttendanceClient.Service
{
	public class ScheduleService : BaseService
	{

		public async Task<List<ScheduleDTO>> GetStudentSchedule(int week, int year, int sid)
		{
			string url = $"Schedule/Student?week={week}&year={year}&sid={sid}";
			List<ScheduleDTO> schedules  = await GetData<List<ScheduleDTO>>(url);
			return schedules;
		}

		public async Task<List<ScheduleDTO>> GetTeacherSchedule(int week, int year, int tid)
		{
			string url = $"Schedule/Student?week={week}&year={year}&tid={tid}";
			List<ScheduleDTO> schedules = await GetData<List<ScheduleDTO>>(url);
			return schedules;
		}
	}
}
