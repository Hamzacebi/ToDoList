using System; 

#region Global Usings
using Models.OtherModels.NeccesaryModelsOfToDoList;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfUser;
#endregion Global Usings

namespace Managers.ManagerOfToDoList.Abstracts
{
    public interface IManagerOfUser
    {
        /// <summary>
        /// Yeni bir kullanici olusturmaya yarayan fonksiyon
        /// </summary>
        /// <param name="itemToAdd">Olusturulmak istenilen kullaniciya ait bilgiler</param>
        /// <returns></returns>
        ResultModel CreateNewUser(WebAPIModelOfInsertUser itemToAdd);

        /// <summary>
        /// Sistemde kayitli olan kullaniciyi guncellemeye yarayan fonksiyon
        /// </summary>
        /// <param name="userToUpdate">Mevcut kullaniciya ait yeni guncel bilgiler</param>
        /// <returns></returns>
        ResultModelOfUpdateUser UpdateExistingUser(WebAPIModelOfUpdateUser userToUpdate);

        /// <summary>
        /// Sistemde kayitli olan kullaniciyi ID bilgisine gore listeleyen fonksiyon
        /// </summary>
        /// <param name="userId">Elde edilmek istenilen kullaniciya ait ID bilgisi</param>
        /// <returns></returns>
        ResultModelOfSelectUser FetchUserById(Guid userId);
    }
}
