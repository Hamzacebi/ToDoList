using System;

#region Global Usings
using Commons.CommonOfToDoList.Constants;
using Microsoft.EntityFrameworkCore;
using Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseContext;
using SinanHamzaceBi.GenericRepository.Concretes.RepositoryOfBasics;
#endregion Global Usings

namespace DataAccess.DataAccessOfToDoList.Concretes.RepositoriesOfEntities.Base
{
    public abstract class BaseForEntitiesOfToDoList<T> : RepositoryBase<T> where T : class
    {
        protected BaseForEntitiesOfToDoList(DbContext dbContext) : base(dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(message: ConstantsOfError.ArgumentNullExceptionMessageForDbContext,
                                                innerException: null);
            }

            if (typeof(ToDoListDbContext) != dbContext.GetType())
            {
                throw new ArgumentNullException(message: ConstantsOfError.ArgumentNullExceptionMessageForToDoListDbContext,
                                                innerException: null);
            }

        }
    }
}
