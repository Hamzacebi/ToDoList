using System;
using System.Collections.Generic;

namespace Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities
{
    public partial class ThingsToDo
    {
        public ThingsToDo()
        {
            AssignmentHistoryOfTasks = new HashSet<AssignmentHistoryOfTasks>();
        }

        public short Id { get; set; }
        public short CategoryId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool? Status { get; set; }
        public byte PriorityType { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual Categories Category { get; set; }
        public virtual ICollection<AssignmentHistoryOfTasks> AssignmentHistoryOfTasks { get; set; }
    }
}
