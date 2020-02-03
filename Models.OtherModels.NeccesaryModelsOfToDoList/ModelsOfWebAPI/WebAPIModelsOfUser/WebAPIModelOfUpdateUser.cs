using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

#region Global Usings
using Commons.CommonOfToDoList.Constants;
#endregion Global Usings

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser
{
    public class WebAPIModelOfUpdateUser : BaseUserWebAPIModel
    {
        [Required(ErrorMessage = ConstantsOfValidation.UserIdCannotBeEmpty)]
        public Guid UserId { get; set; }
        public bool UserStatus { get; set; }
    }
}
