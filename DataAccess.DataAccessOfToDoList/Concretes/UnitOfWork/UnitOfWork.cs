using System;

#region Global Usings
using Microsoft.EntityFrameworkCore;
using Helpers.HelperOfToDoList.Tools;
using Commons.CommonOfToDoList.Constants;
using Helpers.HelperOfToDoList.Extensions;
using Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseContext;
#endregion Global Usings

namespace DataAccess.DataAccessOfToDoList.Concretes.UnitOfWork
{
    #region Internal Project Usings
    using Abstracts.RepositoriesOfEntities;
    using Abstracts.UnitOfWork;
    using Microsoft.EntityFrameworkCore.Storage;
    using RepositoriesOfEntities;

    #endregion Internal Project Usings

    public class UnitOfWork : IUnitOfWork
    {
        #region Global Properties

        private bool disposedValue;

        private DbContext DbContext;
        private IDbContextTransaction DbContextTransaction;

        #endregion Global Properties


        #region Constructor(s)

        public UnitOfWork(DbContext dbContext)
        {
            this.DbContext = dbContext ?? throw new ArgumentNullException(message: ConstantsOfErrors.ArgumentNullExceptionMessageForDbContext,
                                                                         innerException: null);
            //DbContext nesnesi bos degilse islemler yapilsin
            this.disposedValue = default(bool);
        }
        #endregion Constructor(s)


        #region SaveChanges Function

        int IUnitOfWork.SaveChanges()
        {
            return ExtensionsOfFunction.TryCatch<int>(
                    function: () =>
                    {
                        return this.DbContext.SaveChanges();
                    }
                );
        }

        #endregion SaveChanges Function


        #region Transaction Functions

        void IUnitOfWork.BeginTransaction()
        {
            if (this.DbContext != null)
            {
                ExtensionsOfAction.TryCatch(
                    action: () =>
                    {
                        this.DbContextTransaction = this.DbContext.Database.BeginTransaction(isolationLevel: System.Data.IsolationLevel.ReadUncommitted);
                    },
                    catchAndDo: (Exception exception) => throw exception
                );
            }
            else
            {
                throw new ArgumentNullException(message: ConstantsOfErrors.ArgumentNullExceptionMessageForDbContext,
                                            innerException: null);
            }
        }

        void IUnitOfWork.CommitTransaction()
        {
            if (this.DbContextTransaction != null)
            {
                ExtensionsOfAction.TryCatch(
                        action: () => this.DbContextTransaction.Commit(),
                        catchAndDo: (Exception exception) =>
                        {
                            this.DbContextTransaction.Rollback();
                            throw exception;
                        },
                        finallyDo: () => { this.DbContextTransaction.Dispose(); this.DbContext.Dispose(); }
                    );
            }
            else
            {
                throw new ArgumentNullException(message: ConstantsOfErrors.ArgumentNullExceptionMessageForDbContextTransaction,
                                            innerException: null);
            }
        }

        void IUnitOfWork.RollbackTransaction()
        {
            if (this.DbContextTransaction != null)
            {
                ExtensionsOfAction.TryCatch(
                   action: () => this.DbContextTransaction.Rollback(),
                   catchAndDo: (Exception exception) =>
                   {
                       this.DbContextTransaction.Rollback();
                       throw exception;
                   },
                   finallyDo: () => { this.DbContextTransaction.Dispose(); this.DbContext.Dispose(); }
               );
            }
            else
            {
                throw new ArgumentNullException(message: ConstantsOfErrors.ArgumentNullExceptionMessageForDbContextTransaction,
                                           innerException: null);
            }
        }

        #endregion Transaction Functions


        #region Repositories Properties

        IRepositoryOfUser IUnitOfWork.RepositoryOfUser
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IRepositoryOfUser>(resultToReturnClass: typeof(RepositoryOfUser),
                                                                                    constructorParameters: new object[] { this.DbContext,
                                                                                                                          typeof(ToDoListDbContext) });
            }
        }

        IRepositoryOfCategory IUnitOfWork.RepositoryOfCategory
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IRepositoryOfCategory>(resultToReturnClass: typeof(RepositoryOfUser),
                                                                                          constructorParameters: new object[] { this.DbContext,
                                                                                                                                typeof(ToDoListDbContext) });
            }
        }

        IRepositoryOfThingToDo IUnitOfWork.RepositoryOfThingToDo
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IRepositoryOfThingToDo>(resultToReturnClass: typeof(RepositoryOfThingToDo),
                                                                                           constructorParameters: new object[] { this.DbContext,
                                                                                                                                 typeof(ToDoListDbContext) });
            }
        }

        IRepositoryAssignmentHistoryOfTask IUnitOfWork.RepositoryAssignmentHistoryOfTask
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IRepositoryAssignmentHistoryOfTask>(resultToReturnClass: typeof(RepositoryAssignmentHistoryOfTask),
                                                                                                       constructorParameters: new object[] { this.DbContext,
                                                                                                                                             typeof(ToDoListDbContext) });
            }
        }
        #endregion Repositories Properties

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    UtilityTools.CreateUtilityInstance.Dispose();
                    if (this.DbContextTransaction != null)
                    {
                        this.DbContextTransaction.Dispose();
                        this.DbContextTransaction = null;
                    }
                    this.DbContext.Dispose();
                    this.DbContext = null;
                }
                disposedValue = true;
            }
        }
        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion  IDisposable Support
    }
}
