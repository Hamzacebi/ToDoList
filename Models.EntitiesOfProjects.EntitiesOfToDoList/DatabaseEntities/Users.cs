using System;
using System.Collections.Generic;

namespace Models.EntitiesOfProjects.EntitiesOfToDoList.DatabaseEntities
{
    public partial class Users
    {
        public Users()
        {
            AssignmentHistoryOfTasks = new HashSet<AssignmentHistoryOfTasks>();
            Categories = new HashSet<Categories>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<AssignmentHistoryOfTasks> AssignmentHistoryOfTasks { get; set; }
        public virtual ICollection<Categories> Categories { get; set; }
    }
}
