using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class MapBorder : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private BulletsPool m_bulletsPool;
        #endregion

        #region Unity Events
        void OnTriggerExit2D(Collider2D other)
        {
            if(other.tag == Constants.Tags.BULLET)
            {
                m_bulletsPool.MakeBulletAvailable(other.GetComponent<Bullet>());
            }
        }
        #endregion
    }
}