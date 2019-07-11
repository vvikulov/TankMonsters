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
        private BulletsPool m_bulletsPool;
        #endregion

        public float Damage { get; private set; }
        public WeaponType WeaponType { get; private set; }

        #region Unity Events
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.layer == Constants.Layers.MONSTERS)
            {
                m_bulletsPool.MakeBulletAvailable(this);

                VFXManager.Instance.ShowHit(this.transform.position);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.layer == Constants.Layers.BORDERS)
            {
                m_bulletsPool.MakeBulletAvailable(this);
            }
        }
        #endregion

        public void Init(WeaponType weaponType, float damage, BulletsPool bulletsPool)
        {
            Damage = damage;
            WeaponType = weaponType;
            m_bulletsPool = bulletsPool;
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
            m_rigidbody.velocity = Vector2.zero;
        }
    }
}