using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities;
#endregion Global Usings

namespace DataAccess.DataAccessOfToDoList.Concretes.RepositoriesOfEntities
{
    #region Internal Project Usings
    using Base;
    using Microsoft.EntityFrameworkCore;
    using Abstracts.RepositoriesOfEntities;
    #endregion Internal Project Usings

    public class RepositoryAssignmentHistoryOfTask : BaseForEntitiesOfToDoList<AssignmentHistoryOfTasks>, IRepositoryAssignmentHistoryOfTask
    {
        private bool disposedValue;

        public RepositoryAssignmentHistoryOfTask(DbContext dbContext) : base(dbContext)
        {
            this.disposedValue = default(bool);
        }

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.DbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
