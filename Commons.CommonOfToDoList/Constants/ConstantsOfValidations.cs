using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.CommonOfToDoList.Constants
{
    /// <summary>
    /// typeof(Users), typeof(Categories), typeof(ThingsToDo) ve typeof(AssignmentHistoryOfTasks) Entity'lerine ait alanlara ait Validation Error mesajlarini iceren class
    /// </summary>
    public class ConstantsOfValidations
    {
        #region Users

        public const string UserIdCannotBeEmpty = "Kullanıcı ID bilgisi boş geçilemez!";
        public const string UserNameCannotBeEmpty = "Kullanici Adi alani bos gecilemez!";
        public const string UserEmailCannotBeEmpty = "Kullanici Email alani bos gecilemez!";
        public const string UserSurnameCannotBeEmpty = "Kullanici Soyadi alani bos gecilemez!";
        public const string UserPasswordCannotBeEmpty = "Kullanici Sifre alani bos gecilemez!";

        #endregion Users

        #region Categories
        public const string CategoryIdCannotBeEmpty = "Kategori ID boş geçilemez!";
        public const string CategoryNameCannotBeEmpty = "Kategori Adı alanı boş geçilemez!";
        public const string CategoryDescriptionCannotBeEmpty = "Kategori Açıklaması alanı boş geçilemez!";
        public const string CategoryStatusCannotBeEmpty = "Kategori Aktiflik - Pasiflik bilgisi boş geçilemez!";
        public const string UserIdOfCategoryOwnerCannotBeEmpty = "Kategoriyi ekleyen Kullanıcı ID bilgisi boş geçilemez!";
        #endregion Categories

        #region ThingsToDo

        #endregion ThingsToDo

        #region AssignmentHistoryOfTasks

        #endregion AssignmentHistoryOfTasks
    }
}
