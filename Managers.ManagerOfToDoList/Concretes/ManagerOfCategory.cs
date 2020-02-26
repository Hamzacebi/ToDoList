using System;

#region Added Project References and Custom Usings
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Commons.CommonOfToDoList.Constants;
using Models.OtherModels.NeccesaryModelsOfToDoList;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfDataTransferObject;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory;
#endregion Added Project References and Custom Usings

namespace Managers.ManagerOfToDoList.Concretes
{
    #region Internal Project Usings
    using Base;
    using Abstracts;
    #endregion Internal Project Usings

    /// <summary>
    /// typeof(Categories) tablosuna ait BusinessManager classi 
    /// </summary>
    public class ManagerOfCategory : BaseManager, IManagerOfCategory
    {

        #region Global Private Properties
        private readonly IManagerOfUser UserManager;
        #endregion Global Private Properties

        #region Constructor(s)
        public ManagerOfCategory()
        {
            this.UserManager = new ManagerOfUser();
        }
        #endregion Constructor(s)

        #region Public Functions

        ResultModelOfInsertCategory IManagerOfCategory.CreateNewCategory(WebAPIModelOfInsertCategory categoryToInsert)
        {
            ResultModel resultToReturn = default(ResultModel);
            int numberOfRowsAffected = default(int);
            try
            {
                var isThereAnyUser = this.UserManager.FetchUserById(userId: categoryToInsert.UserIdOfCategoryOwner);

                if (isThereAnyUser.SuccessInformation.IsSuccess && isThereAnyUser.UserInformation != null)
                {
                    this.UnitOfWork.BeginTransaction();

                    DTOOfCategory insertedCategory = this.CategoryMapper
                                                         .MapToDTO(entityObject: this.UnitOfWork
                                                                                     .RepositoryOfCategory
                                                                                     .InsertRecord(recordToInsert:
                                                                                                   this.CategoryMapper
                                                                                                   .MapToEntity(dtoObject: new DTOOfCategory()
                                                                                                   {
                                                                                                       Status = true,
                                                                                                       CreationDate = DateTime.Now,
                                                                                                       Name = categoryToInsert.CategoryName,
                                                                                                       UserId = categoryToInsert.UserIdOfCategoryOwner,
                                                                                                       Description = categoryToInsert.CategoryDescription
                                                                                                   })));
                    numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                    if (numberOfRowsAffected > 0)
                    {
                        this.UnitOfWork.CommitTransaction();
                        resultToReturn = ResultModel.SuccessfulResult(successfulResultMessage: ConstantsOfResults.CreateNewCategorySuccessfulMessage);
                    }
                    else
                    {
                        this.UnitOfWork.RollbackTransaction();
                        resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.CreateNewCategoryUnsuccessfulMessage);
                    }
                }
                else
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.UserNotFoundMessage);
                }
            }
            catch (DbUpdateException dbUpdateException)
            {
                this.UnitOfWork
                    .RollbackTransaction();

                if (dbUpdateException.InnerException != null)
                {
                    if (dbUpdateException.InnerException is SqlException sqlException)
                    {
                        // CategoryName degeri Unique oldugu icin sistemde kayitli olan isimlerden bir tanesi tekrar girilirse Unique Exception hatasi 
                        // almak icin bu blok yazildi. 2627 UniqueKey i ifade etmektedir.
                        if (sqlException.Number == 2627)
                        {
                            resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfErrors.CategoryAlreadyExistsTransactionErrorMessage);
                        }
                    }
                }
                else
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.UpdateExistingCategoryTransactionErrorMessage} HATA : {dbUpdateException.Message}");
                }
            }
            catch (Exception exception)
            {
                this.UnitOfWork.RollbackTransaction();
                resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.CreateNewCategoryTransactionErrorMessage} HATA: ${exception.Message}");
            }
            finally
            {
                this.UnitOfWork.Dispose();
            }
            return new ResultModelOfInsertCategory()
            {
                SuccessInformation = resultToReturn,
                CategoryInformation = categoryToInsert
            };
        }


        ResultModelOfUpdateCategory IManagerOfCategory.UpdateExistingCategory(WebAPIModelOfUpdateCategory categoryToUpdate)
        {
            ResultModel resultToReturn = default(ResultModel);
            int numberOfRowsAffected = default(int);
            try
            {
                var isThereUser = this.UserManager
                                      .FetchUserById(userId: categoryToUpdate.UserIdOfCategoryOwner);
                if (!isThereUser.SuccessInformation.IsSuccess && isThereUser.UserInformation == null)
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.UserNotFoundMessage);
                }
                else
                {
                    var isThereCategory = this.CategoryMapper.MapToDTO(entityObject: this.UnitOfWork.RepositoryOfCategory
                                                                                                    .FetchAnyRecord(id: categoryToUpdate.CategoryId));
                    if (isThereCategory == null)
                    {
                        resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.CategoryNotFoundMessage);
                    }
                    else
                    {
                        this.UnitOfWork.BeginTransaction();

                        DTOOfCategory updatedCategory = this.CategoryMapper
                                                            .MapToDTO(entityObject: this.UnitOfWork
                                                                                        .RepositoryOfCategory
                                                                                        .UpdateRecord(recordToUpdate:
                                                                                                      this.CategoryMapper
                                                                                                          .MapToEntity(dtoObject: new DTOOfCategory()
                                                                                                          {
                                                                                                              Id = isThereCategory.Id,
                                                                                                              UpdateDate = DateTime.Now,
                                                                                                              Name = categoryToUpdate.CategoryName,
                                                                                                              DeleteDate = isThereCategory.DeleteDate,
                                                                                                              Status = categoryToUpdate.CategoryStatus,
                                                                                                              CreationDate = isThereCategory.CreationDate,
                                                                                                              UserId = categoryToUpdate.UserIdOfCategoryOwner,
                                                                                                              Description = categoryToUpdate.CategoryDescription
                                                                                                          })));
                        numberOfRowsAffected = this.UnitOfWork.SaveChanges();
                        if (numberOfRowsAffected > 0)
                        {
                            this.UnitOfWork.CommitTransaction();
                            resultToReturn = ResultModel.SuccessfulResult(successfulResultMessage: ConstantsOfResults.CreateNewCategorySuccessfulMessage);
                        }
                        else
                        {
                            this.UnitOfWork.RollbackTransaction();
                            resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.CreateNewCategoryUnsuccessfulMessage);
                        }
                    }
                }
            }
            catch (DbUpdateException dbUpdateException)
            {
                this.UnitOfWork.RollbackTransaction();
                if (dbUpdateException.InnerException != null)
                {
                    if (dbUpdateException.InnerException is SqlException sqlException)
                    {
                        // CategoryName degeri Unique oldugu icin sistemde kayitli olan isimlerden bir tanesi tekrar girilirse Unique Exception hatasi 
                        // almak icin bu blok yazildi. 2627 UniqueKey i ifade etmektedir.
                        if (sqlException.Number == 2627)
                        {
                            resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfErrors.CategoryAlreadyExistsTransactionErrorMessage);
                        }
                    }
                }
                else
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.UpdateExistingCategoryTransactionErrorMessage} HATA : {dbUpdateException.Message}");
                }
            }
            catch (Exception exception)
            {
                this.UnitOfWork.RollbackTransaction();
                resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.UpdateExistingCategoryTransactionErrorMessage} HATA : {exception.Message}");
            }
            finally
            {
                this.UnitOfWork.Dispose();
            }
            return new ResultModelOfUpdateCategory()
            {
                SuccessInformation = resultToReturn
            };
        }


        ResultModelOfSelectCategory IManagerOfCategory.FetchAllCategoryByUserId(Guid userId)
        {
            ResultModel resultToReturn = default(ResultModel);
            try
            {
                var isThereUser = this.UserManager.FetchUserById(userId: userId);
                if (!isThereUser.SuccessInformation.IsSuccess && isThereUser.UserInformation != null)
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.UserNotFoundMessage);
                }
                else
                {
                    var allCategoriesOwnedByTheUser = this.CategoryMapper.MapToDTOList(entityList: this.UnitOfWork.RepositoryOfCategory
                                                                                                                  .FetchAllRecords(whereConditions:
                                                                                                                                   x => x.UserId == userId));
                }
            }
            catch (Exception exception)
            {
                resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.SelectAllCategoriesTransactionErrorMessage} HATA : {exception.Message}");
            }
            return new ResultModelOfSelectCategory()
            {
                SuccessInformation = resultToReturn
            };
        }

        #endregion Public Functions
    }
}
