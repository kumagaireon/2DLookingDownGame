using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InGame.Enemy
{
    public class EnemyGeneration : MonoBehaviour
    {
        [SerializeField] GameObject Enemy;
        [SerializeField] List<Transform> generationPoints = new List<Transform>();
        [Header("敵を生成する間隔(秒)")][SerializeField] float spawnInterval;
        [Header("最大生成数")][SerializeField] int maxEnemies;
        private List<GameObject> spawnedEnemies = new List<GameObject>();
        private bool stopSpawning = false;
        private void Start()
        {
            if (Enemy != null)
            {
                SpawnEnemyRoutine().Forget();
                stopSpawning = false;
            }
        }

        private void OnDestroy()
        {
            // シーン遷移時にリストをクリア
            spawnedEnemies.Clear();
            generationPoints.Clear();
        }

        private async UniTaskVoid SpawnEnemyRoutine()
        {
            while (!stopSpawning)
            {
                await UniTask.Delay((int)(spawnInterval * 1000));

                if (generationPoints.Count == 0)
                {
                    stopSpawning = true;
                    break;
                }

                if (spawnedEnemies.Count < maxEnemies)
                {
                    SpawnEnemy();
                }
                CheckAllEnemiesInactive();
            }
        }

        private void SpawnEnemy()
        {
            // ランダムな生成ポイントを選択
            int randomIndex = UnityEngine.Random.Range(0, generationPoints.Count);
            Transform spawnPoint = generationPoints[randomIndex];

            // 生成ポイントが存在するかチェック
            if (spawnPoint != null)
            {
                // 敵を生成
                GameObject newEnemy = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
                spawnedEnemies.Add(newEnemy);
            }
        }

        private void CheckAllEnemiesInactive()
        {
            bool allInactive = true;
            for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
            {
                if (spawnedEnemies[i] == null)
                {
                    // 破棄されたオブジェクトをリストから削除
                    spawnedEnemies.RemoveAt(i);
                }
                else if (spawnedEnemies[i].activeSelf)
                {
                    allInactive = false;
                }
            }

            if (allInactive)
            {
                FindObjectOfType<SceneController>().Result();
            }
        }
    }
}