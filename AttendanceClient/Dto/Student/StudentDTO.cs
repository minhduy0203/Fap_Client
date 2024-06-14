using AttendanceClient.Dto.StudentSchedules;


namespace AttendanceClient.Dto.Student
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }

        public string? Email { get; set; }

        public ICollection<StudentSchedulesDTO>? StudentSchedules { get; set; }
    }
}
