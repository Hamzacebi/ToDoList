#region Global Usings
using Commons.CommonOfToDoList.Constants;
using System.ComponentModel.DataAnnotations;
#endregion Global Usings

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser
{
    public class BaseUserWebAPIModel
    {
        [Required(ErrorMessage = ConstantsOfValidation.UserNameCannotBeEmpty)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ConstantsOfValidation.UserEmailCannotBeEmpty)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = ConstantsOfValidation.UserSurnameCannotBeEmpty)]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = ConstantsOfValidation.UserPasswordCannotBeEmpty)]
        public string UserPassword { get; set; }
    }
}
