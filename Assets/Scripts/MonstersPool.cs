using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankMGame
{
    public class MonstersPool : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        private Transform m_target;
        [SerializeField]
        private Monster[] m_monsterPrefabs;
        [SerializeField]
        private int m_maxNumMonsters = 10;
        [SerializeField]
        private Map m_map;

        private Dictionary<MonsterType, List<Monster>> m_available;
        private int m_numMonstersOnScene;
        #endregion

        #region Unity Events
        private void Awake()
        {
            m_available = new Dictionary<MonsterType, List<Monster>>();

            for(int i = 0; i < (int)MonsterType.COUNT; i++)
            {
                m_available.Add((MonsterType)i, new List<Monster>(m_maxNumMonsters));
            }
        }

        private void Start()
        {
            while(m_numMonstersOnScene < m_maxNumMonsters)
            {
                SpawnMonster();
            }
        }
        #endregion

        public void MakeMonsterAvailable(Monster monster)
        {
            m_available[monster.MonsterType].Add(monster);
            m_numMonstersOnScene--;
            if(m_numMonstersOnScene < m_maxNumMonsters)
            {
                SpawnMonster();
            }
        }

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

        private Vector2 GetRandomSpawnPos()
        {
            int randSide = Random.Range(0, 4);
            Vector2 randPos = new Vector2();
            const float OFFSET = 3.5f;

            Vector2 mapHalfSize = m_map.MapHalfSize;

            switch(randSide)
            {
                case 0://top
                    randPos.x = Random.Range(-mapHalfSize.x, mapHalfSize.x);
                    randPos.y = mapHalfSize.y + OFFSET;
                    break;
                case 1://bottom
                    randPos.x = Random.Range(-mapHalfSize.x, mapHalfSize.x);
                    randPos.y = -mapHalfSize.y - OFFSET;
                    break;
                case 2://left
                    randPos.x = -mapHalfSize.x - OFFSET;
                    randPos.y = Random.Range(-mapHalfSize.y, mapHalfSize.y);
                    break;
                case 3://right
                    randPos.x = mapHalfSize.x + OFFSET;
                    randPos.y = Random.Range(-mapHalfSize.y, mapHalfSize.y);
                    break;
                default:
                    break;
            }
            return randPos;
        }
    }
}