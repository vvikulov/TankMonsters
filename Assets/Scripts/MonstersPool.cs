using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class MonstersPool : MonoBehaviour
    {
        #region Dependencies
        private Transform m_target;
        private Vector2 m_mapHalfSize;
        #endregion

        #region Fields
        [SerializeField]
        private Monster[] m_monsterPrefabs;
        [SerializeField]
        private int m_maxNumMonsters = 10;
        [SerializeField]
        private float m_offsetForSpawn = 3.5f;

        private Dictionary<MonsterType, List<Monster>> m_available;
        private int m_numMonstersOnScene;
        #endregion

        #region Public
        public void Init(Transform target, Vector2 mapHalfSize)
        {
            m_target = target;
            m_mapHalfSize = mapHalfSize;

            m_available = new Dictionary<MonsterType, List<Monster>>();

            for(int i = 0; i < (int)MonsterType.COUNT; i++)
            {
                m_available.Add((MonsterType)i, new List<Monster>(m_maxNumMonsters));
            }

            while(m_numMonstersOnScene < m_maxNumMonsters)
            {
                SpawnMonster();
            }
        }

        public void MakeMonsterAvailable(Monster monster)
        {
            m_available[monster.MonsterType].Add(monster);
            m_numMonstersOnScene--;
            if(m_numMonstersOnScene < m_maxNumMonsters)
            {
                SpawnMonster();
            }
        }
        #endregion

        #region Helpers
        private void SpawnMonster()
        {
            MonsterType monsterType = (MonsterType)Random.Range(0, (int)MonsterType.COUNT);
            List<Monster> available = m_available[monsterType];

            Monster monster = null;

            if(available.Count > 0)
            {
                monster = available[0];
                available.RemoveAt(0);

            }
            else
            {
                monster = CreateMonster(monsterType);
            }

            monster.SetPos(GetRandomSpawnPos());
            monster.gameObject.SetActive(true);

            m_numMonstersOnScene++;

            monster.StartMoveTowards(m_target);
        }

        private Monster CreateMonster(MonsterType monsterType)
        {
            Monster monster = GameObject.Instantiate(
                m_monsterPrefabs[(int)monsterType], this.transform, false);
            monster.Init(this);

            return monster;
        }
        #endregion

        private Vector2 GetRandomSpawnPos()
        {
            int randSide = Random.Range(0, 4);
            Vector2 randPos = new Vector2();

            switch(randSide)
            {
                case 0://top
                    randPos.x = Random.Range(-m_mapHalfSize.x, m_mapHalfSize.x);
                    randPos.y = m_mapHalfSize.y + m_offsetForSpawn;
                    break;
                case 1://bottom
                    randPos.x = Random.Range(-m_mapHalfSize.x, m_mapHalfSize.x);
                    randPos.y = -m_mapHalfSize.y - m_offsetForSpawn;
                    break;
                case 2://left
                    randPos.x = -m_mapHalfSize.x - m_offsetForSpawn;
                    randPos.y = Random.Range(-m_mapHalfSize.y, m_mapHalfSize.y);
                    break;
                case 3://right
                    randPos.x = m_mapHalfSize.x + m_offsetForSpawn;
                    randPos.y = Random.Range(-m_mapHalfSize.y, m_mapHalfSize.y);
                    break;
                default:
                    break;
            }
            return randPos;
        }
    }
}