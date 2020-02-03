using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [Header("   Movement Zone")]
    [Tooltip("Lenght of the zone where the player can move")]
    [SerializeField]
    private float limitX;

    [Tooltip("Height of the zone where the player can move")]
    [SerializeField]
    private float limitY;

    [Header("   Move Speed")]
    [SerializeField]
    private float maxMoveSpeed;
    [Range(0, 1)]
    [SerializeField]
    private float lerpMoveSpeed;

    private float moveSpeedX, moveSpeedY;
    #endregion


    private void Movement()
    {
        /// Accelerate or decelerate
        Vector2 move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        moveSpeedX = Mathf.Clamp(Mathf.Lerp(moveSpeedX, maxMoveSpeed * move.x, lerpMoveSpeed), -maxMoveSpeed, maxMoveSpeed);
        moveSpeedY = Mathf.Clamp(Mathf.Lerp(moveSpeedY, maxMoveSpeed * move.y, lerpMoveSpeed), -maxMoveSpeed, maxMoveSpeed);
        
        /// Move between limits
        Vector2 position = transform.localPosition;
        position.x = Mathf.Clamp(position.x + moveSpeedX * Time.deltaTime, -limitX / 2, limitX / 2);
        position.y = Mathf.Clamp(position.y + moveSpeedY * Time.deltaTime, -limitY / 2, limitY / 2);

        transform.localPosition = position;
    }


    void Update()
    {
        Movement();
    }
}
