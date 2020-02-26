using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

#region Global Usings
using Helpers.HelperOfToDoList.Extensions;
using Managers.ManagerOfToDoList.Abstracts;
using Managers.ManagerOfToDoList.Concretes;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser;
#endregion Global Usings

namespace Tests.XUnitTestForToDoList
{
    public class XUnitTestOfUser
    {
        private readonly IManagerOfUser userManager;

        public XUnitTestOfUser()
        {
            this.userManager = new ManagerOfUser();
        }

        [Fact]
        public void CreateNewUser()
        {
            var userToCreate = this.userManager
                                   .CreateNewUser(itemToAdd: new WebAPIModelOfInsertUser()
                                   {
                                       UserName = "Sinan",
                                       UserPassword = "Palamut",
                                       UserSurname = "Hamzaçebi",
                                       UserEmail = "generic@instance.denemesi1".ConvertTurkishCharactersToEnglishCharacters()
                                   });

            Assert.True(condition: userToCreate.IsSuccess);
        }

        [Fact]
        public void UpdateExistingUser()
        {
            var userToUpdate = this.userManager
                                   .UpdateExistingUser(userToUpdate: new WebAPIModelOfUpdateUser()
                                   {
                                       UserId = Guid.Parse(input: "e4bf2a60-0c35-4543-9866-5b8ee76d9d42"),
                                       UserName = "Sinan Updatee",
                                       UserPassword = "Mezgit",
                                       UserStatus = true,
                                       UserSurname = "Hamzacebi"
                                   });

            Assert.True(userToUpdate.ResultInformation.IsSuccess);
        }

        [Fact]
        public void FetchUserByWhereConditions()
        {
            var fetchUserById = this.userManager.FetchUserById(userId: Guid.Parse(input: "bc604889-aefc-43c1-81a5-b97cacfa3982"));
            Assert.True(condition: fetchUserById.SuccessInformation.IsSuccess);
        }
    }
}
