using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("   Movement Zone")]
    [Tooltip("Lenght of the zone where the player can move")]
    [SerializeField]
    private float limit = 16;

    [Header("   Move Speed")]
    [SerializeField]
    private float maxMoveSpeed = 5;
    [Range(0, 1)]
    [SerializeField]
    private float lerpMoveSpeed = .08f;

    private float moveSpeed;
    #endregion


    private void Movement()
    {
        /// Accelerate or decelerate
        moveSpeed = Mathf.Clamp(Mathf.Lerp(moveSpeed, maxMoveSpeed * Input.GetAxisRaw("Horizontal"), lerpMoveSpeed), -maxMoveSpeed, maxMoveSpeed);
        
        /// Move between limits
        Vector2 position = transform.localPosition;
        position.x = Mathf.Clamp(position.x + moveSpeed * Time.deltaTime, -limit / 2, limit / 2);

        transform.localPosition = position;
    }


    void Update()
    {
        Movement();
    }
}
