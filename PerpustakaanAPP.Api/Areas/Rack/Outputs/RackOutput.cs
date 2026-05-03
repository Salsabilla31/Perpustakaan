using PerpustakaanAPP.Api.Base;
using PerpustakaanAPP.Api.Areas.Rack.Models.Responses;

namespace PerpustakaanAPP.Api.Areas.Rack.Outputs
{
    public class RackOutput : OutputBase
    {
        public RackResponsesDTO? Data { get; set; }
    }

    public class RackOutputListOutput : OutputBase
    {
        public List<RackResponsesDTO>? Data { get; set; }
    }
}