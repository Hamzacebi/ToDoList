using System;
using System.Collections.Generic;
using System.Text;

namespace Helpers.HelperOfToDoList.Mappers.Base
{
    public interface IMapper<TEntity, TDTO> where TEntity : class where TDTO : class
    {
        /// <summary>
        /// Verilen DTO nesnesini Entity nesnesi olarak veren fonksiyon
        /// </summary>
        /// <param name="dtoObject">Entity nesnesine donusturulecek olan DTO nesnesi</param>
        /// <returns></returns>
        TEntity MapToEntity(TDTO dtoObject);

        /// <summary>
        /// Verilen Entity nesnesini DTO nesnesi olarak veren fonksiyon
        /// </summary>
        /// <param name="entityObject">DTO nesnesine donusturulecek olan Entity nesnesi</param>
        /// <returns></returns>
        TDTO MapToDTO(TEntity entityObject);

        //ToDo: List yerine IEnumerable yazilabilir. Managerde foreach icerisinde donulmeye gore degisir bu durum
        /// <summary>
        /// Verilen Entity nesnesine ait listeyi DTO nesnesine ait liste olarak veren fonksiyon
        /// </summary>
        /// <param name="entityList">DTO nesnesine ait liste olarak elde edilmek istenilen Entity nesnesine ait liste</param>
        /// <returns></returns>
        List<TDTO> MapToDTOList(IEnumerable<TEntity> entityList);
    }
}
