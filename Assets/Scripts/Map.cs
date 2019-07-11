using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class Map : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private SpriteRenderer m_map;
        [SerializeField]
        private Collider2D[] m_borders;
        #endregion

        public Vector2 MapHalfSize { get; private set; }

        #region Unity Events
        private void Awake()
        {
            MapHalfSize = new Vector2(m_map.bounds.size.x / 2.0f, m_map.bounds.size.y / 2.0f);

            Vector2 newPos = Vector2.zero;

            for(int i = 0; i < m_borders.Length; i++)
            {
                Collider2D collider = m_borders[i];
                Vector3 size = collider.bounds.size;
                Vector3 newScale = collider.transform.localScale;

                switch(i)
                {
                    case 0://top
                        newPos.x = 0.0f;
                        newPos.y = MapHalfSize.y + size.y / 2.0f;
                        newScale.x = MapHalfSize.x * 2.0f / size.x;
                        break;
                    case 1://bottom
                        newPos.x = 0.0f;
                        newPos.y = -MapHalfSize.y - size.y / 2.0f;
                        newScale.x = MapHalfSize.x * 2.0f / size.x;
                        break;
                    case 2://left
                        newPos.x = -MapHalfSize.x - size.x / 2.0f;
                        newPos.y = 0.0f;
                        newScale.y = MapHalfSize.y * 2.0f / size.y;
                        break;
                    case 3://right
                        newPos.x = MapHalfSize.x + size.x / 2.0f;
                        newPos.y = 0.0f;
                        newScale.y = MapHalfSize.y * 2.0f / size.y;
                        break;
                    default:
                        break;
                }

                collider.transform.position = newPos;
                collider.transform.localScale = newScale;
            }
        }
        #endregion
    }
}