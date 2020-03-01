using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    [SerializeField]
    private Transform body;
    [SerializeField]
    private Transform follow;

    [Header("   Position of the Object ToFollow relative to PlayerBody")]
    [Tooltip("Offset on Y-Axis")]
    [SerializeField]
    private float offsetY = 1;
    [Tooltip("Offset on Z-Axis")]
    [SerializeField]
    private float offsetZ = -8;

    [Header("   Move")]
    [Range(0, 1)]
    [SerializeField]
    private float lerpSpeed = .05f;

    #endregion

    private void Awake()
    {
        PlayerController pc = FindObjectOfType<PlayerController>();
        body = pc.transform.Find("PlayerBody");
        follow = body.transform.Find("ToFollow");
        follow.localPosition = new Vector3(0, offsetY, offsetZ);
    }


    private void FollowPlayer()
    {
        transform.LookAt(body);

        Vector3 position = transform.position;
        Vector3 desiredPosition = follow.position;
        position = Vector3.Lerp(position, desiredPosition, lerpSpeed);

        transform.position = position;
    }


    void Update()
    {
        FollowPlayer();
    }
}
