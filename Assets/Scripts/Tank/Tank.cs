using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankMGame
{
    public interface IDeath
    {
        void Death();
    }

    public class Tank : MonoBehaviour, IDeath
    {
        #region Dependencies
        private IRestartGame m_restartGame;
        #endregion

        #region Fields
        [SerializeField]
        private TankMovement m_tankMovement;
        [SerializeField]
        private TankShooting m_tankShooting;
        [SerializeField]
        private TankWeaponChange m_tankWeaponChange;
        [SerializeField]
        private HealthController m_healthController;
        [SerializeField]
        private TankDamageReceiver m_tankDamageReceiver;
        #endregion

        #region Public
        public void Init(VfxController vfxController, BulletsPool bulletsPool, IRestartGame restartGame)
        {
            m_restartGame = restartGame;

            m_healthController.Init(this);
            m_tankShooting.Init(m_tankWeaponChange, bulletsPool);
            m_tankDamageReceiver.Init(m_healthController, vfxController);
        }

        public void Death()
        {
            m_restartGame.RestartGame();
        }
        #endregion
    }
}