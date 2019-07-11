using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class CameraController : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Camera m_camera;
        [SerializeField]
        private Transform m_tank;
        [SerializeField]
        private Map m_map;

        private Vector2 m_minPos;
        private Vector2 m_maxPos;
        #endregion

        #region Unity Events
        private void Start()
        {
            Vector2 viewSize = new Vector2(m_camera.orthographicSize * m_camera.aspect, m_camera.orthographicSize);

            Vector2 mapSize = m_map.MapHalfSize;

            m_minPos = new Vector2(-mapSize.x + viewSize.x, -mapSize.y + viewSize.y);
            m_maxPos = new Vector2(mapSize.x - viewSize.x, mapSize.y - viewSize.y);
        }

        private void LateUpdate()
        {
            Vector3 newPos = m_tank.position;
            newPos = new Vector3(Mathf.Clamp(newPos.x, m_minPos.x, m_maxPos.x),
                Mathf.Clamp(newPos.y, m_minPos.y, m_maxPos.y), transform.position.z);

            transform.position = newPos;
        }
        #endregion
    }
}