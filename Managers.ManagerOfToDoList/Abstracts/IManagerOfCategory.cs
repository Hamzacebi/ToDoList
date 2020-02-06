using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Models.OtherModels.NeccesaryModelsOfToDoList;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory;
#endregion Global Usings

namespace Managers.ManagerOfToDoList.Abstracts
{
    public interface IManagerOfCategory
    {
        ResultModelOfInsertCategory CreateNewCategory(WebAPIModelOfInsertCategory categoryToInsert);
    }
}
