using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfDataTransferObject
{
    public class DTOOfAssignmentHistoryOfTask
    {
        public short Id { get; set; }
        public Guid UserId { get; set; }
        public short ToDoId { get; set; }
        public DateTime DateToAccepted { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public byte ProcessType { get; set; }
    }
}
