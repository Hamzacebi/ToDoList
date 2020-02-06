using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory
{
    public sealed class ResultModelOfInsertCategory
    {
        public ResultModel SuccessInformation { get; set; }
        public WebAPIModelOfInsertCategory CategoryInformation { get; set; }
    }
}
