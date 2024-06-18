
using AttendanceClient.Dto.StudentSchedules;

namespace AttendanceMananagmentProject.Dto.StudentSchedules
{
	public class StudentScheduleListDto
	{
		public List<int> StudentId { get; set; }
		public int ScheduleId { get; set; }
		public List<Status> Statuses { get; set; }
	}
}
