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
                                       UserEmail = "sİnan.hamza3çeuibI@.gmaıl.com".ConvertTurkishCharactersToEnglishCharacters()
                                   });

            Assert.True(condition: userToCreate.IsSuccess);
        }
    }
}
