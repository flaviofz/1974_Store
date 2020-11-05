using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class NameTests
    {
        private Name invalidName;
        private Name validName;

        public NameTests()
        {
            invalidName = new Name("", "");
            validName = new Name("Flavio", "Zavarise");

        }

        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            Assert.AreEqual(false, invalidName.IsValid);
            //Assert.AreEqual(1, invalidName.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenNameIsValid()
        {
            Assert.AreEqual(true, validName.IsValid);
            Assert.AreEqual(0, validName.Notifications.Count);
        }
    }
}
