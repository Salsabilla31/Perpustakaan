using PerpustakaanAPP.Api.Areas.AreaBook.Models.Request;
using PerpustakaanAPP.Api.Areas.AreaBook.Models.Responses;
using PerpustakaanAPP.Data.Access.Models;
using Microsoft.EntityFrameworkCore; 
using AreaBookEntity = PerpustakaanAPP.Data.Access.Models.AreaBook;

namespace PerpustakaanAPP.Api.Areas.AreaBook.Services
{
    public class AreaBookService
    {
        private readonly DataContext dataContext;

        public AreaBookService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<AreaBookResponsesDTO> AddAsync(AreaBookRequestDTO req)
        {
            var exists = await dataContext.AreaBooks
                .AnyAsync(a => a.Areacode == req.Areacode);

            if (exists)
            {
                throw new InvalidOperationException(
                    $"Areacode '{req.Areacode}' sudah ada, gunakan nilai unik."
                );
            }

            var areabook = new AreaBookEntity
            {
                Areacode = req.Areacode,
                Areaname = req.Areaname,
                Areadescription = req.Areadescription,
                Isactive = req.Isactive,
            };

            dataContext.AreaBooks.Add(areabook);
            await dataContext.SaveChangesAsync();

            return new AreaBookResponsesDTO
            {
                Areaid = areabook.Areaid,
                Areacode = areabook.Areacode,
                Areaname = areabook.Areaname,
                Areadescription = areabook.Areadescription,
                Isactive = areabook.Isactive
            };
        }

        public async Task<AreaBookResponsesDTO?> UpdateAsync(int id, AreaBookRequestDTO req)
        {
            var areabook = await dataContext.AreaBooks.FindAsync(id);
            if (areabook == null) return null;

            var exists = await dataContext.AreaBooks
                .AnyAsync(a => a.Areacode == req.Areacode && a.Areaid != id);

            if (exists)
            {
                throw new InvalidOperationException(
                    $"Areacode '{req.Areacode}' sudah digunakan oleh Area lain."
                );
            }

            areabook.Areacode = req.Areacode;
            areabook.Areaname = req.Areaname;
            areabook.Areadescription = req.Areadescription;
            areabook.Isactive = req.Isactive;

            await dataContext.SaveChangesAsync();

            return new AreaBookResponsesDTO
            {
                Areaid = areabook.Areaid,
                Areacode = areabook.Areacode,
                Areaname = areabook.Areaname,
                Areadescription = areabook.Areadescription,
                Isactive = areabook.Isactive
            };
        }

        public async Task<AreaBookResponsesDTO?> DeleteAsync(int id)
        {
            var areabook = await dataContext.AreaBooks.FindAsync(id);
            if (areabook == null) return null;

            dataContext.AreaBooks.Remove(areabook);
            await dataContext.SaveChangesAsync();

            return new AreaBookResponsesDTO
            {
                Areaid = areabook.Areaid,
                Areacode = areabook.Areacode,
                Areaname = areabook.Areaname,
                Areadescription = areabook.Areadescription,
                Isactive = areabook.Isactive
            };
        }
    }
}
