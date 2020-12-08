using DataBaseTest.Models;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DataCheckStoreSteps
    {
        private Store expectedStore;

        private Store record;

        [Given(@"Test information of store with following data")]
        public void GivenTestInformationOfStoreWithFollowingData(Table table)
        {
            dynamic testData = table.CreateDynamicInstance();

            expectedStore = new Store()
            {
                StoreId = testData.StoreId,

                StoreName = (string)testData.StoreName,

                Phone = (string)testData.Phone,
                
                Email = (string)testData.Email,
                
                Street = (string)testData.Street,
                
                City = (string)testData.City,
                
                State = (string)testData.State,
                
                ZipCode = testData.ZipCode.ToString()
            };
        }
        
        [When(@"I do a query to get record from the table ""(.*)"" wiht id '(.*)'")]
        public void WhenIDoAQueryToGetRecordFromTheTable(string p0, int id)
        {
            record = StaticContext.context.Stores.Find(id);
        }

        [Then(@"Records from sales\.store should include the same information like in testing data")]
        public void ThenRecordsFromSales_StoreShouldIncludeTheSameInformationLikeInTestingData()
        {
            expectedStore.Should().BeEquivalentTo(record);
        }
    }
}
