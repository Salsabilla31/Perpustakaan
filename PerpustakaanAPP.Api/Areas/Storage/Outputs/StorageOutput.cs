using PerpustakaanAPP.Api.Base;
using PerpustakaanAPP.Api.Areas.Storage.Models.Response;

namespace PerpustakaanAPP.Api.Areas.Storage.Outputs
{
    public class StorageOutput : OutputBase
    {
        public StorageResponseDTO? Data { get; set; }
    }

    public class StorageOutputListOutput : OutputBase
    {
        public List<StorageResponseDTO>? Data { get; set; }
    }
}