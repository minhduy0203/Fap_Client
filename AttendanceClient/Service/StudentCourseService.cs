using AttendanceClient.Dto.StudentCourse;

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

		public async Task<StudentCourseDTO> GetStudentCourse(int sid, int cid)
		{
			string url = $"StudentCourse?sid={sid}&cid={cid}";
			StudentCourseDTO result = await GetData<StudentCourseDTO>(url);
			return result;
		}
	}
}
