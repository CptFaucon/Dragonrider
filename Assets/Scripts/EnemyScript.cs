using UnityEngine;
using System;

public class EnemyScript : MonoBehaviour
{
    public Action OnfinishedPath;

    private void Awake()
    {
        OnfinishedPath += DisableEnemy;
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
