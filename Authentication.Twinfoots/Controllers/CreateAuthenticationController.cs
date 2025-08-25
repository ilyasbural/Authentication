namespace Authentication.Twinfoots.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;

	[ApiController]
	public class CreateAuthenticationController : ControllerBase
	{
		readonly IConfiguration Configuration;
		public CreateAuthenticationController(IConfiguration configuration) { Configuration = configuration; }

		[HttpPost]
		[Route("api/create")]
		[Produces(typeof(CreateResponse))]
		public CreateResponse CreateAuthentication([FromBody] BodyParameterCreate Model)
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

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: Configuration["JwtTokenOptions:Issuer"],
				audience: Configuration["JwtTokenOptions:Audience"],
				claims: Claims,
				notBefore: DateTime.Now,
				expires: DateTime.Now.AddMinutes(30),
				signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeydfgdfgdfgdgdfgfdgfdgdfgdfgdfgfdrleojeırjeırjfıeorjeıjerdfgdflıgdflıgdlfıgdl")), SecurityAlgorithms.HmacSha256)
			);
			string value = new JwtSecurityTokenHandler().WriteToken(token);

			return new CreateResponse
			{
				AccessToken = value,
				AccessTokenExpireDate = token.ValidTo,
				RefreshToken = "5464565465465466",
			};
		}
	}
}