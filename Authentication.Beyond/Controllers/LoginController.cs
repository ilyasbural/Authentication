namespace Authentication.Beyond.Controllers
{
	using System.Text;
	using System.Security.Claims;
	using Microsoft.AspNetCore.Mvc;
	using System.IdentityModel.Tokens.Jwt;
	using Microsoft.IdentityModel.Tokens;

	[ApiController]
	public class LoginController : ControllerBase
	{
		readonly IConfiguration Configuration;
		public LoginController(IConfiguration configuration) { Configuration = configuration; }

		[HttpPost]
		[Route("api/login")]
		[Produces(typeof(LoginResponse))]
		public LoginResponse Authentication([FromBody] BodyParameterAuthentication Model)
		{
			List<Claim> Claims = new List<Claim>()
			{
				new Claim("Id", "4563475674584678"),
				new Claim("Email", "ilyasbural@gmail.com"),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("", ""),
				//new Claim("Authentication", ""),
				//new Claim("AccessTokenExpireDate", ""),
				//new Claim("RefreshToken", ""),
				//new Claim("RefreshTokenExpireDate", "")
			};

			List<Claim> Roles = new List<Claim>()
			{
				new Claim("Role", "Reader"),
				new Claim("Role", "Writer"),
			};

			Claims.AddRange(Roles);

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: Configuration["JwtTokenOptions:Issuer"],
				audience: Configuration["JwtTokenOptions:Audience"],
				claims: Claims,
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeydfgdfgdfgdgdfgfdgfdgdfgdfgdfgfdrleojeırjeırjfıeorjeıjerdfgdflıgdflıgdlfıgdl")), SecurityAlgorithms.HmacSha256)
			);
			string value = new JwtSecurityTokenHandler().WriteToken(token);

			return new LoginResponse
			{
				AccessToken = value,
				AccessTokenExpireDate = token.ValidTo,
				RefreshToken = "5464565465465466",
			};
		}
	}
}