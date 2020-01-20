using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfDataTransferObject;
#endregion Global Usings

namespace Helpers.HelperOfToDoList.Mappers
{
    #region Internal Project Using
    using Base;
    #endregion Internal Project Using

    /// <summary>
    /// AssignmentHistoryOfTasks tablosu icin Entity'nin DTO'ya, DTO'nun Entity'e donusmesini saglayan class
    /// </summary>
    public class AssignmentHistoryOfTaskMapper : IMapper<AssignmentHistoryOfTasks, DTOOfAssignmentHistoryOfTask>
    {
        DTOOfAssignmentHistoryOfTask IMapper<AssignmentHistoryOfTasks, DTOOfAssignmentHistoryOfTask>.MapToDTO(AssignmentHistoryOfTasks entityObject)
        {
            if (entityObject != null)
            {
                return new DTOOfAssignmentHistoryOfTask
                {
                    Id = entityObject.Id,
                    ToDoId = entityObject.ToDoId,
                    UserId = entityObject.UserId,
                    ProcessType = entityObject.ProcessType, 
                    ReleaseDate = entityObject.ReleaseDate,
                    DateToAccepted = entityObject.DateToAccepted
                };
            }
            return null;
        }

        List<DTOOfAssignmentHistoryOfTask> IMapper<AssignmentHistoryOfTasks, DTOOfAssignmentHistoryOfTask>.MapToDTOList(IEnumerable<AssignmentHistoryOfTasks> entityList)
        {
            List<DTOOfAssignmentHistoryOfTask> allDTOItems = new List<DTOOfAssignmentHistoryOfTask>();
            foreach (AssignmentHistoryOfTasks item in entityList)
            {
                allDTOItems.Add(new DTOOfAssignmentHistoryOfTask
                {
                    Id = item.Id,
                    UserId = item.UserId,
                    ToDoId = item.ToDoId,
                    ReleaseDate = item.ReleaseDate, 
                    ProcessType = item.ProcessType,
                    DateToAccepted = item.DateToAccepted
                });
            }
            return allDTOItems;
        }

        AssignmentHistoryOfTasks IMapper<AssignmentHistoryOfTasks, DTOOfAssignmentHistoryOfTask>.MapToEntity(DTOOfAssignmentHistoryOfTask dtoObject)
        {
            if (dtoObject != null)
            {
                return new AssignmentHistoryOfTasks
                {
                    Id = dtoObject.Id,
                    UserId = dtoObject.UserId,
                    ToDoId = dtoObject.ToDoId,
                    ReleaseDate = dtoObject.ReleaseDate,
                    ProcessType = dtoObject.ProcessType,
                    DateToAccepted = dtoObject.DateToAccepted
                };
            }
            return null;
        }
    }
}
