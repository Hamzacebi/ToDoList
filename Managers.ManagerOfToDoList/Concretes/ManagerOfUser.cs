using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Helpers.HelperOfToDoList.Extensions;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfDataTransferObject;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser;
#endregion Global Usings

namespace Managers.ManagerOfToDoList.Concretes
{
    #region Internal Project Usings
    using Base;
    using Abstracts;
    #endregion Internal Project Usings

    public class ManagerOfUser : BaseManager, IManagerOfUser
    {
        bool IManagerOfUser.CreateNewUser(WebAPIModelOfInsertUser itemToAdd)
        {
            bool resultToReturn = default(bool);

            return ExtensionsOfFunction.TryCatch(
                    function: () =>
                    {
                        int numberOfRowsAffected = default(int);

                        this.UnitOfWork.BeginTransaction();

                        DTOOfUser userToCreate = this.UserMapper
                                                     .MapToDTO(entityObject: this.UnitOfWork
                                                                                 .RepositoryOfUser
                                                                                 .InsertRecord(recordToInsert: this.UserMapper
                                                                                                                   .MapToEntity(dtoObject: new DTOOfUser
                                                                                                                   {
                                                                                                                       Status = true,
                                                                                                                       Id = Guid.NewGuid(),
                                                                                                                       Name = itemToAdd.UserName,
                                                                                                                       UpdateDate = DateTime.Now,
                                                                                                                       CreationDate = DateTime.Now,
                                                                                                                       Email = itemToAdd.UserEmail,
                                                                                                                       Surname = itemToAdd.UserSurname,
                                                                                                                       Password = itemToAdd.UserPassword
                                                                                                                   })));
                        numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                        if (numberOfRowsAffected > 0)
                        {
                            this.UnitOfWork.CommitTransaction();
                            resultToReturn = true;
                        }
                        else
                        {
                            this.UnitOfWork.RollbackTransaction();
                            resultToReturn = false;
                        }
                        return resultToReturn;
                    },
                    catchAndDo: (Exception exception) =>
                    {
                        this.UnitOfWork.RollbackTransaction();
                        throw exception;
                    },
                    finallyDo: () =>
                    {
                        this.UnitOfWork.RepositoryOfUser.Dispose();
                        this.UnitOfWork.Dispose();
                    }
                );
        }
    }
}
