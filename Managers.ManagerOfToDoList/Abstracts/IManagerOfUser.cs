using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser;
#endregion Global Usings

namespace Managers.ManagerOfToDoList.Abstracts
{
    public interface IManagerOfUser
    {
        //ToDo : geri donus tipi resultModel olarak degistirilecek
        bool CreateNewUser(WebAPIModelOfInsertUser itemToAdd);
    }
}
