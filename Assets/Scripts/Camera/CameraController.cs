using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    [Header("   Movement Zone")]
    [SerializeField]
    private float limit = 4;

    [Space]
    [Tooltip("Camera Offset on Y-Axis")]
    [SerializeField]
    private float offsetY;
    [Tooltip("Camera Offset on Z-Axis")]
    [SerializeField]
    private float offsetZ = -8;

    [Header("   Move")]
    [Range(0, 1)]
    [SerializeField]
    private float lerpSpeed = .05f;

    private PlayerController pc;
    #endregion


    private void Awake()
    {
        pc = FindObjectOfType<PlayerController>();
    }


    private void FollowPlayer()
    {
        Vector3 position = transform.localPosition;
        Vector2 desiredPosition = pc.gameObject.transform.localPosition;

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, -limit / 2, limit / 2);

        position = Vector3.Lerp(position, desiredPosition, lerpSpeed);
        position.z = offsetZ;

        transform.localPosition = position;
    }


    void Update()
    {
        FollowPlayer();
    }
}
