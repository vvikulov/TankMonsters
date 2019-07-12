using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class MonsterMovement : MonoBehaviour
    {
        #region Dependencies
        private Transform m_target;
        #endregion

        #region Fields
        [SerializeField]
        private Rigidbody2D m_rigidbody;

        private bool m_isCanMove;
        private float m_speed;
        #endregion

        #region Unity Events
        private void FixedUpdate()
        {
            if(!m_isCanMove) return;

            if(transform.position != m_target.position)
            {
                m_rigidbody.MovePosition(Vector2.MoveTowards(
                    transform.position, m_target.position, Time.deltaTime * m_speed));
                m_rigidbody.MoveRotation(Quaternion.LookRotation(
                    m_target.position - transform.position, -Vector3.forward));
            }
        }
        #endregion

        #region Public
        public void Init(float speed)
        {
            m_speed = speed;
        }

        public void StartMoveTowards(Transform target)
        {
            m_target = target;
            m_isCanMove = true;
        }

        public void BlockMovement()
        {
            m_isCanMove = false;
        }
        #endregion
    }
}