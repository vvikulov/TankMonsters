using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class VfxController : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Transform m_hitPrefab;

        private List<Transform> m_hitsGo;
        #endregion

        #region Public
        public void Init()
        {
            m_hitsGo = new List<Transform>();
        }

        public void ShowHit(Vector2 pos)
        {
            Transform vfx = GetAvailableHitGo();
            if(vfx == null)
            {
                vfx = GameObject.Instantiate(m_hitPrefab, this.transform);
                m_hitsGo.Add(vfx);
            }
            else
            {
                vfx.gameObject.SetActive(true);
            }
            vfx.position = pos;
        }
        #endregion

        #region Helpers
        private Transform GetAvailableHitGo()
        {
            foreach(Transform go in m_hitsGo)
            {
                if(!go.gameObject.activeSelf)
                {
                    return go;
                }
            }
            return null;
        }
        #endregion
    }
}