using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class VFXManager : UnitySingleton<VFXManager>
    {
        #region Fields
        [SerializeField]
        private Transform hitPrefab;
        private List<Transform> hitsGo;
        #endregion

        override protected void Init()
        {
            hitsGo = new List<Transform>();
        }

        public void ShowHit(Vector2 pos)
        {
            Transform vfx = GetAvailableHitGo();
            if(vfx == null)
            {
                vfx = GameObject.Instantiate(hitPrefab, this.transform);
                hitsGo.Add(vfx);
            }
            else
            {
                vfx.gameObject.SetActive(true);
            }
            vfx.position = pos;
        }

        private Transform GetAvailableHitGo()
        {
            foreach(Transform go in hitsGo)
            {
                if(!go.gameObject.activeSelf)
                {
                    return go;
                }
            }
            return null;
        }
    }
}