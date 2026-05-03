using PerpustakaanAPP.Api.Areas.Auth.Models.Request;
using PerpustakaanAPP.Api.Areas.Auth.Models.Responses;

namespace PerpustakaanAPP.Api.Areas.Auth.Services
{
    public class AuthService
    {
        public AuthRegisterResponsesDTO Register(AuthRegisterRequestDTO req)
        {
            var result = new AuthRegisterResponsesDTO
            {
                Username = req.Username,
                Email = req.Email,
                FirstName = req.FirstName,
                LastName = req.LastName,
                BirthPlace = req.BirthPlace,
                BirthDate = req.BirthDate,
            };
            return result;
        }
    }
}
