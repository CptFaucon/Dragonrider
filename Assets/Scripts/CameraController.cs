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
    [Tooltip("Camera Offset on Y-Axis")]
    [SerializeField]
    private float offsetY;
    [Tooltip("Camera Offset on Z-Axis")]
    [SerializeField]
    private float offsetZ;

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
        desiredPosition.y = Mathf.Clamp(desiredPosition.y + offsetY, -limitY / 2 + offsetY, limitY / 2 + offsetY);

        position = Vector3.Lerp(position, desiredPosition, lerpSpeed);
        position.z = offsetZ;

        transform.localPosition = position;
    }


    void Update()
    {
        FollowPlayer();
    }
}
