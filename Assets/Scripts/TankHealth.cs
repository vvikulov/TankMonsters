using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        public void RemoveHealth(float damage)
        {
            m_health -= damage * (1 - m_defense);

            if(m_health <= 0.0f)
            {
                RestartGame();
            }
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}