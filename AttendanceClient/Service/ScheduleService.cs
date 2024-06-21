using AttendanceClient.Dto.Schedule;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace AttendanceClient.Service
{
    public class ScheduleService : BaseService
    {

        public async Task<List<ScheduleDTO>> GetStudentSchedule(int week, int year, int sid)
        {
            string url = $"Schedule/Student?week={week}&year={year}&sid={sid}";
            List<ScheduleDTO> schedules = await GetData<List<ScheduleDTO>>(url);
            return schedules;
        }

        public async Task<List<ScheduleDTO>> GetTeacherSchedule(int week, int year, int tid)
        {
            string url = $"Schedule/Teacher?week={week}&year={year}&tid={tid}";
            List<ScheduleDTO> schedules = await GetData<List<ScheduleDTO>>(url);
            return schedules;
        }

        public async Task<HttpResponseMessage> UploadCourse(IFormFile Upload)
        {


            string url = "http://localhost:5142/api/Course/Upload";

            HttpClient client = new HttpClient();
            await using var memoryStream = new MemoryStream();
            await Upload.CopyToAsync(memoryStream);
            var fileContent = new ByteArrayContent(memoryStream.ToArray());


            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(fileContent, "Upload", "file");

            HttpResponseMessage response = await client.PostAsync(url,formData);
            //httpContent.Add(fileContent, "Upload");
            //var response = await client.PostAsync(url, httpContent);
            return response;



        }
    }
}
