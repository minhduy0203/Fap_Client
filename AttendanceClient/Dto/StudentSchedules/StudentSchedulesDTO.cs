
using System.ComponentModel;

namespace AttendanceClient.Dto.StudentSchedules
{
    public class StudentSchedulesDTO
    {
        public int StudentId { get; set; }
        public int ScheduleId { get; set; }
        public Status Status { get; set; }


    }

    public enum Status
    {
        NOT_YET,
        ATTENDED,
        ABSENT
    }
}
