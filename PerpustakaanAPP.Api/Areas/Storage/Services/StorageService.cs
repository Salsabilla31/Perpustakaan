using PerpustakaanAPP.Api.Areas.Storage.Models.Request;
using PerpustakaanAPP.Api.Areas.Storage.Models.Response;
using PerpustakaanAPP.Api.Areas.Storage.Outputs;
using PerpustakaanAPP.Data.Access.Models;
using System.Collections.Generic;

namespace PerpustakaanAPP.Api.Areas.Storage.Services
{
    public class StorageService     
    {
        private readonly DataContext dataContext;

        public StorageService(DataContext datacontext)
        {
            this.dataContext = datacontext;
        }
        public async Task<StorageResponseDTO> AddAsync(StorageRequestDTO req)
        {
            var storage = new Storages
            {
                Bookid = req.Bookid,
                Rackid = req.Rackid
            };
            dataContext.Add(storage);
            await dataContext.SaveChangesAsync();
            return new StorageResponseDTO()
            {
                Storageid = storage.Storageid,
                Bookid = storage.Bookid,
                Rackid = storage.Rackid
            };
        }

        public async Task<StorageResponseDTO?> UpdateAsync(int id, StorageRequestDTO req)
        {
            var storage = await dataContext.Storages.FindAsync(id);
            if (storage == null)
            {
                return null;
            }
            storage.Bookid = req.Bookid;
            storage.Rackid = req.Rackid;
            await dataContext.SaveChangesAsync();
            return new StorageResponseDTO
            {
                Storageid = storage.Storageid,
                Bookid = storage.Bookid,
                Rackid = storage.Rackid
            };
        }

        public async Task<StorageResponseDTO?> DeleteAsync(int id)
        {
            var storage = await dataContext.Storages.FindAsync(id);

            if (storage == null)
            {
                return null;
            }

            dataContext.Storages.Remove(storage);
            await dataContext.SaveChangesAsync();
            return new StorageResponseDTO
            {
                Storageid = storage.Storageid,
                Bookid = storage.Bookid,
                Rackid = storage.Rackid
            };
        }


    }
}