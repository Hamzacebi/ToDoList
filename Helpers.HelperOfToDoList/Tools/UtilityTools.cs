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
        private static readonly ConcurrentDictionary<string, object> createdObjectsOfInstances;
        #endregion Global Properties

        #region Constructor(s)
        private UtilityTools()
        {
            this.disposedValue = default(bool);
        }

        static UtilityTools()
        {
            createdObjectsOfInstances = new ConcurrentDictionary<string, object>();
        }
        #endregion Constructor(s)

        public static UtilityTools CreateUtilityInstance => new UtilityTools();

        /// <summary>
        /// Kendisine verilen Interface ve Class degerlerine gore Singleton olarak bir Constructor'a herhangi bir deger 
        /// gondermeden instance uretmeye yarayan fonksiyon
        /// </summary>
        /// <typeparam name="T">Instance degeri elde edilmek istenilen Interface</typeparam>
        /// <param name="resultToReturnClass">Interface'den Inherit edilmis olan class</param>
        /// <returns></returns>
        public static T CreateGenericSingletonInstance<T>(Type resultToReturnClass)
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
                        return (T)createdObjectsOfInstances[key: interfaceOfInherit.FullName];
                    }
                    Lazy<T> createdSingletonInstance = new Lazy<T>(valueFactory: () =>
                    {
                        object createdInstance = Activator.CreateInstance(type: resultToReturnClass);
                        return (T)createdInstance;
                    });

                    T resultToReturnSingletonInstance = createdSingletonInstance.Value;
                    if (createdSingletonInstance.IsValueCreated)
                    {
                        createdObjectsOfInstances.TryAdd(key: interfaceOfInherit.FullName,
                                                         value: resultToReturnSingletonInstance);
                        return resultToReturnSingletonInstance;
                    }
                }
                else
                {
                    throw new NotImplementedException(message: $"{resultToReturnClass.Name} adlı CLASS {interfaceOfInherit.Name} adlı INTERFACE'den miras almadığı için {interfaceOfInherit.Name} adlı INTERFACE için bir nesne üretilemiyor. Lütfen {interfaceOfInherit.Name}'den miras alan bir CLASS tanımlayınız ve 'resultToReturnClass' adlı parametreye bu CLASS değerini verin!");
                }
            }
            return default(T);
        }

        /// <summary>
        /// Kendisine verilen Interface ve Class degerlerine gore Singleton olarak bir Constructor'a, kendisine verilen degerleri
        /// gondererek instance uretmeye yarayan fonksiyon
        /// </summary>
        /// <typeparam name="T">Instance degeri elde edilmek istenilen Interface</typeparam>
        /// <param name="resultToReturnClass">Interface'den Inherit edilmis olan class</param>
        /// <param name="constructorParameters">Inherit edilmis olan class'a ait Constructor'a gonderilmek istenilen parametre / parametreler</param>
        /// <returns></returns>
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
                    Lazy<T> createdSingletonInstance = new Lazy<T>(valueFactory: () =>
                                                                   {
                                                                       object createdInstance = Activator.CreateInstance(type: resultToReturnClass,
                                                                                                                         args: constructorParameters);
                                                                       return (T)createdInstance;
                                                                   });
                    T resultToReturnInstance = createdSingletonInstance.Value;
                    if (createdSingletonInstance.IsValueCreated)
                    {
                        createdObjectsOfInstances.TryAdd(key: interfaceOfInherit.FullName, value: resultToReturnInstance);
                        return resultToReturnInstance;
                    }
                }
                else
                {
                    throw new NotImplementedException(message: $"{resultToReturnClass.Name} adlı CLASS {interfaceOfInherit.Name} adlı INTERFACE'den miras almadığı için {interfaceOfInherit.Name} adlı INTERFACE için bir nesne üretilemiyor. Lütfen {interfaceOfInherit.Name}'den miras alan bir CLASS tanımlayınız ve 'resultToReturnClass' adlı parametreye bu CLASS değerini verin!");
                }
            }
            return default(T);
        }

        //ToDo : IDisposable icin calisilip burasi ve tum projede ki IDisposable implementationlari duzeltilecek
        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    createdObjectsOfInstances.Clear();
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
