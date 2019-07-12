using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public enum WeaponType { COMMON, LASER, PLAZM, COUNT }

    public class TankWeapon : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private WeaponData m_weaponData;
        [SerializeField]
        private Transform m_bulletSpawnPoint;
        #endregion

        #region Properties
        public WeaponType WeaponType { get { return m_weaponData.weaponType; } }
        public float Damage { get { return m_weaponData.damage; } }
        public float Speed { get { return m_weaponData.speed; } }
        public Transform BulletSpawnPoint { get { return m_bulletSpawnPoint; } }
        #endregion
    }
}