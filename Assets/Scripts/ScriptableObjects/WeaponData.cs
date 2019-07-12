using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    [CreateAssetMenu(fileName = "WeaponData", menuName = "ScriptableObjects/WeaponData")]
    public class WeaponData : ScriptableObject
    {
        #region Fields
        public WeaponType weaponType;
        public float damage;
        public float speed;
        #endregion
    }
}