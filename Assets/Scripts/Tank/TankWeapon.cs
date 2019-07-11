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
        private WeaponType m_weaponType;
        [SerializeField]
        private float m_damage;
        [SerializeField]
        private float m_speed;
        [SerializeField]
        private Transform m_bulletSpawnPoint;
        #endregion

        public WeaponType WeaponType { get { return m_weaponType; } }
        public float Damage { get { return m_damage; } }
        public float Speed { get { return m_speed; } }
        public Transform BulletSpawnPoint { get { return m_bulletSpawnPoint; } }
    }
}