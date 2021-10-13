namespace FirstUnitTest
{
    public interface ICustomer
    {
        string GreetMessage { get; set; }
        bool IsPlatinum { get; set; }
        int OrderTotal { get; set; }

        int Discount { get; set; }

        CustomerType GetCustomerDetails();
        string GreetAndCombineName(string firstName, string LastName);
    }
}