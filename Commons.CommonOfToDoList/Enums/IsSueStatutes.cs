using System;
using System.Collections.Generic;
using System.Text;

namespace Commons.CommonOfToDoList.Enums
{
    /// <summary>
    /// Herhangi bir To Do icin islem turleri
    /// </summary>
    public enum IsSueStatutes
    { 
        /// <summary>
        /// Acildi ve beklemede
        /// </summary>
        OpenAndPending = 0,

        /// <summary>
        /// Kabul edildi
        /// </summary>
        Accepted = 1,

        /// <summary>
        /// Islemde - Yapiliyor - Devam etmekte
        /// </summary>
        InProgress = 2,

        /// <summary>
        /// Tamamlandi
        /// </summary>
        Done = 3,

        /// <summary>
        /// Kapatildi
        /// </summary>
        Closed = 4,

        /// <summary>
        /// Iptal edildi
        /// </summary>
        Canceled = 5,

        /// <summary>
        /// Red edildi
        /// </summary>
        Rejected = 6
    }
}
