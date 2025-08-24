namespace Authentication.Avonyu
{
	public class LoginResponse
	{
		public String AccessToken { get; set; } = String.Empty;
		public DateTime AccessTokenExpireDate { get; set; }
		public String RefreshToken { get; set; } = String.Empty;
	}
}