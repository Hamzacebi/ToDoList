using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.CommonOfToDoList.Constants
{
    /// <summary>
    /// Butun Error (Hata) mesajlarini icerir
    /// </summary>
    public static class ConstantsOfErrors
    {
        #region Database Error Messages

        public const string ArgumentNullExceptionMessageForDbContext = "DbContext objesi bos gecilemez!";
        public const string ArgumentNullExceptionMessageForDbContextTransaction = "Commit veya Rollback islemi yapilabilmesi icin Begin Transaction baslatilmasi gerekmektedir. Lutfen bir Begin Transaction islemi baslatin!";

        public const string ArgumentNullExceptionMessageForToDoListDbContext = "Lutfen ulasmak istediginiz tabloya ait repository nesnesi icin tablonun bulundugu DatabaseContext nesnesini verin! Orn: ToDoListDbContext";

        #endregion Database Error Messages

        #region User Error Messages
        public const string CreateNewUserTransactionErrorMessage = "Yeni kullanıcı oluşturma işlemi esnasında sistemsel bir hata oluştu!";
        public const string UpdateExistingUserTransactionErrorMessage = "Kullanıcı güncelleme işlemi esnasında sistemsel bir hata oluştu!";
        #endregion User Error Messages
    }
}
