namespace Authentication.Avipes
{
	public class UserModel
	{
		public Int64 Id { get; set; }
		public String Email { get; set; }
		public String Name { get; set; }
		public String Lastname { get; set; }
		public DateTime Birthdate { get; set; }
		public Byte Gender { get; set; }
		public String Address { get; set; }
		public String Phone { get; set; }
		public String Country { get; set; }
		public String State { get; set; }
		public String City { get; set; }
		public String Access { get; set; }
		public String PostalCode { get; set; }
		public DateTime RegisterDate { get; set; }
		public DateTime UpdateDate { get; set; }
		public String Authentication { get; set; }
		public String AccessToken { get; set; }
		public DateTime AccessTokenExpireDate { get; set; }
		public String RefreshToken { get; set; }
		public DateTime RefreshTokenExpireDate { get; set; }
	}
}