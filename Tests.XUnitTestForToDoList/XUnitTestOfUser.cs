using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

#region Global Usings
using Managers.ManagerOfToDoList.Abstracts;
using Managers.ManagerOfToDoList.Concretes;
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
        public void Hamsi()
        {

        }
    }
}
