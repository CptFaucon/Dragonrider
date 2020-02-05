using UnityEngine;
using System;

public class EnemyScript : PathFollower
{

    public override void Awake()
    {
        base.Awake();
        OnFinishedPath += DisableEnemy;
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
