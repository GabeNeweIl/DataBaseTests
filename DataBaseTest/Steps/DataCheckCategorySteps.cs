using DataBaseTest.Models;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DataCheckCategorySteps
    {
        private Category expectedCategory;

        private Category actualCategory;

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
        
        [When(@"I do an query to get record from table production\.categories with id '(.*)'")]
        public void WhenIDoAnQueryToGetRecordFromTableProduction_CategoriesWithId(int id)
        {
            actualCategory = StaticContext.context.Categories.Find(id);
        }
        
        [Then(@"Records from production\.categories should include the same information like in testing data")]
        public void ThenRecordsFromProduction_CategoriesShouldIncludeTheSameInformationLikeInTestingData()
        {
            try
            {
                expectedCategory.Should().BeEquivalentTo(actualCategory);
            }
            catch (Exception)
            {
                throw new Exception($"Expected data from table production.brands should be:" + "\n" + $"CategoryId: {expectedCategory.CategoryId}; CategoryName: {expectedCategory.CategoryName}" + "\n"
                    + "But actual data was:" + "\n" + $"CategorydId: {actualCategory.CategoryId}; CategoryName: {actualCategory.CategoryName}");
            }
        }
    }
}
