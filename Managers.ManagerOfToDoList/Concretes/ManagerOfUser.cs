using System;
using System.Linq.Expressions;
#region Global Usings
using Commons.CommonOfToDoList.Constants;
using Helpers.HelperOfToDoList.Extensions;
using Models.OtherModels.NeccesaryModelsOfToDoList;
using Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfDataTransferObject;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser;
#endregion Global Usings

namespace Managers.ManagerOfToDoList.Concretes
{
    #region Internal Project Usings
    using Base;
    using Abstracts;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    #endregion Internal Project Usings

    /// <summary>
    /// typeof(Users) tablosuna ait BusinessManager classi 
    /// </summary>
    public class ManagerOfUser : BaseManager, IManagerOfUser
    {
        ResultModel IManagerOfUser.CreateNewUser(WebAPIModelOfInsertUser itemToAdd)
        {
            ResultModel returnToResult = default(ResultModel);
            try
            {
                int numberOfRowAffected = default(int);
                itemToAdd.UserEmail = itemToAdd.UserEmail.ConvertTurkishCharactersToEnglishCharacters();

                if (!this.CheckIfExistsEmail(mailToCheck: itemToAdd.UserEmail))
                {
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
                    numberOfRowAffected = this.UnitOfWork.SaveChanges();
                    if (numberOfRowAffected > 0)
                    {
                        this.UnitOfWork.CommitTransaction();
                        returnToResult = ResultModel.SuccessfulResult(successfulResultMessage: ConstantsOfResults.CreateNewUserSuccessfulMessage);
                    }
                    else
                    {
                        this.UnitOfWork.RollbackTransaction();
                        returnToResult = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.CreateNewUserUnsuccessfulMessage);
                    }
                }
                else
                {
                    returnToResult = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.ThisEmailAlreadyExists);
                }
            }
            catch (Exception exception)
            {
                this.UnitOfWork.RollbackTransaction();
                returnToResult = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.CreateNewUserTransactionErrorMessage} HATA: ${exception.Message}");
            }
            finally
            {
                this.UnitOfWork.Dispose();
            }
            return returnToResult;
        }

        ResultModelOfUpdateUser IManagerOfUser.UpdateExistingUser(WebAPIModelOfUpdateUser userToUpdate)
        {
            ResultModel successInformation = default(ResultModel);
            try
            {
                //Kullanici, sisteme kayit olurken kullandigi E-Mail adresini degistiremesin diye E-Mail kontrolu yapilmamistir.
                DTOOfUser theUser = this.FetchAnyUserByWhereConditions(x => x.Id == userToUpdate.UserId);
                if (theUser != null)
                {
                    int numberOfRowsAffected = default(int);

                    this.UnitOfWork.BeginTransaction();

                    DTOOfUser updatedUser = this.UserMapper
                                                .MapToDTO(entityObject: this.UnitOfWork
                                                                            .RepositoryOfUser
                                                                            .UpdateRecord(recordToUpdate: this.UserMapper
                                                                                                              .MapToEntity(dtoObject: new DTOOfUser()
                                                                                                              {
                                                                                                                  Id = theUser.Id,
                                                                                                                  Email = theUser.Email,
                                                                                                                  UpdateDate = DateTime.Now,
                                                                                                                  Name = userToUpdate.UserName,
                                                                                                                  Status = userToUpdate.UserStatus,
                                                                                                                  Surname = userToUpdate.UserSurname,
                                                                                                                  CreationDate = theUser.CreationDate,
                                                                                                                  Password = userToUpdate.UserPassword
                                                                                                              })));
                    numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                    if (numberOfRowsAffected > 0)
                    {
                        this.UnitOfWork.CommitTransaction();
                        successInformation = ResultModel.SuccessfulResult(successfulResultMessage: ConstantsOfResults.UpdateUserSuccessfulMessage);
                    }
                    else
                    {
                        this.UnitOfWork.RollbackTransaction();
                        successInformation = ResultModel.SuccessfulResult(successfulResultMessage: ConstantsOfResults.UpdateUserUnsuccessfulMessage);
                    }
                }
                else
                {
                    successInformation = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.NotFoundUserMessage);
                }
            }
            catch (Exception exception)
            {
                this.UnitOfWork.RollbackTransaction();
                successInformation = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.UpdateExistingUserTransactionErrorMessage} HATA: ${exception.Message}"); ;
            }
            finally
            {
                this.UnitOfWork.Dispose();
            }
            return new ResultModelOfUpdateUser()
            {
                UpdatedUserInformation = userToUpdate,
                ResultInformation = successInformation
            };
        }


        ResultModelOfSelectUser IManagerOfUser.FecthUserById(Guid userId)
        {
            ResultModel resultToReturn = default(ResultModel);
            WebAPIModelOfSelectUser resultToReturnOfUserInformation = default(WebAPIModelOfSelectUser);
            try
            {
                DTOOfUser getUserById = this.FetchAnyUserByWhereConditions(whereConditions: x => x.Id == userId);
                if (getUserById != null)
                {
                    resultToReturnOfUserInformation = new WebAPIModelOfSelectUser()
                    {
                        UserEmail = getUserById.Email,
                        UserId = getUserById.Id,
                        UserName = getUserById.Name,
                        UserPassword = getUserById.Password,
                        UserStatus = getUserById.Status,
                        UserSurname = getUserById.Surname
                    };
                    resultToReturn = ResultModel.SuccessfulResult(successfulResultMessage: ConstantsOfResults.UserIsFound);
                }
                else
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.NotFoundUserMessage);
                }
            }
            catch (Exception exception)
            {
                this.UnitOfWork.RollbackTransaction();
                resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.FetchUserTransactionErrorMessage} HATA : {exception.Message}");
            }
            finally
            {
                this.UnitOfWork.Dispose();
            }
            return new ResultModelOfSelectUser()
            {
                SuccessInformation = resultToReturn
            };
        }


        #region Private Function(s)

        /// <summary>
        /// Yeni kayit icin girilmek istenilen E-Mail degerinin daha onceden kullanilip kullanilmadigini kontrol etmeye yarayan fonksiyon
        /// </summary>
        /// <param name="mailToCheck">Kontrol edilmek istenilen E-Mail degeri</param>
        /// <returns>Eger E-Mail degeri kullanilmamis ise false, kullanilmis ise true olarak deger dondurur</returns>
        bool CheckIfExistsEmail(String mailToCheck)
        {
            bool resultToReturn = default(bool);

            mailToCheck = mailToCheck.ConvertTurkishCharactersToEnglishCharacters();

            ExtensionsOfAction.TryCatch(
                    action: () =>
                    {
                        DTOOfUser getUserByEmail = this.FetchAnyUserByWhereConditions(whereConditions: x => x.Email == mailToCheck);
                        resultToReturn = getUserByEmail == null ? false : true;
                    }
                );
            return resultToReturn;
        }

        /// <summary>
        /// Kendisine verilen sart / sartlara gore typeof(Users) tablosundan istenilen tek satir veriyi cekmeye yarayan fonksiyon
        /// </summary>
        /// <param name="whereConditions">Istenilen veriyi elde etmek icin gerekli sart / sartlar </param>
        /// <returns></returns>
        private DTOOfUser FetchAnyUserByWhereConditions(Expression<Func<Users, bool>> whereConditions)
        {
            return this.UserMapper
                       .MapToDTO(entityObject: this.UnitOfWork
                                                   .RepositoryOfUser
                                                   .FetchAnyRecord(whereConditions: whereConditions));
        }
        #endregion Private Function(s)
    }
}
