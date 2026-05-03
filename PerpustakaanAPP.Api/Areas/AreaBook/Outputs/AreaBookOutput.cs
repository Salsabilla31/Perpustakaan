using PerpustakaanAPP.Api.Base;
using PerpustakaanAPP.Api.Areas.AreaBook.Models.Responses;

namespace PerpustakaanAPP.Api.Areas.AreaBook.Outputs
{
    public class AreaBookOutput : OutputBase
    {
        public AreaBookResponsesDTO? Data { get; set; }
    }

    public class AreaBookOutputListOutput : OutputBase
    {
        public List<AreaBookResponsesDTO>? Data { get; set; }
    }
}