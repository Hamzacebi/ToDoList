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
    public class XUnitTestAssignmentHistoryOfTask
    {
        private readonly IManagerAssignmentHistoryOfTask managerAssignmentHistoryOfTask;

        public XUnitTestAssignmentHistoryOfTask()
        {
            this.managerAssignmentHistoryOfTask = new ManagerAssignmentHistoryOfTask();
        }

        [Fact]
        public void FirstTestFunctionForAssignmentHistoryOfTask()
        {

        }
    }
}
