using UnityEngine;

public class EnemyDisabler : MonoBehaviour
{
    [HideInInspector]
    public Enemy parent;

    public void DisableEnemy()
    {
        parent.EndLife();
    }
}
