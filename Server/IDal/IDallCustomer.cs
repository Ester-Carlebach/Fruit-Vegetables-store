namespace IDal
{
    public interface IDallCustomer:IDallServices<Dto.Customer>
    {
        //שליפת  לקוח ע"פ ת.ז
        public Task<Dto.Customer> ?GetById(string id);
        //הרשמה
        public Task<int> SignIn(Dto.Customer customer);
    }
}
