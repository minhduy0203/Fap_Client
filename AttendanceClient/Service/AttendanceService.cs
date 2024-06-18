using AttendanceClient.Dto.Schedule;
using AttendanceClient.Dto.StudentSchedules;
using AttendanceMananagmentProject.Dto.StudentSchedules;

namespace AttendanceClient.Service
{
	public class AttendanceService : BaseService
	{

		public async Task<ScheduleDTO> GetScheduleAttendance(int scheduleId)
		{
			string url = $"Schedule/{scheduleId}";
			ScheduleDTO result = await GetData<ScheduleDTO>(url);
			return result;
		}

		public async Task<List<StudentSchedulesDTO>> AttendListStudent(StudentScheduleListDto request)
		{
			List<StudentSchedulesDTO> result = await PostData<List<StudentSchedulesDTO>, StudentScheduleListDto>("StudentSchedule/List/Attend",request);
			return result;
		}
	}
}
