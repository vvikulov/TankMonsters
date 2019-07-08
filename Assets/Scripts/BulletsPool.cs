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

        private Dictionary<WeaponType, List<Bullet>> m_available;
        #endregion

        private void Awake()
        {
            m_available = new Dictionary<WeaponType, List<Bullet>>();//new List<Bullet>();

            for(int i = 0; i < (int)WeaponType.COUNT; i++)
            {
                m_available.Add((WeaponType)i, new List<Bullet>());
            }
        }

        public Bullet GetBullet(TankWeapon currentWeapon)
        {
            List<Bullet> available = m_available[currentWeapon.WeaponType];

            Bullet bullet = null;

            for(int i = available.Count - 1; i >= 0; i--)
            {
                bullet = available[i];

                if(bullet.WeaponType == currentWeapon.WeaponType)
                {
                    available.RemoveAt(i);

                    bullet.SetPosRotation(
                        currentWeapon.BulletSpawnPoint.position,
                        currentWeapon.BulletSpawnPoint.rotation);

                    break;
                }
            }

            if(bullet == null)
            {
                bullet = CreateBullet(currentWeapon);
            }

            bullet.gameObject.SetActive(true);

            return bullet;
        }
        
        public void MakeBulletAvailable(Bullet bullet)
        {
            bullet.ResetAll();
            bullet.gameObject.SetActive(false);
            m_available[bullet.WeaponType].Add(bullet);
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