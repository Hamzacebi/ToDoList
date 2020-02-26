using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory
{
    public class ResultModelOfSelectCategory
    {
        public ResultModel SuccessInformation { get; set; }
        public List<WebAPIModelOfSelectCategory> Categories { get; set; }
    }
}
