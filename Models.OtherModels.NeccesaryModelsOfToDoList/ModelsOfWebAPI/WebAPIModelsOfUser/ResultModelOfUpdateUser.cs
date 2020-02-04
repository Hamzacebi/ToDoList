using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser
{
    public sealed class ResultModelOfUpdateUser
    {
        public ResultModel ResultInformation { get; set; }
        public WebAPIModelOfUpdateUser UpdatedUserInformation { get; set; }
    }
}
