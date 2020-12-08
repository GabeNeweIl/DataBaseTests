using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using TechTalk.SpecFlow;

namespace DataBaseTest.Steps
{
    [Binding]
    public class NotNullableTableSteps
    {
        private int recordsCount;

        [When(@"I am making an query for (.*)")]
        public void WhenIAmMakingAQueryForTable(string tableName)
        {
            switch (tableName)
            {
                case "sales.customers":
                    recordsCount = StaticContext.context.Customers.AsNoTracking().Count();
                    break;

                case "production.brands":
                    recordsCount = StaticContext.context.Brands.AsNoTracking().Count();
                    break;

                case "production.categories":
                    recordsCount = StaticContext.context.Categories.AsNoTracking().Count();
                    break;

                case "productions.products":
                    recordsCount = StaticContext.context.Products.AsNoTracking().Count();
                    break;

                case "sale.staff":
                    recordsCount = StaticContext.context.Staffs.AsNoTracking().Count();
                    break;

                case "sale.stores":
                    recordsCount = StaticContext.context.Stores.AsNoTracking().Count();
                    break;
            }
        }

        [Then(@"Count of records should be more the '(.*)'")]
        public void ThenCountOfRecordsShouldBeMoreThe(int expectedCount)
        {
            Assert.LessOrEqual(expectedCount, recordsCount);
        } 
    }
}
