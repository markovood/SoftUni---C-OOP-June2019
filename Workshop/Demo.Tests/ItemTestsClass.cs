using CustomTestingFramework.Asserts;
using CustomTestingFramework.Attributes;

namespace Demo.Tests
{
    [TestClass]
    public class ItemTestsClass
    {
        [TestMethod]
        public void Property_Price_GetterGetsProperly()
        {
            Item item = new Item();
            decimal actual = item.Price;
            decimal expected = 0m;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void Property_Price_SetterSetsProperly()
        {
            Item item = new Item();
            item.Price = 5m;

            decimal actual = item.Price;
            decimal expected = 5m;

            Assert.AreEqual(actual, expected);
        }
    }
}
