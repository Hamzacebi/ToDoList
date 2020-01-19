using System;
using System.Collections.Generic;

namespace Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities
{
    public partial class Categories
    {
        public Categories()
        {
            ThingsToDo = new HashSet<ThingsToDo>();
        }

        public short Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<ThingsToDo> ThingsToDo { get; set; }
    }
}
