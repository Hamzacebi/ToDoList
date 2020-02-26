using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory
{
    public class ResultModelOfUpdateCategory
    {
        public ResultModel SuccessInformation { get; set; }
        public WebAPIModelOfUpdateCategory CategoryInformation { get; set; }
    }
}
