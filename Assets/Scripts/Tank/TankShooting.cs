using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class TankShooting : MonoBehaviour
    {
        #region Dependencies
        private TankWeaponChange m_tankWeaponChange;
        private BulletsPool m_bulletsPool;
        #endregion

        #region Fields
        [SerializeField]
        private string m_fireButton;
        #endregion

        #region Unity Events
        private void Update()
        {
            if(Input.GetButtonUp(m_fireButton))
            {
                Shoot();
            }
        }
        #endregion

        #region Public
        public void Init(TankWeaponChange tankWeaponChange, BulletsPool bulletsPool)
        {
            m_tankWeaponChange = tankWeaponChange;
            m_bulletsPool = bulletsPool;
        }
        #endregion

        #region Helpers
        private void Shoot()
        {
            TankWeapon currentWeapon = m_tankWeaponChange.CurrentWeapon;

            Bullet bullet = m_bulletsPool.GetBullet(currentWeapon);
            bullet.SetVelocity(currentWeapon.Speed * currentWeapon.BulletSpawnPoint.up);
        }
        #endregion
    }
}