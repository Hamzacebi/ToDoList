using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.CommonOfToDoList.Constants
{
    /// <summary>
    /// typeof(Users), typeof(Categories), typeof(ThingsToDo) ve typeof(AssignmentHistoryOfTasks) Entity'lerine ait alanlara ait Validation Error mesajlarini iceren class
    /// </summary>
    public class ConstantsOfValidation
    {
        #region Users

        public const string UserIdCannotBeEmpty = "Kullanıcı ID bilgisi boş geçilemez!";
        public const string UserNameCannotBeEmpty = "Kullanici Adi alani bos gecilemez!";
        public const string UserEmailCannotBeEmpty = "Kullanici Email alani bos gecilemez!";
        public const string UserSurnameCannotBeEmpty = "Kullanici Soyadi alani bos gecilemez!";
        public const string UserPasswordCannotBeEmpty = "Kullanici Sifre alani bos gecilemez!";

        #endregion Users

        #region Categories

        #endregion Categories

        #region ThingsToDo

        #endregion ThingsToDo

        #region AssignmentHistoryOfTasks

        #endregion AssignmentHistoryOfTasks
    }
}
