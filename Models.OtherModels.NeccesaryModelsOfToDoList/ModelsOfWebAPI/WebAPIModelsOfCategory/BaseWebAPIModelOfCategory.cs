using System.ComponentModel.DataAnnotations;

#region Global Usings
using Commons.CommonOfToDoList.Constants;
#endregion Global Usings

namespace Models.OtherModels.NeccesaryModelsOfToDoList.ModelsOfWebAPI.WebAPIModelsOfCategory
{
    public class BaseWebAPIModelOfCategory
    {
        [Required(ErrorMessage = ConstantsOfValidations.CategoryNameCannotBeEmpty)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = ConstantsOfValidations.CategoryDescriptionCannotBeEmpty)]
        public string CategoryDescription { get; set; }
    }
}
