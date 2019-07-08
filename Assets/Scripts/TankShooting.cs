using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class TankShooting : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private string m_fireButton;
        [SerializeField]
        private TankWeaponChange m_tankWeaponChange;
        [SerializeField]
        private BulletsPool m_bulletsPool;
        #endregion

        #region Unity Events
        private void Update()
        {
            if(Input.GetButtonUp(m_fireButton))
            {
                Fire();
            }
        }
        #endregion

        public void Fire()
        {
            TankWeapon currentWeapon = m_tankWeaponChange.CurrentWeapon;

            Bullet bullet = m_bulletsPool.GetBullet(currentWeapon);
            bullet.Init(currentWeapon.WeaponType, currentWeapon.Damage);
            bullet.SetVelocity(currentWeapon.Speed * currentWeapon.BulletSpawnPoint.up);
        }
    }
}