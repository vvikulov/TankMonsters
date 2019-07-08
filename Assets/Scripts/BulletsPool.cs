using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    [System.Serializable]
    public class BulletsPool : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Bullet[] m_bulletPrefabs;

        private List<Bullet> m_available;
        private List<Bullet> m_inUse;
        #endregion

        private void Awake()
        {
            m_available = new List<Bullet>();
            m_inUse = new List<Bullet>();
        }

        public Bullet GetBullet(TankWeapon currentWeapon)
        {
            for(int i = m_available.Count - 1; i >= 0; i--)
            {
                Bullet bullet = m_available[i];

                if(bullet.WeaponType == currentWeapon.WeaponType)
                {
                    m_inUse.Add(bullet);
                    m_available.RemoveAt(i);

                    return bullet;
                }
            }

            Bullet newBullet = CreateBullet(currentWeapon);
            m_inUse.Add(newBullet);

            return newBullet;
        }

        private Bullet CreateBullet(TankWeapon currentWeapon)
        {
            Bullet bullet = GameObject.Instantiate(m_bulletPrefabs[(int)currentWeapon.WeaponType],
                currentWeapon.BulletSpawnPoint.position, currentWeapon.BulletSpawnPoint.rotation);
            bullet.transform.SetParent(this.transform, true);
            return bullet;
        }
    }
}