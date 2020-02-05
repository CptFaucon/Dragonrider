using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private EnemyManager em;
    public Spawner[] spawners;


    private void Awake()
    {
        em = FindObjectOfType<EnemyManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        foreach (var spawn in spawners)
        {
            em.SpawnEnemy(spawn.enemyType, spawn.transform.position, spawn.path);
        }
    }
}
