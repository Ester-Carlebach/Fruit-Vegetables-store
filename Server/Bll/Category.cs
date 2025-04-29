
namespace Bll
{
    public class Category:IBll.IBlCategory
    {
        IDal.IDallCategory dalC;
        public Category(IDal.IDallCategory c)
        {
            this.dalC = c;
        }
        //קריאה לפונקצית שליפת כל הקטגוריות
        public async Task<List<Dto.Category> >GetCategory()
        {
            return await dalC.GetCategory();
        }

    }
}
