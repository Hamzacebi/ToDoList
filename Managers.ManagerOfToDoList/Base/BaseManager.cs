using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Microsoft.EntityFrameworkCore;
using Commons.CommonOfToDoList.Constants;
using DataAccess.DataAccessOfToDoList.Abstracts.UnitOfWork;
using DataAccess.DataAccessOfToDoList.Concretes.UnitOfWork;
#endregion Global Usings

namespace Managers.ManagerOfToDoList.Base
{
    public abstract class BaseManager
    {
        #region Global Properties

        private IUnitOfWork unitOfWork;
        private readonly DbContext DbContext;

        private readonly object lockObjectForUnitOfWork;


        #endregion Global Properties

        #region Constructor(s)

        protected BaseManager(DbContext dbContext)
        {
            this.DbContext = dbContext ?? throw new ArgumentNullException(message: ConstantsOfError.ArgumentNullExceptionMessageForDbContext,
                                                                          innerException: null);

            this.lockObjectForUnitOfWork = new object();
        }

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                if (this.unitOfWork == null)
                {
                    lock (this.lockObjectForUnitOfWork)
                    {
                        if (this.unitOfWork == null)
                        {
                            this.unitOfWork = new UnitOfWork(dbContext: this.DbContext);
                        }
                    }
                }
                return this.UnitOfWork;
            }
        }

        #endregion Constructor(s)

    }
}
