using UnityEngine;
using System;

public class PathMovement : MonoBehaviour
{
    public PathManager PathToFollow;

    private int CurrentWayPointID;
    private float reachDistance = 1.0f;

    public float speed = 2f;
    public float rotationSpeed = 2f;
    
    

    public void FollowPath(Action OnFinishedPath)
    {
        if (CurrentWayPointID >= PathToFollow.pathTransforms.Count)
        {
            OnFinishedPath.Invoke();
        }

        else
        {
            float distance = Vector3.Distance(PathToFollow.pathTransforms[CurrentWayPointID].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathTransforms[CurrentWayPointID].position, Time.deltaTime * speed);

            var rotation = Quaternion.LookRotation(PathToFollow.pathTransforms[CurrentWayPointID].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

            if (distance <= reachDistance)
            {
                CurrentWayPointID++;
            }
        }
    }
}
 