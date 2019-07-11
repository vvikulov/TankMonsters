using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class MonsterDamageReceiver : MonoBehaviour
    {
        #region Dependencies
        private IHealth m_healthController;
        #endregion

        #region Public
        public void Init(IHealth healthController)
        {
            m_healthController = healthController;
        }
        #endregion

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == Constants.Layers.BULLETS)
            {
                m_healthController.RemoveHealth(other.GetComponent<Bullet>().Damage);
            }
        }
    }
}