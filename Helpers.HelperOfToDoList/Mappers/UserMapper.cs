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
    /// Users tablosu icin Entity'nin DTO'ya, DTO'nun Entity'e donusmesini saglayan class
    /// </summary>
    public class UserMapper : IMapper<Users, DTOOfUser>
    {
        DTOOfUser IMapper<Users, DTOOfUser>.MapToDTO(Users entityObject)
        {
            if (entityObject != null)
            {
                return new DTOOfUser
                {
                    Id = entityObject.Id,
                    Name = entityObject.Name,
                    Email = entityObject.Email,
                    Status = entityObject.Status,
                    Surname = entityObject.Surname,
                    Password = entityObject.Password,
                    UpdateDate = entityObject.UpdateDate,
                    CreationDate = entityObject.CreationDate
                };
            }
            return null;
        }

        List<DTOOfUser> IMapper<Users, DTOOfUser>.MapToDTOList(IEnumerable<Users> entityList)
        {
            List<DTOOfUser> allDTOItems = new List<DTOOfUser>();
            foreach (Users user in entityList)
            {
                allDTOItems.Add(new DTOOfUser
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Status = user.Status,
                    Surname = user.Surname,
                    Password = user.Password,
                    UpdateDate = user.UpdateDate,
                    CreationDate = user.CreationDate
                });
            }
            return allDTOItems;
        }

        Users IMapper<Users, DTOOfUser>.MapToEntity(DTOOfUser dtoObject)
        {
            if (dtoObject != null)
            {
                return new Users
                {
                    Id = dtoObject.Id,
                    Name = dtoObject.Name,
                    Email = dtoObject.Email,
                    Status = dtoObject.Status,
                    Surname = dtoObject.Surname,
                    Password = dtoObject.Password,
                    UpdateDate = dtoObject.UpdateDate,
                    CreationDate = dtoObject.CreationDate
                };
            }
            return null;
        }
    }
}
