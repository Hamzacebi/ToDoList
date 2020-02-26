using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

#region Global Usings
using Managers.ManagerOfToDoList.Abstracts;
using Managers.ManagerOfToDoList.Concretes;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory;
#endregion Global Usings

namespace Tests.XUnitTestForToDoList
{
    public class XUnitTestOfCategory
    {
        private readonly IManagerOfCategory managerOfCategory;

        public XUnitTestOfCategory()
        {
            this.managerOfCategory = new ManagerOfCategory();
        }

        [Fact]
        public void CreateNewCategory()
        {
            this.managerOfCategory
                .CreateNewCategory(new WebAPIModelOfInsertCategory()
                {
                    CategoryName = "İlk Kategori",
                    CategoryDescription = "Eklenen ilk Kategori",
                    UserIdOfCategoryOwner = Guid.Parse(input: "bc604889-aefc-43c1-81a5-b97cacfa3982")
                });
        }

        [Fact]
        public void UpdateExistingCategory()
        {
            var updatedCategory = this.managerOfCategory.UpdateExistingCategory(new WebAPIModelOfUpdateCategory()
            {
                CategoryDescription = "First Update",
                CategoryId = 3,
                CategoryName = "İlk Kategori",
                CategoryStatus = false,
                UserIdOfCategoryOwner = Guid.Parse(input: "bc604889-aefc-43c1-81a5-b97cacfa3982")
            });
        }

        [Fact]
        public void FetchAllCategoryByUserId()
        {
            var allCategoriesOwnedByTheUser = this.managerOfCategory.FetchAllCategoryByUserId(userId: Guid.Parse(input: "bc604889-aefc-43c1-81a5-b97cacfa3982"));
        }
    }
}
