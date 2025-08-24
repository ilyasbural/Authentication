namespace Authentication.Newsportix.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;

	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		readonly IConfiguration Configuration;
		public AuthenticationController(IConfiguration configuration) { Configuration = configuration; }

		[HttpPost]
		[Route("api/authentication")]
		[Produces(typeof(AuthenticationResponse))]
		public AuthenticationResponse Authentication([FromBody] BodyParameterAuthentication Model)
		{
			List<Claim> Claims = new List<Claim>()
			{
				//new Claim("Id", "4563475674584678"),
				//new Claim("Email", "ilyasbural@gmail.com"),
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

			string a = Configuration["JwtTokenOptions:Issuer"]!;
			string b = Configuration["JwtTokenOptions:Audience"]!;

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: Configuration["JwtTokenOptions:Issuer"],
				audience: Configuration["JwtTokenOptions:Audience"],
				claims: Claims,
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeydfgdfgdfgdgdfgfdgfdgdfgdfgdfgfdrleojeırjeırjfıeorjeıjerdfgdflıgdflıgdlfıgdl")), SecurityAlgorithms.HmacSha256)
			);
			string value = new JwtSecurityTokenHandler().WriteToken(token);

			return new AuthenticationResponse
			{
				AccessToken = value,
				AccessTokenExpireDate = token.ValidTo,
				RefreshToken = "5464565465465466",
			};
		}
	}
}