using DataBaseTest.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace DataBaseTest.Steps
{
    [Binding]
    public class DuplicatesSteps
    {
        private IEnumerable<string> duplicates;

        private List<Customer> customers;

        private List<Brand> brands;

        private List<Category> categories;

        private List<Product> products;

        private List<Staff> staffs;

        private List<Store> stores;

        [When(@"I am making a query for duplicates in a table (.*)")]
        public void WhenIAmMakingAQueryForDuplicatesInATable(string tableName)
        {   
            switch(tableName)
            {
                case "sales.customers":
                    customers = StaticContext.context.Customers.AsNoTracking().ToList();
                    duplicates = customers.GroupBy(i => i.Email).Where(x => x.Count() > 1).Select(val => val.Key);
                    break;

                case "production.brands":
                    brands = StaticContext.context.Brands.AsNoTracking().ToList();
                    duplicates = brands.GroupBy(i => i.BrandName).Where(x => x.Count() > 1).Select(val => val.Key);
                    break;
                case "production.categories":
                    categories = StaticContext.context.Categories.AsNoTracking().ToList();
                    duplicates = categories.GroupBy(i => i.CategoryName).Where(x => x.Count() > 1).Select(val => val.Key);
                    break;

                case "productions.products":
                    products = StaticContext.context.Products.AsNoTracking().ToList();
                    duplicates = products.GroupBy(i => i.ProductName).Where(x => x.Count() > 1).Select(val => val.Key);
                    break;

                case "sale.staff":
                    staffs = StaticContext.context.Staffs.AsNoTracking().ToList();
                    duplicates = staffs.GroupBy(i => i.Email).Where(x => x.Count() > 1).Select(val => val.Key);
                    break;

                case "sale.stores":
                    stores = StaticContext.context.Stores.AsNoTracking().ToList();
                    duplicates = stores.GroupBy(i => i.StoreName).Where(x => x.Count() > 1).Select(val => val.Key);
                    break;
            }
        }

        [Then(@"Count of duplicate should be '(.*)'")]
        public void ThenCountOfDuplicateShouldBe(int expectedResult)
        {
             Assert.AreEqual(expectedResult, duplicates.Count(), $"Are not equal! Count of duplicates {duplicates.Count()}");
        }
        //
    }
}
