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
    /// ThingsToDo tablosu icin Entity'nin DTO'ya, DTO'nun Entity'e donusmesini saglayan class
    /// </summary>
    public class ThingToDoMapper : IMapper<ThingsToDo, DTOOfThingToDo>
    {
        DTOOfThingToDo IMapper<ThingsToDo, DTOOfThingToDo>.MapToDTO(ThingsToDo entityObject)
        {
            if (entityObject != null)
            {
                return new DTOOfThingToDo
                {
                    Id = entityObject.Id,
                    Status = entityObject.Status,
                    Subject = entityObject.Subject,
                    UpdateDate = entityObject.UpdateDate,
                    CategoryId = entityObject.CategoryId,
                    DeleteDate = entityObject.DeleteDate,
                    Description = entityObject.Description,
                    IsCompleted = entityObject.IsCompleted,
                    PriorityType = entityObject.PriorityType,
                    CreationDate = entityObject.CreationDate
                };
            }
            return null;
        }

        List<DTOOfThingToDo> IMapper<ThingsToDo, DTOOfThingToDo>.MapToDTOList(IEnumerable<ThingsToDo> entityList)
        {
            List<DTOOfThingToDo> allDTOItems = new List<DTOOfThingToDo>();
            foreach (ThingsToDo thingToDo in entityList)
            {
                allDTOItems.Add(new DTOOfThingToDo
                {
                    Id = thingToDo.Id,
                    Status = thingToDo.Status,
                    Subject = thingToDo.Subject,
                    UpdateDate = thingToDo.UpdateDate,
                    CategoryId = thingToDo.CategoryId,
                    DeleteDate = thingToDo.DeleteDate,
                    IsCompleted = thingToDo.IsCompleted,
                    Description = thingToDo.Description,
                    PriorityType = thingToDo.PriorityType,
                    CreationDate = thingToDo.CreationDate
                });
            }
            return allDTOItems;
        }

        ThingsToDo IMapper<ThingsToDo, DTOOfThingToDo>.MapToEntity(DTOOfThingToDo dtoObject)
        {
            if (dtoObject != null)
            {
                return new ThingsToDo
                {
                    Id = dtoObject.Id,
                    Status = dtoObject.Status,
                    Subject = dtoObject.Subject,
                    CategoryId = dtoObject.CategoryId,
                    DeleteDate = dtoObject.DeleteDate,
                    UpdateDate = dtoObject.UpdateDate,
                    Description = dtoObject.Description,
                    IsCompleted = dtoObject.IsCompleted,
                    PriorityType = dtoObject.PriorityType,
                    CreationDate = dtoObject.CreationDate
                };
            }
            return null;
        }
    }
}
