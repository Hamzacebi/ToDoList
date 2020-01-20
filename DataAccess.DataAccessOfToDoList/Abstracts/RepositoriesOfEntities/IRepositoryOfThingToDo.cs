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
    /// typeof(ThingsToDo) Entity - Tablosu'na ait Base ve Custom fonksiyonlarin oldugu Interface
    /// </summary>
    public interface IRepositoryOfThingToDo : IRepositoryOfSelectable<ThingsToDo>, IRepositoryOfInsertable<ThingsToDo>,
                                              IRepositoryOfUpdatable<ThingsToDo>, IRepositoryOfDeletable<ThingsToDo>, IDisposable
    {
    }
}
