using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public PathManager PathToFollow;

    public int CurrentWayPointID = 0;
    public float speed;
    private float reachDistance = 1.0f;
    public float rotationSpeed;
    //public string pathName;

    //Vector3 lastPosition;
    //Vector3 currentPosition;

    private void Start()
    {
        //PathToFollow = GameObject.Find(pathName).GetComponent<PathManager> ();
        //lastPosition = transform.position;
    }

    private void Update()
    {
        float distance = Vector3.Distance(PathToFollow.pathTransforms[CurrentWayPointID].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathTransforms[CurrentWayPointID].position, Time.deltaTime * speed);

        var rotation = Quaternion.LookRotation(PathToFollow.pathTransforms[CurrentWayPointID].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if(distance <= reachDistance)
        {
            CurrentWayPointID++;
        }

        if (CurrentWayPointID >= PathToFollow.pathTransforms.Count)
        {
            //gameObject.SetActive(false);
        }
    }
}
 