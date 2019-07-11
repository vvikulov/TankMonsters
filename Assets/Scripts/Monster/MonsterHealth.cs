using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class MonsterHealth : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private float m_health;
        private float m_currentHealth;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float m_defense;
        [SerializeField]
        private Monster m_monster;
        #endregion

        #region Unity Events
        private void Awake()
        {
            ResetHealth();
        }
        #endregion

        public void ResetHealth()
        {
            m_currentHealth = m_health;
        }

        public void RemoveHealth(float damage)
        {
            m_currentHealth -= damage * (1 - m_defense);

            if(m_currentHealth <= 0.0f)
            {
                m_monster.Death();
            }
        }
    }
}