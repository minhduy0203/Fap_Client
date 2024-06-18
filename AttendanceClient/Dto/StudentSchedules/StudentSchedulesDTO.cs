
using AttendanceClient.Dto.Schedule;
using AttendanceClient.Dto.Student;
using System.ComponentModel;

namespace AttendanceClient.Dto.StudentSchedules
{
    public class StudentSchedulesDTO
    {
        public int StudentId { get; set; }

        public StudentDTO Student { get; set; }
        public int ScheduleId { get; set; }
        public ScheduleDTO Schedule { get; set; }
        public Status Status { get; set; }


    }

    public enum Status
    {
        NOT_YET,
        ABSENT,
        ATTENDED
    }
}
