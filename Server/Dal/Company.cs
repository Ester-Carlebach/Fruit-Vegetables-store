
using Dal.models;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class Company : IDal.IDallCompany
    {
        ShopContext db;
        public Company(ShopContext db)
        {
            this.db = db;
        }
        //שליפת כל החברות
        public async Task<List<Dto.Company>> Get()
        {
            var q = await db.Companies.ToListAsync();
            return Converters.Company.ToListCourseDto(q);
        }

    }
}
