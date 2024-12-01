namespace BookstoreA.Service.Exceptions

{
    public class DbConcurrencyException : ApplicationException
    {
        public DbConcurrencyException(string? message) : base(message)
        {
        }
    }
}