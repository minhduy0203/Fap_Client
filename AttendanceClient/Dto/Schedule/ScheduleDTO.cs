using AttendanceClient.Dto.Course;
using AttendanceClient.Dto.Room;
using AttendanceClient.Dto.StudentSchedules;
using AttendanceClient.Dto.Teacher;


namespace AttendanceClient.Dto.Schedule
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public int Slot { get; set; }
        public DateTime Date { get; set; }

        public int CourseId { get; set; }
        public CourseDTO Course { get; set; }
        public int TeacherId { get; set; }
        public TeacherDTO Teacher { get; set; }

        public int RoomId { get; set; }

        public RoomDTO Room { get; set; }
        public ICollection<StudentSchedulesDTO>? StudentSchedules { get; set; }
    }
}
