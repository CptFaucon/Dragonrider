using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpeedTrigger : MonoBehaviour
{
    private PathMovement pm;

    [SerializeField]
    private float newSpeed;
    [SerializeField]
    private float lerpSpeed = .08f;
    [SerializeField]
    private float stoppedTime;
    [SerializeField]
    private bool isStopping;


    private void Awake()
    {
        pm = FindObjectOfType<PlayerController>().pm;
    }


    private void OnTriggerEnter(Collider other)
    {
        pm.ChangeSpeed(newSpeed, lerpSpeed, isStopping, stoppedTime);
    }
}
