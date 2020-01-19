using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfDataTransferObject
{
    public class DTOOfThingToDo
    {
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
    }
}
