using System;
using System.Text;
using System.Collections.Generic;

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

    public class RepositoryOfUser : BaseForEntitiesOfToDoList<Users>, IRepositoryOfUser
    {
        private bool disposedValue;

        public RepositoryOfUser(DbContext dbContext, Type inWhichDbContext) : base(dbContext, inWhichDbContext)
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

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
