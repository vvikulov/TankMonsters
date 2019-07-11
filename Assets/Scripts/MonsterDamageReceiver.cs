using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class MonsterDamageReceiver : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private MonsterHealth m_monsterHealth;
        [SerializeField]
        private Monster m_monster;
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