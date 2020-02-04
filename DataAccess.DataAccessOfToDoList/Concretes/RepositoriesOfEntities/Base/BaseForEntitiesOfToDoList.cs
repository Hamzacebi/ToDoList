using System;

#region Global Usings
using Microsoft.EntityFrameworkCore;
using Commons.CommonOfToDoList.Constants;
using SinanHamzaceBi.GenericRepository.Concretes.RepositoryOfBasics;
#endregion Global Usings

namespace DataAccess.DataAccessOfToDoList.Concretes.RepositoriesOfEntities.Base
{
    public abstract class BaseForEntitiesOfToDoList<T> : RepositoryBase<T> where T : class
    {
        protected BaseForEntitiesOfToDoList(DbContext dbContext, Type inWhichDbContext) : base(dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(message: ConstantsOfErrors.ArgumentNullExceptionMessageForDbContext,
                                                innerException: null);
            }

            if (inWhichDbContext != dbContext.GetType())
            {
                throw new ArgumentNullException(message: ConstantsOfErrors.ArgumentNullExceptionMessageForToDoListDbContext,
                                                innerException: null);
            }

        }
    }
}
