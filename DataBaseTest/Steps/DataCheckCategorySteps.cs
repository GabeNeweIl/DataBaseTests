using DataBaseTest.Models;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DataCheckCategorySteps
    {
        private Category expectedCategory;

        private Category record;

        [Given(@"The infromation of category with following data")]
        public void GivenTheInfromationOfCategoryWithFollowingData(Table table)
        {
            dynamic testData = table.CreateDynamicInstance();

            expectedCategory = new Category()
            {
                CategoryId = (int)testData.CategoryId,

                CategoryName = (string)testData.CategoryName
            };
        }
        
        [When(@"I do an a query to get record from table production\.categories with id '(.*)'")]
        public void WhenIDoAnAQueryToGetRecordFromTableProduction_CategoriesWithId(int id)
        {
            record = StaticContext.context.Categories.Find(id);
        }
        
        [Then(@"Records from production\.categories should include the same information like in testing data")]
        public void ThenRecordsFromProduction_CategoriesShouldIncludeTheSameInformationLikeInTestingData()
        {
            expectedCategory.Should().BeEquivalentTo(record);
        }
    }
}
