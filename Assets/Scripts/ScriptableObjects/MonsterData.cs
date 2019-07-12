using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    [CreateAssetMenu(fileName = "MonsterData", menuName = "ScriptableObjects/MonsterData")]
    public class MonsterData : ScriptableObject
    {
        #region Fields
        public MonsterType monsterType;
        public float damage;
        public float speed;
        public float health;
        [Range(0.0f, 1.0f)]
        public float defense;
        #endregion
    }
}