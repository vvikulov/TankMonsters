using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class TankMovement : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Rigidbody2D m_rigidbody;
        [SerializeField]
        private string m_movementAxisName;
        [SerializeField]
        private string m_turnAxisName;

        public float m_speed = 12f;
        public float m_turnSpeed = 180f;

        private float m_movementInputValue;
        private float m_turnInputValue;
        #endregion

        #region Unity Events
        private void Update()
        {
            m_movementInputValue = Input.GetAxis(m_movementAxisName);
            m_turnInputValue = Input.GetAxis(m_turnAxisName);
        }

        private void FixedUpdate()
        {
            Move();
            Turn();
        }
        #endregion

        private void Move()
        {
            Vector2 movement = transform.up * m_movementInputValue * m_speed * Time.deltaTime;
            m_rigidbody.MovePosition(m_rigidbody.position + movement);
        }


        private void Turn()
        {
            float turn = m_turnInputValue * m_turnSpeed * Time.deltaTime;
            m_rigidbody.MoveRotation(m_rigidbody.rotation - turn);
        }
    }
}