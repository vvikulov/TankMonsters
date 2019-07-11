using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TankMGame
{
    public interface IRestartGame
    {
        void RestartGame();
    }

    public class GameSceneController : MonoBehaviour, IRestartGame
    {
        #region Fields
        [SerializeField]
        private VfxController m_vfxController;
        [SerializeField]
        private Map m_map;
        [SerializeField]
        private CameraController m_cameraController;
        [SerializeField]
        private Tank m_tank;
        [SerializeField]
        private BulletsPool m_bulletsPool;
        [SerializeField]
        private MonstersPool m_monstersPool;
        #endregion

        #region Unity Events
        private void Start()
        {
            m_vfxController.Init();
            m_map.Init();
            m_cameraController.Init(m_map, m_tank.transform);
            m_bulletsPool.Init(m_vfxController);
            m_tank.Init(m_vfxController, m_bulletsPool, this);
            m_monstersPool.Init(m_tank.transform, m_map.MapHalfSize);
        }
        #endregion

        #region Public
        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        #endregion
    }
}