using PerpustakaanAPP.Api.Areas.Rack.Models.Request;
using PerpustakaanAPP.Api.Areas.Rack.Models.Responses;
using PerpustakaanAPP.Data.Access.Models;
using Microsoft.EntityFrameworkCore;
using RackEntity = PerpustakaanAPP.Data.Access.Models.Racks;

namespace PerpustakaanAPP.Api.Areas.Rack.Services
{
    public class RackService
    {
        private readonly DataContext dataContext;

        public RackService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<RackResponsesDTO> AddAsync(RackRequestDTO req)
        {
            var exists = await dataContext.Racks
                .AnyAsync(a => a.Rackcode == req.Rackcode);

            if (exists)
            {
                throw new InvalidOperationException(
                    $"Rackcode '{req.Rackcode}' sudah ada, gunakan nilai unik."
                );
            }

            var rack = new RackEntity   
            {
                Areaid = req.Areaid,
                Rackcode = req.Rackcode,
                Rackname = req.Rackname,
                Rackdescription = req.Rackdescription,
                Capacity = req.Capacity,
                Isactive = req.Isactive,
            };

            dataContext.Racks.Add(rack);
            await dataContext.SaveChangesAsync();

            return new RackResponsesDTO
            {
                Rackid = rack.Rackid,
                Areaid = rack.Areaid,
                Rackcode = rack.Rackcode,
                Rackname = rack.Rackname,
                Rackdescription = rack.Rackdescription,
                Capacity = rack.Capacity,
                Isactive = rack.Isactive
            };
        }

        public async Task<RackResponsesDTO?> UpdateAsync(int id, RackRequestDTO req)
        {
            var rack = await dataContext.Racks.FindAsync(id);
            if (rack == null) return null;

            var exists = await dataContext.Racks
                .AnyAsync(a => a.Rackcode == req.Rackcode && a.Rackid != id);

            if (exists)
            {
                throw new InvalidOperationException(
                    $"Rackcode '{req.Rackcode}' sudah digunakan oleh Rack lain."
                );
            }
            rack.Areaid = req.Areaid;
            rack.Rackcode = req.Rackcode;
            rack.Rackname = req.Rackname;
            rack.Rackdescription = req.Rackdescription;
            rack.Capacity = req.Capacity;
            rack.Isactive = req.Isactive;

            await dataContext.SaveChangesAsync();

            return new RackResponsesDTO
            {
                Rackid = rack.Rackid,
                Areaid = rack.Areaid,
                Rackcode = rack.Rackcode,
                Rackname = rack.Rackname,
                Rackdescription = rack.Rackdescription,
                Capacity = rack.Capacity,
                Isactive = rack.Isactive
            };
        }

        public async Task<RackResponsesDTO?> DeleteAsync(int id)
        {
            var rack = await dataContext.Racks.FindAsync(id);
            if (rack == null) return null;

            dataContext.Racks.Remove(rack);
            await dataContext.SaveChangesAsync();

            return new RackResponsesDTO
            {
                Rackid = rack.Rackid,
                Areaid = rack.Areaid,
                Rackcode = rack.Rackcode,
                Rackname = rack.Rackname,
                Rackdescription = rack.Rackdescription,
                Capacity = rack.Capacity,
                Isactive = rack.Isactive
            };
        }
    }
}
