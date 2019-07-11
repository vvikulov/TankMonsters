﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public enum MonsterType { MONSTER_1, MONSTER_2, MONSTER_3, COUNT }

    public class Monster : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private MonsterType m_monsterType;
        [SerializeField]
        private Rigidbody2D m_rigidbody;
        [SerializeField]
        private float m_damage;
        [SerializeField]
        private float m_speed;
        [SerializeField]
        private MonsterHealth m_monsterHealth;

        private Transform m_target;
        private bool m_isCanMove;
        private MonstersPool m_monstersPool;
        #endregion

        public float Damage { get { return m_damage; } }
        public MonsterType MonsterType { get { return m_monsterType; } }

        #region Unity Events
        private void FixedUpdate()
        {
            if(!m_isCanMove) return;

            if(transform.position != m_target.position)
            {
                m_rigidbody.MovePosition(Vector2.MoveTowards(transform.position, m_target.position, Time.deltaTime * m_speed));
                m_rigidbody.MoveRotation(Quaternion.LookRotation(m_target.position - transform.position, -Vector3.forward));
            }
        }
        #endregion

        public void Init(MonstersPool monstersPool)
        {
            m_monstersPool = monstersPool;
        }

        public void SetPos(Vector2 pos)
        {
            this.transform.position = pos;
        }

        public void StartMoveTowards(Transform target)
        {
            m_target = target;
            m_isCanMove = true;
        }

        public void Death()
        {
            this.gameObject.SetActive(false);
            m_isCanMove = false;
            m_monsterHealth.ResetHealth();
            m_monstersPool.MakeMonsterAvailable(this);
        }
    }
}