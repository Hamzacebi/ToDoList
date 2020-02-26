using System;
using System.Collections.Generic;
using System.Text;

#region Added Project References
using Models.OtherModels.NeccesaryModelsOfToDoList;
using Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory;
#endregion Added Project References

namespace Managers.ManagerOfToDoList.Abstracts
{
    public interface IManagerOfCategory
    {
        /// <summary>
        /// Kullanicilarin kendilerine ait yapilacak isler icin kategoriler olusturmasini saglayan fonksiyon
        /// </summary>
        /// <param name="categoryToInsert">Yapilacak isler icin olusturulmak istenilen Kategori'ye ait bilgiler</param>
        /// <returns></returns>
        ResultModelOfInsertCategory CreateNewCategory(WebAPIModelOfInsertCategory categoryToInsert);

        /// <summary>
        /// Olusturulmus olan Kategori'nin bilgilerini guncellemeye yarayan fonksiyon
        /// </summary>
        /// <param name="categoryToUpdate">Bilgileri degistirilmek istenilen Kategoriye ait guncel bilgiler</param>
        /// <returns></returns>
        ResultModelOfUpdateCategory UpdateExistingCategory(WebAPIModelOfUpdateCategory categoryToUpdate);

        /// <summary>
        /// Kullaniciya ait olan tum Kategorileri listelemeye yarayan fonksiyon
        /// </summary>
        /// <param name="userId">Kategori listesini elde etmek isteyen kullaniciya ait ID bilgisi</param>
        /// <returns></returns>
        ResultModelOfSelectCategory FetchAllCategoryByUserId(Guid userId);
    }
}
