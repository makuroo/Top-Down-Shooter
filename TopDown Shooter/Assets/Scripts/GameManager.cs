using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace MyCode
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public GameObject activePlayer;
        public GameObject playerPrefab;
        public bool isPlaying;
        public UnityAction OnGameOverAction;
        public ScriptableInteger life;
        public ScriptableInteger coin;
        public EnemySpawner spawner;
        /////list untuk menampung item coin life dkk
        public List<GameObject> items;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public static GameManager GetInstance()
        {
            return instance;
        }

        void Start()
        {
            
        }
        private void spawnPlayer()
        {
            activePlayer = Instantiate(playerPrefab);
        }

        //mendapatkan poosisi transform player
        public Vector3 getPlayerPosition()
        {
            if (activePlayer != null)
            {
                return activePlayer.transform.position;
            }
            return Vector3.zero;
        }


        public void startGame()
        {
            isPlaying = true;
            spawnPlayer();
        }

        public void resumeGame()
        {
            isPlaying = true;
            Time.timeScale = 1;
        }

        public void pauseGame()
        {
            isPlaying = false;
            Time.timeScale = 0;
        }
        internal void gameOver()
        {
            isPlaying = false;
            OnGameOverAction?.Invoke();
        }


        internal void retry()
        {
            life.reset();
            coin.reset();
            spawner.clearEnemies(); //destroy semua emeny
            ObjectPool.GetInstance().deactivateAllObject(); //clear pool objects
            clearAllItem();
        }

        internal void addItem(GameObject gameObject)
        {
            items.Add(gameObject);
        }

        public void clearAllItem()
        {
            foreach (GameObject go in items)
            {
                Destroy(go);
            }
            items.Clear();
        }
    }
}
