using AttendanceClient.Dto.Schedule;
using AttendanceClient.Dto.Student;

namespace AttendanceClient.Dto.StudentSchedules
{
	public class AttendanceDto
	{
	
		public int ScheduleId { get; set; }
		public ScheduleDTO Schedule { get; set; }
		public Status Status { get; set; }
	}
}
