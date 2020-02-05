using UnityEngine;

public class PlayerController : PathFollower
{
    #region Variables
    [Header("   Movement Zone")]
    [SerializeField]
    private GameObject body;

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


    public override void Awake()
    {
        base.Awake();
        OnFinishedPath += EndPath;
    }


    private void Movement()
    {
        /// Accelerate or decelerate
        moveSpeed = Mathf.Clamp(Mathf.Lerp(moveSpeed, maxMoveSpeed * Input.GetAxisRaw("Horizontal"), lerpMoveSpeed), -maxMoveSpeed, maxMoveSpeed);
        
        /// Move between limits
        Vector2 position = body.transform.localPosition;
        position.x = Mathf.Clamp(position.x + moveSpeed * Time.deltaTime, -limit / 2, limit / 2);

        body.transform.localPosition = position;
    }


    public void EndPath()
    {
        Debug.Log("Path Followed");
    }


    public override void Update()
    {
        base.Update();
        Movement();
    }
}
