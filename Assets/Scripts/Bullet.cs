using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class Bullet : MonoBehaviour
    {
        #region Dependencies
        private BulletsPool m_bulletsPool;
        private VfxController m_vfxController;
        #endregion

        #region Fields
        [SerializeField]
        private Rigidbody2D m_rigidbody;
        #endregion

        #region Properties
        public float Damage { get; private set; }
        public WeaponType WeaponType { get; private set; }
        #endregion

        #region Unity Events
        private void OnTriggerEnter2D(Collider2D col)
        {
            if(col.gameObject.layer == Constants.Layers.MONSTERS)
            {
                m_bulletsPool.MakeBulletAvailable(this);

                m_vfxController.ShowHit(this.transform.position);
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

        #region Public
        public void Init(WeaponType weaponType, float damage, BulletsPool bulletsPool, VfxController vfxController)
        {
            Damage = damage;
            WeaponType = weaponType;

            m_bulletsPool = bulletsPool;
            m_vfxController = vfxController;
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

        public void ResetVelocity()
        {
            m_rigidbody.velocity = Vector2.zero;
        }
        #endregion
    }
}