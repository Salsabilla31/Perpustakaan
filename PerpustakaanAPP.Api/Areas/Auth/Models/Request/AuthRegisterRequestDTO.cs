namespace PerpustakaanAPP.Api.Areas.Auth.Models.Request
{
    public class AuthRegisterRequestDTO
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string PasswordVerify { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthPlace { get; set; }
        public string? BirthDate { get; set; }
    }
}
