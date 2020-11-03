using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var customer = new Customer("Flavio", "Zavarise", "13120696321", "flaviofz@gmail.com", "92443554", "Rua Tal");

            var order = new Order(customer);
            order.AddItem();
        }
    }
}
