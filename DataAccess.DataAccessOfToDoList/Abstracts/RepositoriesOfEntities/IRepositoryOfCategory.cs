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
    /// typeof(Categories) Entity - Tablosu'na ait Base ve Custom fonksiyonlarin oldugu Interface
    /// </summary>
    public interface IRepositoryOfCategory : IRepositoryOfSelectable<Categories>, IRepositoryOfInsertable<Categories>,
                                             IRepositoryOfUpdatable<Categories>, IRepositoryOfDeletable<Categories>, IDisposable
    {
    }
}
