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

    public class RepositoryOfThingToDo : BaseForEntitiesOfToDoList<ThingsToDo>, IRepositoryOfThingToDo
    {
        private bool disposedValue;

        public RepositoryOfThingToDo(DbContext dbContext, Type inWhichDbContext) : base(dbContext, inWhichDbContext)
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
