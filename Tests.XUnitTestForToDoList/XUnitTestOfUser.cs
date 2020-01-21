using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

#region Global Usings
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
            Assert.True(condition: this.userManager.CreateNewUser(new WebAPIModelOfInsertUser
            {
                UserEmail = "email@email.com",
                UserName = "First User",
                UserPassword = "Password",
                UserSurname = "First Surname"
            }));
        }
    }
}
