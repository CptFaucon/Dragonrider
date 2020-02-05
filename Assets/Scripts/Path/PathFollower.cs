using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(PathMovement))]

public class PathFollower : MonoBehaviour
{
    private PathMovement pm;
    public Action OnFinishedPath;


    public virtual void Awake()
    {
        pm = GetComponent<PathMovement>();
    }


    public virtual void Update()
    {
        pm.FollowPath(OnFinishedPath);
    }
}
