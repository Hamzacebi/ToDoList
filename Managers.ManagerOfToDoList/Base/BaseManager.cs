using System;

#region Global Usings 
using Helpers.HelperOfToDoList.Tools;
using Helpers.HelperOfToDoList.Mappers;
using Helpers.HelperOfToDoList.Mappers.Base;
using DataAccess.DataAccessOfToDoList.Abstracts.UnitOfWork;
using DataAccess.DataAccessOfToDoList.Concretes.UnitOfWork;
using Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseContext;
using Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfDataTransferObject;
#endregion Global Usings

namespace Managers.ManagerOfToDoList.Base
{
    public abstract class BaseManager : IDisposable
    {
        #region Global Properties
        private readonly object userMapperOfLocObject, categoryMapperOfLockObject,
                                thingToDoOfLockObject, lockObjectForAssignmentHistoryOfTask;

        private IMapper<Users, DTOOfUser> userMapper;
        private IMapper<Categories, DTOOfCategory> categoryMapper;
        private IMapper<ThingsToDo, DTOOfThingToDo> thingToDoMapper;
        private IMapper<AssignmentHistoryOfTasks, DTOOfAssignmentHistoryOfTask> assignmentHistoryOfTaskMapper;
        #endregion Global Properties

        #region Constructor(s)

        protected BaseManager()
        {
            this.userMapperOfLocObject =
            this.thingToDoOfLockObject =
            this.categoryMapperOfLockObject =
            this.lockObjectForAssignmentHistoryOfTask = new object();
        }

        #endregion Constructor(s)

        #region UnitOfWork Property

        protected IUnitOfWork UnitOfWork
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IUnitOfWork>(resultToReturnClass: typeof(UnitOfWork),
                                                                                constructorParameters: new object[] { new ToDoListDbContext() });
            }
        }

        #endregion UnitOfWork Property

        #region Mapper Properties

        protected IMapper<Users, DTOOfUser> UserMapper
        {
            get
            {
                // ToDo :IMapper<TEntity,TDTO> yani generic oldugu icin cast aninda hata veriyor. cozum uretilmesi gerekiyor
                //return UtilityTools.CreateGenericSingletonInstance<IMapper<Users, DTOOfUser>>(resultToReturnClass: typeof(UserMapper));
                if (this.userMapper == null)
                {
                    lock (this.userMapperOfLocObject)
                    {
                        if (this.userMapper == null)
                        {
                            this.userMapper = new UserMapper();
                        }
                    }
                }
                return this.userMapper;
            }
        }

        protected IMapper<Categories, DTOOfCategory> CategoryMapper
        {
            get
            {
                if (this.categoryMapper == null)
                {
                    lock (this.categoryMapperOfLockObject)
                    {
                        if (this.categoryMapper == null)
                        {
                            this.categoryMapper = new CategoryMapper();
                        }
                    }
                }
                return this.categoryMapper;
            }
        }

        protected IMapper<ThingsToDo, DTOOfThingToDo> ThingToDoMapper
        {
            get
            {
                if (this.thingToDoMapper == null)
                {
                    lock (this.thingToDoOfLockObject)
                    {
                        if (this.thingToDoMapper == null)
                        {
                            this.thingToDoMapper = new ThingToDoMapper();
                        }
                    }
                }
                return this.thingToDoMapper;
            }
        }

        protected IMapper<AssignmentHistoryOfTasks, DTOOfAssignmentHistoryOfTask> AssignmentHistoryOfTaskMapper
        {
            get
            {
                if (this.assignmentHistoryOfTaskMapper == null)
                {
                    lock (this.lockObjectForAssignmentHistoryOfTask)
                    {
                        if (this.assignmentHistoryOfTaskMapper == null)
                        {
                            this.assignmentHistoryOfTaskMapper = new AssignmentHistoryOfTaskMapper();
                        }
                    }
                }
                return this.assignmentHistoryOfTaskMapper;
            }
        }
        #endregion Mapper Properties


        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this.UnitOfWork.Dispose();
                    UtilityTools.CreateUtilityInstance.Dispose();
                }
                disposedValue = true;
            }
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }
        #endregion IDisposable Support
    }
}
