using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser
{
    public class WebAPIModelOfUpdateUser : BaseUserWebAPIModel
    {
        public Guid UserId { get; set; }
        public bool UserStatus { get; set; }
    }
}
