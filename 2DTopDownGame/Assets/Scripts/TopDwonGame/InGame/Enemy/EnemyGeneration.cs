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
        [Header("�G�𐶐�����Ԋu(�b)")][SerializeField] float spawnInterval;
        [Header("�ő吶����")][SerializeField] int maxEnemies;
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
            // �V�[���J�ڎ��Ƀ��X�g���N���A
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
            // �����_���Ȑ����|�C���g��I��
            int randomIndex = UnityEngine.Random.Range(0, generationPoints.Count);
            Transform spawnPoint = generationPoints[randomIndex];

            // �����|�C���g�����݂��邩�`�F�b�N
            if (spawnPoint != null)
            {
                // �G�𐶐�
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
                    // �j�����ꂽ�I�u�W�F�N�g�����X�g����폜
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