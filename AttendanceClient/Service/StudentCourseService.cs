using AttendanceClient.Dto.StudentCourse;
using AttendanceClient.Dto.StudentSchedules;
using AttendanceMananagmentProject.Dto.StudentSchedules;

namespace AttendanceClient.Service
{
	public class StudentCourseService : BaseService
	{
		public async Task<List<StudentCourseDTO>> ListStudentCourse(int id)
		{
			string url = $"StudentCourse/List/Student/{id}";
			List<StudentCourseDTO> result = await GetData<List<StudentCourseDTO>>(url);
			return result;
		}

		public async Task<List<AttendanceDto>> GetStudentCourse(int sid, int cid)
		{
			string url = $"StudentSchedule/List/Student?sid={sid}&cid={cid}";
			List<AttendanceDto> result = await GetData<List<AttendanceDto>>(url);
			return result;
		}
	}
}
