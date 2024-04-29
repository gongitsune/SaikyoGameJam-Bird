using UnityEngine;

namespace Projects.Scripts.Common
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                _instance = FindObjectOfType<T>();
                if (_instance == null) Debug.LogError(typeof(T) + " is nothing");
                return _instance;
            }
        }

        private void OnDestroy()
        {
            _instance = null;
        }
    }
}