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
    /// typeof(AssignmentHistoryOfTasks) Entity - Tablosu'na ait Base ve Custom fonksiyonlarin oldugu Interface
    /// </summary>
    public interface IRepositoryAssignmentHistoryOfTask : IRepositoryOfSelectable<AssignmentHistoryOfTasks>, IRepositoryOfInsertable<AssignmentHistoryOfTasks>,
                                                          IRepositoryOfUpdatable<AssignmentHistoryOfTasks>, IDisposable
    {
    }
}
