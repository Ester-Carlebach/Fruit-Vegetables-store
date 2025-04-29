namespace IDal
{
    public interface IDallCompany:IDallServices<Dto.Company>
    {
        //שליפת כל החברות
        public Task<List<Dto.Company>> Get();
    }
}
