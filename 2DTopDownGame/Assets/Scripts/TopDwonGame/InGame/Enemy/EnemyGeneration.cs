using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InGame.Enemy
{
    public class EnemyGeneration : MonoBehaviour
    {
        [SerializeField] GameObject Enemy;
        [SerializeField] List<Transform> generationPoints = new List<Transform>();
        [Header("�G�𐶐�����Ԋu(�b)")][SerializeField] float spawnInterval;
        [Header("�ő吶����")][SerializeField] int maxEnemies;
        private List<GameObject> spawnedEnemies = new List<GameObject>();

        private void Start()
        {
            if (Enemy != null)
            {
                StartCoroutine(SpawnEnemyRoutine());
            }
        }

        private IEnumerator SpawnEnemyRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnInterval);

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
            int randomIndex = Random.Range(0, generationPoints.Count);
            Transform spawnPoint = generationPoints[randomIndex];

            // �G�𐶐�
            GameObject newEnemy = Instantiate(Enemy, spawnPoint.position, spawnPoint.rotation);
            spawnedEnemies.Add(newEnemy);
        }
        private void CheckAllEnemiesInactive()
        {
            bool allInactive = true;
            foreach (GameObject enemy in spawnedEnemies)
            {
                if (enemy.activeSelf)
                {
                    allInactive = false;
                    break;
                }
            }

            if (allInactive)
            {
                FindObjectOfType<SceneController>().Result();
            }
        }
    }
}