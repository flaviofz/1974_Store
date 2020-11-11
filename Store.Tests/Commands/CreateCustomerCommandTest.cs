using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Commands.CustomerCommands.Inputs;

namespace Store.Tests
{
    [TestClass]
    public class CreateCustomerCommandTest
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Flavio";
            command.LastName = "Zavarise";
            command.Email = "flaviofz@gmail.com";
            command.Document = "12345678912";

            Assert.AreEqual(true, command.Valid());
        }
    }
}
