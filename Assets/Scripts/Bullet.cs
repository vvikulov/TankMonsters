using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class Bullet : MonoBehaviour
    {
        #region MyRegion
        [SerializeField]
        private Rigidbody2D m_rigidbody;
        #endregion

        public float Damage { get; private set; }
        public WeaponType WeaponType { get; private set; }

        public void Init(WeaponType weaponType, float damage)
        {
            Damage = damage;
            WeaponType = weaponType;
        }

        public void SetPosRotation(Vector2 pos, Quaternion rotation)
        {
            transform.position = pos;
            transform.rotation = rotation;
        }

        public void SetVelocity(Vector2 newVelocity)
        {
            m_rigidbody.velocity = newVelocity;
        }

        public void ResetAll()
        {
            //transform.position = Vector2.zero;
            //m_rigidbody.position = Vector2.zero;
            //m_rigidbody.rotation = 0.0f;
            m_rigidbody.velocity = Vector2.zero;
        }
    }
}