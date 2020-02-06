using System;

#region Global Usings
using Commons.CommonOfToDoList.Constants;
using Helpers.HelperOfToDoList.Extensions;
using Models.OtherModels.NeccesaryModelsOfToDoList;
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

        private readonly IManagerOfUser userManager;

        public ManagerOfCategory()
        {
            this.userManager = new ManagerOfUser();
        }

        ResultModelOfInsertCategory IManagerOfCategory.CreateNewCategory(WebAPIModelOfInsertCategory categoryToInsert)
        {
            ResultModel resultToReturn = default(ResultModel);
            int numberOfRowsAffected = default(int);
            try
            {
                var isThereAnyUser = this.userManager
                                          .FecthUserById(userId: categoryToInsert.CategoryOwnerUserId);
                if (isThereAnyUser.SuccessInformation.IsSuccess)
                {

                }
                else
                {

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
    }
}
