using System;
using System.Collections.Generic;
using System.Text;

namespace Models.OtherModels.NeccesaryModelsOfToDoList
{
    public class ResultModel
    {
        private ResultModel() { }

        public String Message { get; private set; } = string.Empty;
        public Boolean IsSuccess { get; private set; } = default(bool);

        private static ResultModel CreateResult(Boolean isSuccess, String message) => new ResultModel()
        {
            IsSuccess = isSuccess,
            Message = message
        };

        /// <summary>
        /// Basarili islemler icin kullanilacak olan ResultModel
        /// </summary>
        /// <param name="successfulResultMessage">Basarili islem mesaji</param>
        /// <returns></returns>
        public static ResultModel SuccessfulResult(String successfulResultMessage = "") => CreateResult(isSuccess: true,
                                                                                                        message: successfulResultMessage);

        /// <summary>
        /// Basarisiz islemler icin kullanilacak olan ResultModel
        /// </summary>
        /// <param name="unsuccessfulResultMessage">Basarisiz islem mesaji</param>
        /// <returns></returns>
        public static ResultModel UnsuccessfulResult(String unsuccessfulResultMessage = "") => CreateResult(isSuccess: false,
                                                                                                            message: unsuccessfulResultMessage);



    }
}
