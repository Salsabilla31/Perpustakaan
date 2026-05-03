using PerpustakaanAPP.Api.Areas.Auth.Models.Request;
using PerpustakaanAPP.Api.Areas.Auth.Models.Responses;
using PerpustakaanAPP.Api.Base;

namespace PerpustakaanAPP.Api.Areas.Auth.Outputs
{
    public class AuthRegisterOuput : OutputBase
    {
        public AuthRegisterResponsesDTO? Data { get; set; }
    }

    public class AuthRegisterListOuput : OutputBase
    {
        public List<AuthRegisterResponsesDTO>? Data { get; set; }
    }
}
