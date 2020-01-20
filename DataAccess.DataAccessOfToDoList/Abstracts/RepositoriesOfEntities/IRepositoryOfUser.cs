using System;
using System.Collections.Generic;
using System.Text;

#region Global Usings

using Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities;
using SinanHamzaceBi.GenericRepository.Abstracts.RepositoryOfBasics;

#endregion Global Usings

namespace DataAccess.DataAccessOfToDoList.Abstracts.RepositoriesOfEntities
{
    /// <summary>
    /// typeof(Users) Entity - Tablosu'na ait Base ve Custom fonksiyonlarin oldugu Interface
    /// </summary>
    public interface IRepositoryOfUser : IRepositoryOfSelectable<Users>, IRepositoryOfInsertable<Users>,
                                         IRepositoryOfUpdatable<Users>, IDisposable
    {
    }
}
