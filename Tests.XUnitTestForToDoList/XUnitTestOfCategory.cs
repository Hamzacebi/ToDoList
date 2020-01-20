using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Managers.ManagerOfToDoList.Abstracts;
using Managers.ManagerOfToDoList.Concretes;
using Xunit;
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
        public void CategoryTestFunction()
        {
            
        }
    }
}
