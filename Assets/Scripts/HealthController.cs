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
        private float m_health;
        private float m_defense;
        private float m_currentHealth;
        #endregion

        #region Public
        public void Init(float health, float defense, IDeath mortalObj)
        {
            m_health = health;
            m_defense = defense;
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