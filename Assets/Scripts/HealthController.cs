using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankMGame
{
    public interface IHealth
    {
        void RemoveHealth(float damage);
    }

    public class HealthController : MonoBehaviour, IHealth
    {
        #region Dependencies
        private IDeath m_mortalObj;
        #endregion

        #region Fields
        [SerializeField]
        private float m_health;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float m_defense;

        private float m_currentHealth;
        #endregion

        #region Public
        public void Init(IDeath mortalObj)
        {
            m_mortalObj = mortalObj;

            ResetHealth();
        }

        public void ResetHealth()
        {
            m_currentHealth = m_health;
        }

        public void RemoveHealth(float damage)
        {
            m_currentHealth -= damage * (1 - m_defense);

            if(m_currentHealth <= 0.0f)
            {
                m_mortalObj.Death();
            }
        }
        #endregion
    }
}