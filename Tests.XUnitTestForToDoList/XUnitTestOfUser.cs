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
                                       UserEmail = "sİnan.hamzaÇebI@gmaıl.com".ConvertTurkishCharactersToEnglishCharacters()
                                   });

            Assert.True(condition: userToCreate.IsSuccess);
        }

        [Fact]
        public void UpdateExistingUser()
        {
            var userToUpdate = this.userManager
                                   .UpdateExistingUser(userToUpdate: new WebAPIModelOfUpdateUser()
                                   {
                                       UserId = Guid.Parse(input: "d1477a22-22b7-4944-9d9c-c56b091c7f37"),
                                       UserName = "Sinan Updatee",
                                       UserPassword = "Mezgit",
                                       UserStatus = true,
                                       UserSurname = "Hamzacebi"
                                   });

            Assert.True(userToUpdate.ResultInformation.IsSuccess);
        }

        //[Fact]
        //public void GetUserById
    }
}
