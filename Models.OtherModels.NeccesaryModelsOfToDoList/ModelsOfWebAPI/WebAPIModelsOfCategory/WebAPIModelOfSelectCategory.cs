using System;

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory
{
    public sealed class WebAPIModelOfSelectCategory : BaseWebAPIModelOfCategory
    {
        public short CategoryId { get; set; }
        public bool CategoryStatus { get; set; }
        public DateTime CategoryCreationDate { get; set; }
        public Nullable<DateTime> CategoryUpdateDate { get; set; }
        public Nullable<DateTime> CategoryDeleteDate { get; set; }
    }
}
