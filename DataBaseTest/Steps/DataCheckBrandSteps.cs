using DataBaseTest.Models;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DataCheckBrandSteps
    {
        private Brand expectedBrand;

        private Brand actualBrand;

        [Given(@"The infromation of brand with following data")]
        public void GivenTheInfromationOfBrandWithFollowingData(Table table)
        {
            dynamic testData = table.CreateDynamicInstance();

            expectedBrand = new Brand()
            {
                BrandId = (int)testData.BrandId,

                BrandName = (string)testData.BrandName
            };
        }
        
        [When(@"I do an query to get record from table production\.brands with id '(.*)'")]
        public void WhenIDoAnQueryToGetRecordFromTableProduction_BrandsWithId(int id)
        {
            actualBrand = StaticContext.context.Brands.Find(id);
        }
        
        [Then(@"Records from production\.brands should include the same information like in testing data")]
        public void ThenRecordsFromProduction_BrandsShouldIncludeTheSameInformationLikeInTestingData()
        {
            try
            {
                expectedBrand.Should().BeEquivalentTo(actualBrand);
            }
            catch (Exception)
            {
                throw new Exception($"Expected data from table production.brand should be:" + "\n" + $"BranddId: {expectedBrand.BrandId}; BrandName: {expectedBrand.BrandName}" + "\n" 
                    + "But actual data was:" + "\n" + $"BrandId: {actualBrand.BrandId}; BrandName: {actualBrand.BrandName}");
            }
        }
    }
}
