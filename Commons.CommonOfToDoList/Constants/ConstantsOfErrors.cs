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

        #region General Error Messages
        public const string ImplementationExceptionMessage = "";
        #endregion General Error Messages

        #region Base Error Message(s)
        private const string baseTransactionErrorMessage = " işlemi esnasında sistemsel bir hata oluştu!";
        #endregion Base Error Message(s)

        #region User Error Messages
        public const string CreateNewUserTransactionErrorMessage = "Yeni Kullanıcı oluşturma" + baseTransactionErrorMessage;
        public const string FetchUserTransactionErrorMessage = "Kullanıcı bilgilerine ulaşma" + baseTransactionErrorMessage;
        public const string UpdateExistingUserTransactionErrorMessage = "Kullanıcı güncelleme" + baseTransactionErrorMessage;
        #endregion User Error Messages

        #region Category Error Messages
        public const string DeleteExistingCategoryTransactionErrorMessage = "Kategori silme" + baseTransactionErrorMessage;
        public const string CreateNewCategoryTransactionErrorMessage = "Yeni Kategori oluşturma" + baseTransactionErrorMessage;
        public const string UpdateExistingCategoryTransactionErrorMessage = "Kategori güncelleme" + baseTransactionErrorMessage;

        public const string CategoryAlreadyExistsTransactionErrorMessage = "Eklemek istediğiniz bu KATEGORİ daha önceden zaten eklenmişti. Lütfen başka bir KATEGORİ ismi girerek tekrar deneyin!";
        #endregion Category Error Messages

        #region ThingToDo Error Messages

        #endregion ThingToDo Error Messages

        #region AssignmentHistoryOfTask Error Messages

        #endregion AssignmentHistoryOfTask Error Messages
    }
}
