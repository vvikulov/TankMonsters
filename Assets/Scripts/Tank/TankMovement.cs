﻿using System.Collections;
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
        private Animator m_animator;

        private string m_movementAxisName;
        private string m_turnAxisName;
        private float m_speed;
        private float m_turnSpeed;

        private float m_movementInputValue;
        private float m_turnInputValue;
        private bool m_isMove;
        #endregion

        #region Unity Events
        private void Update()
        {
            m_movementInputValue = Input.GetAxis(m_movementAxisName);
            m_turnInputValue = Input.GetAxis(m_turnAxisName);

            bool isMove = m_movementInputValue != 0.0f || m_turnInputValue != 0.0f;

            if(m_isMove != isMove)
            {
                m_animator.SetBool("isMove", isMove);
                m_isMove = isMove;
            }
        }

        private void FixedUpdate()
        {
            Move();
            Turn();
        }
        #endregion

        #region Public
        public void Init(string movementAxisName, string turnAxisName, float speed, float turnSpeed)
        {
            m_movementAxisName = movementAxisName;
            m_turnAxisName = turnAxisName;
            m_speed = speed;
            m_turnSpeed = turnSpeed;
        }
        #endregion

        #region Helpers
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
        #endregion
    }
}