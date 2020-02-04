using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.CommonOfToDoList.Constants
{
    /// <summary>
    /// Butun Successful ve Unsuccessful mesajlarini iceren class
    /// </summary>
    public class ConstantsOfResults
    {
        #region Users
        public const string CreateNewUserSuccessfulMessage = "Yeni kullanıcı oluşturma işlemi başarılı!";
        public const string CreateNewUserUnsuccessfulMessage = "Yeni kullanıcı oluşturma işlemi başarısız. Lütfen tekrar deneyin!";

        public const string NotFoundUserMessage = "Kullanıcı bulunamadı. Lütfen tekrar deneyin!";

        public const string UpdateUserSuccessfulMessage = "Kullanıcı güncelleme işlemi başarılı!";
        public const string UpdateUserUnsuccessfulMessage = "Kullanıcı güncelleme işlemi başarısız. Lütfen tekrar deneyiniz!";

        public const string ThisEmailAlreadyExists = "Bu E-Mail adresi zaten kullanılıyor. Lütfen başka bir E-Mail adresi deneyin!";
        #endregion Users

        #region Categories

        #endregion Categories

        #region ThingsToDo

        #endregion ThingsToDo

        #region AssignmentHistoryOfTasks

        #endregion AssignmentHistoryOfTasks
    }
}
