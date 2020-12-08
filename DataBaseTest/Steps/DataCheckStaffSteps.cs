using DataBaseTest.Models;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DataCheckStaffSteps
    {
        private Staff expectedStaff;

        private Staff record;

        [Given(@"Test information of staff with following data")]
        public void GivenTestInformationOfStaffWithFollowingData(Table table)
        {
            dynamic testData = table.CreateDynamicInstance();

            expectedStaff = new Staff()
            {
                StaffId = (int)testData.StaffId,

                FirstName = (string)testData.FirstName,
                
                LastName = (string)testData.LastName,
                
                Email = (string)testData.Email,
                
                Phone = (string)testData.Phone,
                
                Active = (byte)testData.Active,
                
                StoreId = (int)testData.StoreId,

                ManagerId = (int?)testData.ManagerId
            };
        }
        
        [When(@"I do an query to get record from table sales\.staff with id '(.*)'")]
        public void WhenIDoAnQueryToGetRecordFromTableSales_StaffWithId(int id)
        {
            record = StaticContext.context.Staffs.Find(id);
        }

        [Then(@"Records from sales\.staff should include the same information like in testing data")]
        public void ThenRecordsFromSales_StaffShouldIncludeTheSameInformationLikeInTestingData()
        {
            expectedStaff.Should().BeEquivalentTo(record);
        }

    }
}
