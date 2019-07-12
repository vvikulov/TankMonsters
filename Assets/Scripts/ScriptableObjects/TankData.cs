using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    [CreateAssetMenu(fileName = "TankData", menuName = "ScriptableObjects/TankData")]
    public class TankData : ScriptableObject
    {
        #region Fields
        public string movementAxisName;
        public string turnAxisName;
        public float speed = 9.0f;
        public float turnSpeed = 190.0f;
        public string fireButton;
        public KeyCode prevWeaponButton;
        public KeyCode nextWeaponButton;
        public float health;
        [Range(0.0f, 1.0f)]
        public float defense;
        #endregion
    }
}