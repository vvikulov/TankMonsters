﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class TankDamageReceiver : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private float m_immortalTime = 3.0f;//sec
        [SerializeField]
        private float m_immortalColorA = 0.5f;
        [SerializeField]
        private float m_normalColorA = 1.0f;
        [SerializeField]
        private TankHealth m_tankHealth;

        private bool m_isImmortal;
        private List<SpriteRenderer> m_spriteRenderers;
        private List<Collider2D> m_colliders;
        #endregion

        #region Unity Events
        private void Awake()
        {
            m_spriteRenderers = new List<SpriteRenderer>();
            SearchForComponentRecursively<SpriteRenderer>(m_spriteRenderers, this.transform);

            m_colliders = new List<Collider2D>();
            SearchForComponentRecursively<Collider2D>(m_colliders, this.transform);
        }
        #endregion

        private void SearchForComponentRecursively<T>(List<T> list, Transform t) where T : Component
        {
            list.AddRange(t.GetComponentsInChildren<T>(true));

            foreach(Transform child in t)
            {
                SearchForComponentRecursively<T>(list, child);
            }
        }

        private void MakeImmortalColor(bool isImmortal)
        {
            Color newColor;
            float newA = isImmortal ? m_immortalColorA : m_normalColorA;
            foreach(SpriteRenderer spriteRenderer in m_spriteRenderers)
            {
                newColor = spriteRenderer.color;
                newColor.a = newA;
                spriteRenderer.color = newColor;
            }
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if(!m_isImmortal && collision.gameObject.layer == Constants.Layers.MONSTERS)
            {
                VFXManager.Instance.ShowHit(collision.GetContact(0).point);
                m_tankHealth.RemoveHealth(collision.gameObject.GetComponent<Monster>().Damage);
                SetIsImmortal(true);
                StartCoroutine(MakeMortalAfterDelay(m_immortalTime));
            }
        }

        private IEnumerator MakeMortalAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            SetIsImmortal(false);
        }

        private void SetIsImmortal(bool isImmortal)
        {
            m_isImmortal = isImmortal;

            if(isImmortal)
            {
                ChangeLayerOfColliders(Constants.Layers.DEFAULT);
            }
            else
            {
                ChangeLayerOfColliders(Constants.Layers.PLAYER);
            }
            MakeImmortalColor(isImmortal);
        }

        private void ChangeLayerOfColliders(int layer)
        {
            foreach(Collider2D collider in m_colliders)
            {
                collider.gameObject.layer = layer;
            }
        }
    }
}