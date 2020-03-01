using UnityEngine;

public class EnemyDisabler : MonoBehaviour
{
    public void DisableEnemy()
    {
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
