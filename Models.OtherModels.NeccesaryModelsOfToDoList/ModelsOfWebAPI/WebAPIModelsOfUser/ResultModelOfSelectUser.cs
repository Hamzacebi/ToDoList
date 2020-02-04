using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser
{
    public sealed class ResultModelOfSelectUser
    {
        public ResultModel SuccessInformation { get; set; }
        public WebAPIModelOfSelectUser UserInformation { get; set; }
    }
}
