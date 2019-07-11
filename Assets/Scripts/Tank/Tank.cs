using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class Tank : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private TankMovement m_tankMovement;
        [SerializeField]
        private TankShooting m_tankShooting;
        [SerializeField]
        private TankWeaponChange m_tankWeaponChange;
        [SerializeField]
        private TankHealth m_tankHealth;
        [SerializeField]
        private TankDamageReceiver m_tankDamageReceiver;
        #endregion

        #region Public
        public void Init(VfxController vfxController, BulletsPool bulletsPool)
        {
            m_tankShooting.Init(m_tankWeaponChange, bulletsPool);
            m_tankDamageReceiver.Init(m_tankHealth, vfxController);
        }
        #endregion
    }
}