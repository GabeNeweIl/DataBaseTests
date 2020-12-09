using DataBaseTest.Models;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DataCheckStaffSteps
    {
        private Staff expectedStaff;

        private Staff actualStaff;

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
            actualStaff = StaticContext.context.Staffs.Find(id);
        }

        [Then(@"Records from sales\.staff should include the same information like in testing data")]
        public void ThenRecordsFromSales_StaffShouldIncludeTheSameInformationLikeInTestingData()
        {
            try
            {
                expectedStaff.Should().BeEquivalentTo(actualStaff);
            }
            catch (Exception)
            {
                throw new Exception($"Expected data from table sales.staff should be:" + "\n" + $"StaffId: {expectedStaff.StaffId}; FirstName: {expectedStaff.FirstName}; " +
                    $"LastName: {expectedStaff.LastName}; Email: {expectedStaff.Email}; Phone: {expectedStaff.Phone}; Active: {expectedStaff.Active}; " +
                    $"StoreId: {expectedStaff.StoreId}; ManagerId: {expectedStaff.ManagerId}" + "\n"
                    + "But actual data was:" + "\n" + $"StaffId: {actualStaff.StaffId}; FirstName: {actualStaff.FirstName}; " +
                    $"LastName: {actualStaff.LastName}; Email: {actualStaff.Email}; Phone: {actualStaff.Phone}; Active: {actualStaff.Active}; " +
                    $"StoreId: {actualStaff.StoreId}; ManagerId: {actualStaff.ManagerId}");
            }
        }

    }
}
