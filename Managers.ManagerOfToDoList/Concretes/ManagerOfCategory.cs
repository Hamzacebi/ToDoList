using System;

#region Global Usings
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Commons.CommonOfToDoList.Constants;
using Helpers.HelperOfToDoList.Extensions;
using Models.OtherModels.NeccesaryModelsOfToDoList;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfDataTransferObject;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory;
#endregion Global Usings

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

        private readonly IManagerOfUser UserManager;

        public ManagerOfCategory()
        {
            this.UserManager = new ManagerOfUser();
        }

        ResultModelOfInsertCategory IManagerOfCategory.CreateNewCategory(WebAPIModelOfInsertCategory categoryToInsert)
        {
            ResultModel resultToReturn = default(ResultModel);
            int numberOfRowsAffected = default(int);
            try
            {
                var isThereAnyUser = this.UserManager
                                         .FecthUserById(userId: categoryToInsert.CategoryOwnerUserId);
                if (isThereAnyUser.SuccessInformation.IsSuccess)
                {
                    this.UnitOfWork
                        .BeginTransaction();

                    DTOOfCategory insertedCategory = this.CategoryMapper
                                                         .MapToDTO(entityObject: this.UnitOfWork
                                                                                     .RepositoryOfCategory
                                                                                     .InsertRecord(recordToInsert: this.CategoryMapper
                                                                                                                       .MapToEntity(dtoObject: new DTOOfCategory()
                                                                                                                       {
                                                                                                                           Status = true,
                                                                                                                           CreationDate = DateTime.Now,
                                                                                                                           Name = categoryToInsert.CategoryName,
                                                                                                                           UserId = categoryToInsert.CategoryOwnerUserId,
                                                                                                                           Description = categoryToInsert.CategoryDescription
                                                                                                                       })));
                    numberOfRowsAffected = this.UnitOfWork
                                               .SaveChanges();
                    if (numberOfRowsAffected > 0)
                    {
                        this.UnitOfWork
                            .CommitTransaction();
                        resultToReturn = ResultModel.SuccessfulResult(successfulResultMessage: ConstantsOfResults.CreateNewCategorySuccessfulMessage);
                    }
                    else
                    {
                        this.UnitOfWork
                            .RollbackTransaction();
                        resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.CreateNewCategoryUnsuccessfulMessage);
                    }
                }
                else
                {
                    resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfResults.NotFoundUserMessage);
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
                    else
                    {
                        resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: ConstantsOfErrors.CreateNewCategoryTransactionErrorMessage);
                    }
                }
            }
            catch (Exception exception)
            {
                this.UnitOfWork
                    .RollbackTransaction();
                resultToReturn = ResultModel.UnsuccessfulResult(unsuccessfulResultMessage: $"{ConstantsOfErrors.CreateNewCategoryTransactionErrorMessage} HATA: ${exception.Message}");
            }
            finally
            {
                this.UnitOfWork
                    .Dispose();
            }
            return new ResultModelOfInsertCategory()
            {
                SuccessInformation = resultToReturn,
                CategoryInformation = categoryToInsert
            };
        }

        //ToDo: CategoryName guncellemesinde sistemde kayitli olan isimle guncellemeyi dene bakalim hata verecek mi?
    }
}
