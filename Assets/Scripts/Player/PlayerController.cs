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

    [Header("Pause Input")]
    [SerializeField]
    private KeyCode pauseInput;

    [HideInInspector]
    public bool isOnPause;
    private ScoreManager sm;
    #endregion


    public override void Awake()
    {
        base.Awake();
        sm = FindObjectOfType<ScoreManager>();
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
        sm.AtRunEnd();
        enabled = false;
    }


    public override void Update()
    {
        if (!isOnPause) {

            base.Update();
            Movement();
            if (Input.GetKeyUp(pauseInput)) {

                isOnPause = true;
            }
        }
        else {

            if (Input.GetKeyDown(pauseInput)) {

                isOnPause = false;
            }
        }
    }
}
