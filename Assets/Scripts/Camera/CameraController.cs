using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    private Transform body;
    private Transform follow;

    [Header("   Position of the Object ToFollow relative to PlayerBody")]
    [Tooltip("Offset when the Player goes forward")]
    [SerializeField]
    private Vector3 defaultOffset = new Vector3(0, 1, -6);

    [Tooltip("Offset when the Player goes toward the ground")]
    [SerializeField]
    private Vector3 divingOffset = new Vector3(0, 1.5f, -7);

    [Tooltip("Offset when the Player goes to the sky")]
    [SerializeField]
    private Vector3 flyingOffset = new Vector3(0, .5f, -5);


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
        follow.localPosition = defaultOffset;
    }


    private void FollowPlayer()
    {
        transform.LookAt(body);

        Vector3 position = transform.position;
        Vector3 desiredPosition = follow.position;
        position = Vector3.Lerp(position, desiredPosition, lerpSpeed);

        transform.position = position;
    }

    public void ChangeFollowedPosition(int position)
    {
        Vector3[] positions = new Vector3[3] { divingOffset, defaultOffset, flyingOffset };
        follow.localPosition = positions[position];
    }


    void Update()
    {
        FollowPlayer();
    }
}
