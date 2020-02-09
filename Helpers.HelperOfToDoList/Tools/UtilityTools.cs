using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Collections.Concurrent;

namespace Helpers.HelperOfToDoList.Tools
{
    /// <summary>
    /// Proje icerisinde herhangi bir yerde kullanilacak yardimci fonksiyonlari iceren class
    /// </summary>
    public class UtilityTools : IDisposable
    {
        #region Global Properties 
        private bool disposedValue;
        private static ConcurrentDictionary<string, object> createdObjectsOfInstances;
        //private static Dictionary<string, object> createdObjectsOfInstances;
        #endregion Global Properties

        #region Constructor(s)
        private UtilityTools()
        {
            this.disposedValue = default(bool);
        }

        static UtilityTools()
        {
            //createdObjectsOfInstances = new Dictionary<string, object>();
            createdObjectsOfInstances = new ConcurrentDictionary<string, object>();
        }
        #endregion Constructor(s)

        public static UtilityTools CreateUtilityInstance => new UtilityTools();

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
                        //createdObjectsOfInstances.Append()

                        //createdObjectsOfInstances..Add(key: interfaceOfInherit.FullName, value: resultToReturnInstance);
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

        #region IDisposable Support

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    createdObjectsOfInstances = new ConcurrentDictionary<string, object>();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

    }
}
