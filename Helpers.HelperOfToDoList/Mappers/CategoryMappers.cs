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
    /// Categories tablosu icin Entity'nin DTO'ya, DTO'nun Entity'e donusmesini saglayan class
    /// </summary>
    public class CategoryMappers : IMapper<Categories, DTOOfCategory>
    {

        DTOOfCategory IMapper<Categories, DTOOfCategory>.MapToDTO(Categories entityObject)
        {
            if (entityObject != null)
            {
                return new DTOOfCategory
                {
                    Id = entityObject.Id,
                    Name = entityObject.Name,
                    Status = entityObject.Status,
                    UserId = entityObject.UserId,
                    UpdateDate = entityObject.UpdateDate,
                    DeleteDate = entityObject.DeleteDate,
                    Description = entityObject.Description,
                    CreationDate = entityObject.CreationDate
                };
            }
            return null;
        }

        List<DTOOfCategory> IMapper<Categories, DTOOfCategory>.MapToDTOList(IEnumerable<Categories> entityList)
        {
            List<DTOOfCategory> allDTOItems = new List<DTOOfCategory>();
            foreach (Categories category in entityList)
            {
                allDTOItems.Add(new DTOOfCategory
                {
                    Id = category.Id,
                    Name = category.Name,
                    Status = category.Status,
                    UserId = category.UserId,
                    UpdateDate = category.UpdateDate,
                    DeleteDate = category.DeleteDate,
                    Description = category.Description,
                    CreationDate = category.CreationDate
                });
            }
            return allDTOItems;
        }

        Categories IMapper<Categories, DTOOfCategory>.MapToEntity(DTOOfCategory dtoObject)
        {
            if (dtoObject != null)
            {
                return new Categories
                {
                    Id = dtoObject.Id,
                    Name = dtoObject.Name,
                    UserId = dtoObject.UserId,
                    Status = dtoObject.Status,
                    DeleteDate = dtoObject.DeleteDate,
                    UpdateDate = dtoObject.UpdateDate,
                    Description = dtoObject.Description,
                    CreationDate = dtoObject.CreationDate
                };
            }
            return null;
        }
    }
}
