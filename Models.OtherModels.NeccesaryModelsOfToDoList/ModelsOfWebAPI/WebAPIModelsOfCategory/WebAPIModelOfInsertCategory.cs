using System;
using System.ComponentModel.DataAnnotations;

#region Global Usings
using Commons.CommonOfToDoList.Constants;
#endregion Global Usings

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory
{
    public sealed class WebAPIModelOfInsertCategory : BaseWebAPIModelOfCategory
    {
        [Required(ErrorMessage = ConstantsOfValidations.CategoryOwnerUserIdCannotBeEmpty)]
        public Guid CategoryOwnerUserId { get; set; }
    }
}
