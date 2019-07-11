using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class MonsterDamageReceiver : MonoBehaviour
    {
        #region Dependencies
        private MonsterHealth m_monsterHealth;
        #endregion

        #region Public
        public void Init(MonsterHealth monsterHealth)
        {
            m_monsterHealth = monsterHealth;
        }
        #endregion

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.layer == Constants.Layers.BULLETS)
            {
                m_monsterHealth.RemoveHealth(other.GetComponent<Bullet>().Damage);
            }
        }
    }
}