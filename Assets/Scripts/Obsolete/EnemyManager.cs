using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    #region Variables
    private GameObject[,] EnemiesArrays;

    [SerializeField]
    private GameObject[] Enemies;
    [SerializeField]
    private int maxNbOfEnemies;

    private int[] currentEnemy;
    #endregion

    
    private void Awake()
    {
        int enemies = Enemies.Length;
        currentEnemy = new int[enemies];

        EnemiesArrays = new GameObject[enemies, maxNbOfEnemies];

        for (int i = 0; i < enemies; i++)
        {
            for (int j = 0; j < maxNbOfEnemies; j++)
            {
                EnemiesArrays[i, j] = Instantiate(Enemies[i]);
                EnemiesArrays[i, j].SetActive(false);
            }
        }
    }


    public void SpawnEnemy(int enemyType, Vector3 spawnPosition, PathManager path)
    {
        EnemiesArrays[enemyType, currentEnemy[enemyType]].GetComponent<PathMovement>().PathToFollow = path;
        EnemiesArrays[enemyType, currentEnemy[enemyType]].transform.position = spawnPosition;
        EnemiesArrays[enemyType, currentEnemy[enemyType]].SetActive(true);
        currentEnemy[enemyType] = (currentEnemy[enemyType] + 1) % maxNbOfEnemies;
    }
}
