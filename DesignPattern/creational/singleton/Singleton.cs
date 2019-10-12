using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.creational.singleton
{
    /// <summary>
    /// 单例模式
    /// </summary>
    class Singleton
    {
        private static Singleton _instance;
        protected Singleton() { }
        public static Singleton instance()
        {
            if (_instance.Equals(null))
            {
                _instance =  new Singleton();
            }
            return _instance;
        }
    }
    /// <summary>
    /// double check lock singleton
    /// </summary>
    class SafeSingleton
    {
        private static volatile SafeSingleton _instance;
        private static object _lock = new object();

        private SafeSingleton() { }
        public static SafeSingleton GetInstance
        {
            get{
                if (_instance.Equals(null))
                {
                    lock (_lock)
                    {
                        if (_instance.Equals(null))
                        {
                            _instance = new SafeSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }

    class LazySingleton
    {
        private static readonly Lazy<LazySingleton> _instance = new Lazy<LazySingleton>(() => new LazySingleton());
        private LazySingleton() { }
        public static LazySingleton GetInstance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
    /// <summary>
    /// 泛型单例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class TSingleton<T> where T : class, new()
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => (T)Activator.CreateInstance(typeof(T), true));
        
        public static T GetInstance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}
