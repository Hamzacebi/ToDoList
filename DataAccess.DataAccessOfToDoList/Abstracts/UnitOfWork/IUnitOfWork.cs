using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DataAccessOfToDoList.Abstracts.UnitOfWork
{
    #region Internal Project Usings

    using RepositoriesOfEntities;

    #endregion Internal Project Usings

    /// <summary>
    /// Repository Interfacelerine, Database Transaction fonksiyonlarina ve SaveChanges fonksiyon / fonksiyonlarina ulasmayi saglayan Interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region SaveChanges Function

        /// <summary>
        /// Database icin yapilan C (Create) - U (Update) - D (Delete) islemlerinin Database'e gonderilmesini saglayan fonksiyon
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        #endregion SaveChanges Function


        #region Transaction Functions

        /// <summary>
        /// Database uzerinde Insert, Update ve Delete islemleri yapilirken olusabilecek herhangi bir hata - basari durumunda 
        /// RollBack - Commit yonetimini yapabilmek icin Database'e ulasilma aninda direkt olarak Begin Transaction baslatan fonksiyon
        /// </summary>
        /// <returns></returns>
        void BeginTransaction();

        /// <summary>
        /// Database uzerinde yapilan Insert - Update ve Delete islemleri icin herhangi bir hata durumu yoksa yapilan degisiklikleri veritabanina 
        /// kayit edilmesini saglayan fonksiyon
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Database uzerinde yapilan Insert - Update ve Delete islemleri icin yapilan islemlerde herhangi bir hata oldugunda tum degisiklikleri geri
        /// almaya yarayan fonksiyon
        /// </summary>
        void RollbackTransaction();

        #endregion Transaction Functions


        #region Repositories Properties

        /// <summary>
        /// typeof(Users) Entity - Tablosu'na ait Repository tablosuna ulasmayi saglayan property
        /// </summary>
        IRepositoryOfUser RepositoryOfUser { get; }

        /// <summary>
        /// typeof(Categories) Entity - Tablosu'na ait Repository tablosuna ulasmayi saglayan property
        /// </summary>
        IRepositoryOfCategory RepositoryOfCategory { get; }

        /// <summary>
        /// typeof(ThingsToDo) Entity - Tablosu'na ait Repository tablosuna ulasmayi saglayan property
        /// </summary>
        IRepositoryOfThingToDo RepositoryOfThingToDo { get; }

        /// <summary>
        /// typeof(AssignmentHistoryOfTasks) Entity - Tablosu'na ait Repository tablosuna ulasmayi saglayan property
        /// </summary>
        IRepositoryAssignmentHistoryOfTask RepositoryAssignmentHistoryOfTask { get; }

        #endregion Repositories Properties

    }
}
