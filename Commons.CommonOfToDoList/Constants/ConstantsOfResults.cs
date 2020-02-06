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

        #region Base Result Messages
        private const string baseSuccessfulResultMessage = " işlemi başarılı!";
        private const string baseUnsuccessfulResultMessage = " işlemi başarısız. Lütfen tekrar deneyin!";
        #endregion Base Result Messages

        #region Users Result Messages
        public const string UserIsFound = "Kullanıcı sorgulama" + baseSuccessfulResultMessage;

        public const string CreateNewUserSuccessfulMessage = "Yeni kullanıcı oluşturma" + baseSuccessfulResultMessage;
        public const string CreateNewUserUnsuccessfulMessage = "Yeni kullanıcı oluşturma" + baseUnsuccessfulResultMessage;

        public const string NotFoundUserMessage = "Kullanıcı bulunamadı. Lütfen tekrar deneyin!";

        public const string UpdateUserSuccessfulMessage = "Kullanıcı güncelleme" + baseSuccessfulResultMessage;
        public const string UpdateUserUnsuccessfulMessage = "Kullanıcı güncelleme" + baseUnsuccessfulResultMessage;

        public const string ThisEmailAlreadyExists = "Bu E-Mail adresi zaten kullanılıyor. Lütfen başka bir E-Mail adresi deneyin!";
        #endregion Users Result Messages

        #region Categories Result Messages

        #endregion Categories Result Messages

        #region ThingsToDo Result Messages

        #endregion ThingsToDo Result Messages

        #region AssignmentHistoryOfTasks Result Messages

        #endregion AssignmentHistoryOfTasks Result Messages
    }
}
