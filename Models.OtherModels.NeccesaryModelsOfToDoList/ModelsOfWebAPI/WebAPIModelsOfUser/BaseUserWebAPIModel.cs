#region Global Usings
using Commons.CommonOfToDoList.Constants;
using System.ComponentModel.DataAnnotations;
#endregion Global Usings

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser
{
    public class BaseUserWebAPIModel
    {
        [Required(ErrorMessage = ConstantsOfValidations.UserNameCannotBeEmpty)]
        public string UserName { get; set; }

        [Required(ErrorMessage = ConstantsOfValidations.UserSurnameCannotBeEmpty)]
        public string UserSurname { get; set; }

        [Required(ErrorMessage = ConstantsOfValidations.UserPasswordCannotBeEmpty)]
        public string UserPassword { get; set; }
    }
}
