using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class TankWeaponChange : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private TankWeapon[] m_weapons;

        private int m_currentWeaponIndex;
        private KeyCode m_prevWeaponButton;
        private KeyCode m_nextWeaponButton;
        #endregion

        #region Properties
        public TankWeapon CurrentWeapon { get { return m_weapons[m_currentWeaponIndex]; } }
        #endregion

        #region Unity Events
        private void Update()
        {
            int newWeaponIndex = m_currentWeaponIndex;

            if(Input.GetKeyUp(m_prevWeaponButton))
            {
                newWeaponIndex--;
            }
            else if(Input.GetKeyUp(m_nextWeaponButton))
            {
                newWeaponIndex++;
            }

            if(newWeaponIndex < 0)
            {
                newWeaponIndex = 0;
            }
            else if(newWeaponIndex >= m_weapons.Length)
            {
                newWeaponIndex = m_weapons.Length - 1;
            }

            ChangeWeapon(newWeaponIndex);
        }
        #endregion

        #region Public
        public void Init(KeyCode prevWeaponButton, KeyCode nextWeaponButton)
        {
            m_prevWeaponButton = prevWeaponButton;
            m_nextWeaponButton = nextWeaponButton;
        }
        #endregion

        #region Helpers
        private void ChangeWeapon(int newWeaponIndex)
        {
            if(m_currentWeaponIndex != newWeaponIndex)
            {
                m_weapons[m_currentWeaponIndex].gameObject.SetActive(false);
                m_currentWeaponIndex = newWeaponIndex;
                m_weapons[m_currentWeaponIndex].gameObject.SetActive(true);
            }
        }
        #endregion
    }
}