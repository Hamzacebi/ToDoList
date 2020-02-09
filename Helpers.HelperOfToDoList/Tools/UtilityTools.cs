using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Helpers.HelperOfToDoList.Tools
{
    /// <summary>
    /// Proje icerisinde herhangi bir yerde kullanilacak yardimci fonksiyonlari iceren class
    /// </summary>
    public class UtilityTools
    {
        #region Global Properties 
        private static Dictionary<string, object> createdObjectsOfInstances;
        #endregion Global Properties

        #region Constructor(s)
        private UtilityTools() { }

        static UtilityTools()
        {
            createdObjectsOfInstances = new Dictionary<string, object>();
        }
        #endregion Constructor(s)


        //public static T CreateGenericSingletonInstance<T>(Type resultToReturnClass)
        //{
        //    return default(T);
        //}

        public static T CreateGenericSingletonInstance<T>(Type resultToReturnClass, object[] constructorParameters)
        {
            if (resultToReturnClass != null)
            {
                Type interfaceOfInherit = typeof(T);

                bool isInheritedInterface = ((TypeInfo)resultToReturnClass).ImplementedInterfaces
                                                                           .Contains(value: interfaceOfInherit);
                if (isInheritedInterface)
                {
                    if (createdObjectsOfInstances.ContainsKey(key: interfaceOfInherit.FullName))
                    {
                        return (T)createdObjectsOfInstances[interfaceOfInherit.FullName];
                    }
                    Lazy<T> createdSingletonInstance = new Lazy<T>(isThreadSafe: true,
                                                                   valueFactory: () =>
                                                                   {
                                                                       object createdInstance = Activator.CreateInstance(type: resultToReturnClass,
                                                                                                                         args: constructorParameters);
                                                                       return (T)createdInstance;
                                                                   });
                    T resultToReturnInstance = createdSingletonInstance.Value;
                    if (createdSingletonInstance.IsValueCreated)
                    {
                        createdObjectsOfInstances.Add(key: interfaceOfInherit.FullName, value: resultToReturnInstance);
                        return resultToReturnInstance;
                    }
                }
                else
                {
                    throw new NotImplementedException(message: "Elde edilmek istenilen class, verilen typeof(T) tipindeki interfaceden miras almadi");
                }
            }
            return default(T);
        }


        #region Disposable Function

        public static void Dispose()
        {
            createdObjectsOfInstances = new Dictionary<string, object>();
        }
        #endregion Disposable Function

    }
}
