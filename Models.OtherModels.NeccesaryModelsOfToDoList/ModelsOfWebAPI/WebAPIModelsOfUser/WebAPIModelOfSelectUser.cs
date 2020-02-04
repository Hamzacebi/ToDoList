using System;
#region Global Usings
using Commons.CommonOfToDoList.Constants;
using System.ComponentModel.DataAnnotations;
#endregion Global Usings
namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser
{
    public sealed class WebAPIModelOfSelectUser : BaseUserWebAPIModel
    {
        public Guid UserId { get; set; }

        [Required(ErrorMessage = ConstantsOfValidations.UserEmailCannotBeEmpty)]
        public string UserEmail { get; set; }

        public bool UserStatus { get; set; }
    }
}
