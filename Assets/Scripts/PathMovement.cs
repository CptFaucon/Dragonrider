using UnityEngine;

public class PathMovement : MonoBehaviour
{
    public PathManager PathToFollow;

    private int CurrentWayPoint;

    public float speed;
    public float rotationSpeed;

    private void Update()
    {
        float distance = Vector3.Distance(PathToFollow.pathTransforms[CurrentWayPoint].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathTransforms[CurrentWayPoint].position, Time.deltaTime * speed);

        var rotation = Quaternion.LookRotation(PathToFollow.pathTransforms[CurrentWayPoint].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        if(distance <= 1)
        {
            CurrentWayPoint++;
        }

        if (CurrentWayPoint >= PathToFollow.pathTransforms.Count)
        {
            //gameObject.SetActive(false);
        }
    }
}