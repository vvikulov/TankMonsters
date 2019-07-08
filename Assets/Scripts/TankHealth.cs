using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class TankHealth : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private float m_health;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float m_defense;
        #endregion

        public float Health { get { return m_health; } }

        public void RemoveHealth(float damage)
        {
            m_health -= damage * m_defense;
        }
    }
}