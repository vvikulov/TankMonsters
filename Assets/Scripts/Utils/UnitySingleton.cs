using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public abstract class UnitySingleton<T> : MonoBehaviour where T : UnitySingleton<T>
    {
        #region Fields
        private static T m_instance;
        [SerializeField]
        private bool m_isPersist = true;
        #endregion

        #region Properties
        public static T Instance
        {
            get
            {
                if(!IsInstantiated)
                {
                    // This would only EVER be null if some other MonoBehavior requests the instance
                    // in its' Awake method.

                    Debug.Log("[UnitySingleton] Finding instance of '" + typeof(T).ToString() +
                              "' object.");

                    m_instance = FindObjectOfType<T>();

                    // This should only occur if 'T' hasn't been attached to any game
                    // objects in the scene.

                    if(m_instance == null)
                    {
                        Debug.LogWarning("[UnitySingleton] No instance of " + typeof(T).ToString()
                                       + " found!");

                        GameObject tempInstanceObject = new GameObject(typeof(T).ToString());
                        m_instance = tempInstanceObject.AddComponent<T>();

                        Debug.Log("[UnitySingleton] Instance of " + typeof(T).ToString()
                                       + " is created");
                    }

                    m_instance.InitInner();
                }

                return m_instance;
            }
        }

        public static bool IsInstantiated
        {
            get { return m_instance != null; }
        }

        public bool IsPersist
        {
            get { return m_isPersist; }
            protected set { m_isPersist = value; }
        }
        #endregion

        #region Unity Events
        private void Awake()
        {
            Instantiation();
        }

        // Make sure no "ghost" objects are left behind when applicaton quits.
        private void OnApplicationQuit()
        {
            m_instance = null;
        }
        #endregion

        #region Initialisation
        private bool Instantiation()
        {
            if(IsInstantiated)
            {
                if(gameObject != m_instance.gameObject)
                {
                    Debug.LogWarning("[UnitySingleton] Only one " + typeof(T) +
                        " is allowed, destroying " + gameObject.name + ".");
                    GameObject.Destroy(this.gameObject);
                    return false;
                }
            }
            else
            {
                m_instance = this as T;
                InitInner();
            }

            return true;
        }
        #endregion

        #region Helpers
        private void InitInner()
        {
            m_instance.Init();
            if(m_isPersist && this.transform.parent == null)
                GameObject.DontDestroyOnLoad(gameObject);
        }
        #endregion

        #region Virtual
        // Override this in child classes rather than have Awake().
        virtual protected void Init()
        {
        }
        #endregion
    }
}