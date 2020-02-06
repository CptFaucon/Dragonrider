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
        Debug.Log("disabled");
        pm.CurrentWayPointID = 0;
        gameObject.SetActive(false);
    }
}
