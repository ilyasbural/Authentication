namespace Authentication.Avipes.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.IdentityModel.Tokens;
	using System.Text;
	using System.Security.Claims;
	using System.IdentityModel.Tokens.Jwt;

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
				new Claim("Id", "4563475674584678"),
				new Claim("Email", "ilyasbural@gmail.com"),
				new Claim("Name", "fghfg"),
				new Claim("Lastname", "rtytry"),
				new Claim("Birthdate", "54646"),
				new Claim("Gender", "dfgdf"),
				new Claim("Address", "rgfdgsdfg"),
				new Claim("Phone", "sddfgdg"),
				new Claim("Country", "dfgdsf"),
				new Claim("State", "fghfgh"),
				new Claim("City", "ertert"),
				new Claim("Access", "gfhdfhgf"),
				new Claim("PostalCode", "456456"),
				new Claim("RegisterDate", "6858"),
				new Claim("UpdateDate", "567567"),
				new Claim("Authentication", "fdgdfgf"),
				new Claim("AccessToken", ""),
				new Claim("AccessTokenExpireDate", "retert"),
				new Claim("RefreshToken", "dfgdfg"),
				new Claim("RefreshTokenExpireDate", "ertert")
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

			return new CreateResponse
			{
				AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
				AccessTokenExpireDate = token.ValidTo,
				RefreshToken = "5464565465465466",
			};
		}
	}
}