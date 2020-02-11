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

        //private readonly object lockObjectForUnitOfWork;
        //private readonly object lockObjectForUserMapper;
        //private readonly object lockObjectForCategoryMapper;
        //private readonly object lockObjectForThingToDoMapper;
        //private readonly object lockObjectForAssignmentHistoryOfTaskMapper;

        #endregion Global Properties

        #region Constructor(s)

        protected BaseManager()
        {
            //this.lockObjectForUnitOfWork =
            //this.lockObjectForUserMapper =
            //this.lockObjectForCategoryMapper =
            //this.lockObjectForThingToDoMapper =
            //this.lockObjectForAssignmentHistoryOfTaskMapper = new object();
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
                return UtilityTools.CreateGenericSingletonInstance<IMapper<Users, DTOOfUser>>(resultToReturnClass: typeof(UserMapper));
            }
        }

        protected IMapper<Categories, DTOOfCategory> CategoryMapper
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IMapper<Categories, DTOOfCategory>>(resultToReturnClass: typeof(CategoryMapper));
            }
        }

        protected IMapper<ThingsToDo, DTOOfThingToDo> ThingToDoMapper
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IMapper<ThingsToDo, DTOOfThingToDo>>(resultToReturnClass: typeof(ThingToDoMapper));
            }
        }

        protected IMapper<AssignmentHistoryOfTasks, DTOOfAssignmentHistoryOfTask> AssignmentHistoryOfTaskMapper
        {
            get
            {
                return UtilityTools.CreateGenericSingletonInstance<IMapper<AssignmentHistoryOfTasks,
                                                                           DTOOfAssignmentHistoryOfTask>>(resultToReturnClass: typeof(AssignmentHistoryOfTaskMapper));
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
