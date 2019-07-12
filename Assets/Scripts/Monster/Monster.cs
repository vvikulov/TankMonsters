using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public enum MonsterType { MONSTER_1, MONSTER_2, MONSTER_3, COUNT }

    public class Monster : MonoBehaviour, IDeath
    {
        #region Dependencies
        private MonstersPool m_monstersPool;
        #endregion

        #region Fields
        [SerializeField]
        private MonsterData m_monsterData;
        [SerializeField]
        private HealthController m_healthController;
        [SerializeField]
        private MonsterDamageReceiver m_monsterDamageReceiver;
        [SerializeField]
        private MonsterMovement m_monsterMovement;
        #endregion

        #region Properties
        public float Damage { get { return m_monsterData.damage; } }
        public MonsterType MonsterType { get { return m_monsterData.monsterType; } }
        #endregion

        #region Public
        public void Init(MonstersPool monstersPool)
        {
            m_monstersPool = monstersPool;

            m_healthController.Init(m_monsterData.health, m_monsterData.defense, this);
            m_monsterDamageReceiver.Init(m_healthController);
            m_monsterMovement.Init(m_monsterData.speed);
        }

        public void SetPos(Vector2 pos)
        {
            this.transform.position = pos;
        }

        public void StartMoveTowards(Transform target)
        {
            m_monsterMovement.StartMoveTowards(target);
        }

        public void Death()
        {
            this.gameObject.SetActive(false);
            m_monsterMovement.BlockMovement();
            m_healthController.ResetHealth();
            m_monstersPool.MakeMonsterAvailable(this);
        }
        #endregion
    }
}