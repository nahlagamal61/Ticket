namespace WebAPI.Controllers
{
    using Domains.Authentication;
    using Domains.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using WebAPI.Wrapper;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                if (userRoles != null)
                {

                    var authClaims = new List<Claim>
                    {
                        new Claim (ClaimTypes.Email , user.Email),
                        new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
                    };
                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                        );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo, 
                        role = userRoles.FirstOrDefault(),
                    });
                }
                return BadRequest();

            }
            else
            {
                return BadRequest(new CustomResponse<LoginModel>(loginModel, "failed to login", (int)HttpStatusCode.BadRequest));
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Username);
            if (userExists != null)
                return BadRequest( new CustomResponse<RegisterModel>( model, "User already exists!" , (int)HttpStatusCode.BadRequest) );

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return BadRequest(new CustomResponse<RegisterModel>(model, "User creation failed! Please check user details and try again.", (int)HttpStatusCode.InternalServerError));
            
            if (!await _roleManager.RoleExistsAsync(UserRole.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRole.User));

            if (await _roleManager.RoleExistsAsync(UserRole.User))
            {
                await _userManager.AddToRoleAsync(user, UserRole.User);
            }

            return Ok(new CustomResponse<RegisterModel>(model, "User created successfully!", (int)HttpStatusCode.OK));

        }

    }
}
