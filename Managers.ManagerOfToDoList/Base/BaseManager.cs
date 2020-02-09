using System;

#region Global Usings 
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

        private IUnitOfWork unitOfWork;

        private readonly object lockObjectForUnitOfWork;
        private readonly object lockObjectForUserMapper;
        private readonly object lockObjectForCategoryMapper;
        private readonly object lockObjectForThingToDoMapper;
        private readonly object lockObjectForAssignmentHistoryOfTaskMapper;

        private IMapper<Users, DTOOfUser> userMapper;
        private IMapper<Categories, DTOOfCategory> categoryMapper;
        private IMapper<ThingsToDo, DTOOfThingToDo> thingToDoMapper;
        private IMapper<AssignmentHistoryOfTasks, DTOOfAssignmentHistoryOfTask> assignmentHistoryOfTaskMapper;

        #endregion Global Properties

        #region Constructor(s)

        protected BaseManager()
        {
            this.lockObjectForUnitOfWork =
            this.lockObjectForUserMapper =
            this.lockObjectForCategoryMapper =
            this.lockObjectForThingToDoMapper =
            this.lockObjectForAssignmentHistoryOfTaskMapper = new object();
        }

        #endregion Constructor(s)

        #region UnitOfWork Property

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
                            this.unitOfWork = new UnitOfWork(dbContext: new ToDoListDbContext());
                        }
                    }
                }
                return this.unitOfWork;
            }
        }

        #endregion UnitOfWork Property

        #region Mapper Properties

        protected IMapper<Users, DTOOfUser> UserMapper
        {
            get
            {
                if (this.userMapper == null)
                {
                    lock (this.lockObjectForUserMapper)
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
                    lock (this.lockObjectForCategoryMapper)
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
                    lock (this.lockObjectForThingToDoMapper)
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
                    lock (this.lockObjectForAssignmentHistoryOfTaskMapper)
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
                    //this.UnitOfWork.Dispose();
                    //this.unitOfWork = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

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
