using UnityEngine;
using System;
using System.Collections;

public class PathMovement : MonoBehaviour
{
    private CameraController cam;
    public PathManager PathToFollow;

    [HideInInspector]
    public int CurrentWayPointID;
    private float reachDistance = 1.0f;

    public float speed = 2f;
    public float rotationSpeed = 2f;

    private void Awake()
    {
        cam = FindObjectOfType<CameraController>();
    }

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

                float distanceY = PathToFollow.pathTransforms[CurrentWayPointID].position.y - PathToFollow.pathTransforms[CurrentWayPointID - 1].position.y;
                cam.ChangeFollowedPosition(distanceY > 0
                    ? 2
                    : (int)Mathf.Sign(distanceY) + 1);
            }
        }
    }


    public void ChangeSpeed(float newSpeed, float lerpSpeed, bool isStopping, float stoppedTime)
    {
        if (!isStopping)
        {
            StartCoroutine(LerpSpeed(newSpeed, lerpSpeed));
        }
        else
        {
            StartCoroutine(StopToFollow(newSpeed, lerpSpeed, stoppedTime));
        }
    }


    private IEnumerator StopToFollow(float newSpeed, float lerpSpeed, float stoppedTime)
    {
        yield return LerpSpeed(0, lerpSpeed);
        yield return new WaitForSeconds(stoppedTime);
        yield return LerpSpeed(newSpeed, lerpSpeed);
        yield break;
    }


    private IEnumerator LerpSpeed(float newSpeed, float lerpSpeed)
    {
        float limit = Mathf.Abs(speed - newSpeed) / 100;
        while (Mathf.Abs(speed - newSpeed) >= limit)
        {
            speed = Mathf.Lerp(speed, newSpeed, lerpSpeed);
            yield return new WaitForFixedUpdate();
        }
        yield break;
    }

    public void SpeedModification(float modifier)
    {
        speed = modifier;
    }
}
 