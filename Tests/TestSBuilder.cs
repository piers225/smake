using NUnit.Framework;

namespace Demo.Tests
{
    [TestFixture]
    public class TestSBuilder
    {

        [Test]
        public void Newline_and_Parameters_Inserted()
        {
            var result = SBuilder.SMake("%S is not known.%NPlease enter a valid %S.", "Store", "centre");
            Assert.That(result, Is.EqualTo("Store is not known." + Environment.NewLine + "Please enter a valid centre."));
        }

        [Test]
        public void One_Percentage_Is_Used()
        {
            var result = SBuilder.SMake("20%% VAT will be applied.");
            Assert.That(result, Is.EqualTo("20% VAT will be applied."));
        }

        [Test]
        public void Repeat_Calling_Builds_Up_String()
        {
            string result = null;
            int[] ids = { 1, 2, 3, 4 };

            foreach (int id in ids)
            {
                result = SBuilder.SMake("%S%,%S", result, id);
            }
            Assert.That("1,2,3,4", Is.EqualTo(result));
        }

        [Test]
        public void Percentage_And_Name_Replaced()
        {
            var result = SBuilder.SMake("%%%S%% %S", "STATUS", 500);
            Assert.That(result, Is.EqualTo("%STATUS% 500"));
        }
    }
}
