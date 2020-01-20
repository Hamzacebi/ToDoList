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
    public class XUnitTestOfThingToDo
    {
        private readonly IManagerOfThingToDo managerOfThingToDo;

        public XUnitTestOfThingToDo()
        {
            this.managerOfThingToDo = new ManagerOfThingToDo();
        }

        [Fact]
        public void FirstTestFunctionForThingToDo()
        {

        }
    }
}
