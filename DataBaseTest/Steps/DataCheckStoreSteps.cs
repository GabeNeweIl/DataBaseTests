using DataBaseTest.Models;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DataCheckStoreSteps
    {
        private Store expectedStore;

        private Store actualStore;

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
        
        [When(@"I do an query to get record from the table sales\.store with id '(.*)'")]
        public void WhenIDoAnQueryToGetRecordFromTheTableSale_StoreWithId(int id)
        {
            actualStore = StaticContext.context.Stores.Find(id);
        }

        [Then(@"Records from sales\.store should include the same information like in testing data")]
        public void ThenRecordsFromSales_StoreShouldIncludeTheSameInformationLikeInTestingData()
        {
            try
            {
                expectedStore.Should().BeEquivalentTo(actualStore);
            }
            catch (Exception)
            {
                throw new Exception($"Expected data from table sales.store should be:" + "\n" + $"StaffId: {expectedStore.StoreId}; " +
                    $"Email: {expectedStore.Email}; Phone: {expectedStore.Phone}; Street: {expectedStore.Street}; City: {expectedStore.City}; " +
                    $"State: {expectedStore.State}; ZipCode: {expectedStore.ZipCode}" + "\n"
                    + "But actual data was:" + "\n" + $"StaffId: {actualStore.StoreId}; " +
                    $"Email: {actualStore.Email}; Phone: {actualStore.Phone}; Street: {actualStore.Street}; City: {actualStore.City}; " +
                    $"State: {actualStore.State}; ZipCode: {actualStore.ZipCode}");
            }

        }
    }
}
