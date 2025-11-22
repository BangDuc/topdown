using UnityEngine;

namespace singleton_bang
{
    public class Singleton_Monobehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static bool IsExist => _instance;

        public static T Instance => GetInstance();

        public static T GetInstance()
        {
            if (_instance) return _instance;
            _instance = FindAnyObjectByType<T>();
            if (_instance) return _instance;
            return _instance = new GameObject(typeof(T).Name).AddComponent<T>();

        }

        protected virtual void Awake()
        {
            if (_instance && _instance != this)
            {
                Destroy(gameObject);
                return;
            }
            _instance = this as T;

        }


    }

    public class SingletonPersistent_Monobehaviour<T> : Singleton_Monobehaviour<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(transform.root);
        }
    }
}

