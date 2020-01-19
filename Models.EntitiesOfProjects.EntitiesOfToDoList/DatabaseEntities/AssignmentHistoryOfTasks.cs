using System;
using System.Collections.Generic;

namespace Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities
{
    public partial class AssignmentHistoryOfTasks
    {
        public short Id { get; set; }
        public Guid UserId { get; set; }
        public short ToDoId { get; set; }
        public DateTime DateToAccepted { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public byte ProcessType { get; set; }

        public virtual ThingsToDo ToDo { get; set; }
        public virtual Users User { get; set; }
    }
}
