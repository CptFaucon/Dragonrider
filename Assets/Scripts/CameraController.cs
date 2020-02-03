using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Variables
    [Header("   Movement Zone")]
    [SerializeField]
    private float limitX;
    [SerializeField]
    private float limitY;

    [Space]
    [Tooltip("Camera Offset on Z-Axis")]
    [SerializeField]
    private float offset;

    [Header("   Move")]
    [Range(0, 1)]
    [SerializeField]
    private float lerpSpeed;

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

        desiredPosition.x = Mathf.Clamp(desiredPosition.x, -limitX / 2, limitX / 2);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, -limitY / 2, limitY / 2);

        position = Vector3.Lerp(position, desiredPosition, lerpSpeed);
        position.z = -offset;

        transform.localPosition = position;
    }


    void Update()
    {
        FollowPlayer();
    }
}
