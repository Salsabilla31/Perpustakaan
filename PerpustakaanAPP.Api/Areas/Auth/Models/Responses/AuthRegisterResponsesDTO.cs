namespace PerpustakaanAPP.Api.Areas.Auth.Models.Responses
{
    public class AuthRegisterResponsesDTO
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? BirthPlace { get; set; }
        public string? BirthDate { get; set; }
    }
}
