using UnityEngine;

public class DisableEnemy : Hittable
{
    [HideInInspector]
    public Enemy parent;

    public override void OnHit()
    {
        parent.EndLife();
    }
}
