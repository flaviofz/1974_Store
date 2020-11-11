namespace Store.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository 
    { 
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void Save(Customer customer);
    }
}