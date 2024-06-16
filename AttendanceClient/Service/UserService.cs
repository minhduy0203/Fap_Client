using AttendanceClient.Dto;
using AttendanceClient.Dto.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AttendanceClient.Service
{
    public class UserService : BaseService
    {
        public UserService()
        {

        }

        public async Task<string> Login(LoginRequest request)
        {
          Response<LoginResponse> result = await PostData<Response<LoginResponse>, LoginRequest>("User/Login", request);
            if(result.Data != null)
            {
                return result.Data.Token;
             
            } else
            {
                return null;


            }
        }
    }
}
