using DataBaseTest.Models;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DataCheckBrandSteps
    {
        private Brand expectedBrand;

        private Brand record;

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
        
        [When(@"I do an a query to get record from table production\.brands with id '(.*)'")]
        public void WhenIDoAnAQueryToGetRecordFromTableProduction_BrandsWithId(int id)
        {
            record = StaticContext.context.Brands.Find(id);
        }
        
        [Then(@"Records from production\.brands should include the same information like in testing data")]
        public void ThenRecordsFromProduction_BrandsShouldIncludeTheSameInformationLikeInTestingData()
        {
            expectedBrand.Should().BeEquivalentTo(record);
        }
    }
}
