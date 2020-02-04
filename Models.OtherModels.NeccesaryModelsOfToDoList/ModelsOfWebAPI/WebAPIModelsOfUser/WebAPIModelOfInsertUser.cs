#region Global Usings
using Commons.CommonOfToDoList.Constants;
using System.ComponentModel.DataAnnotations;
#endregion Global Usings

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser
{

    public sealed class WebAPIModelOfInsertUser : BaseUserWebAPIModel
    {
        [Required(ErrorMessage = ConstantsOfValidations.UserEmailCannotBeEmpty)]
        public string UserEmail { get; set; }
    }
}
