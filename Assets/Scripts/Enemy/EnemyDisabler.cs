using UnityEngine;

public class EnemyDisabler : Hittable
{
    [HideInInspector]
    public Enemy parent;

    public override void OnHit()
    {
        parent.EndLife();
    }
}
