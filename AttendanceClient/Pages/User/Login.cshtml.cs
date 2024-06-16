using AttendanceClient.Dto.User;
using AttendanceClient.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AttendanceClient.Pages.User
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public LoginRequest UserLogin { get; set; }

        public string Message { get; set; }

        public UserService userService { get; set; }

        public LoginModel(UserService userService)
        {
            this.userService = userService;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            string result = await userService.Login(UserLogin);
            if (result != null)
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(result);
                var tokenS = jsonToken as JwtSecurityToken;
                string email = tokenS.Claims.First(claim => claim.Type.Equals(ClaimTypes.Name)).Value;
                string role = tokenS.Claims.First(claim => claim.Type.Equals(ClaimTypes.Role)).Value;
				string id =  tokenS.Claims.First(claim => claim.Type.Equals("Id")).Value;

				List<Claim> claims = new List<Claim>()
              {
                  new Claim(ClaimTypes.Name, email),
                  new Claim(ClaimTypes.Role,role),
                  new Claim("Id", id)
              };


                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties()
                {
                    IsPersistent = true
                });
                return Redirect("/");
            }
            else
            {
                Message = "Email or password is incorrect";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //Redirect to login page    
            return Redirect("/User/Login");
        }
    }
}
