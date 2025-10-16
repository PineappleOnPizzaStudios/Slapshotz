using UnityEngine;
using Lean.Touch;

public class PlayerMovement : MonoBehaviour
{
    public bool CanMove;
    public Collider2D PlayerCollider { get; private set; }
    Rigidbody2D PlayerRB;
    public PlayerController PC;
    public Transform Boundaries;
    Boundary PlayerBounds;

    public int? LockedFingerID { get; set; }

    void Start()
    {
        PlayerCollider = GetComponent<Collider2D>();
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerBounds = new Boundary(
            Boundaries.GetChild(0).position.y,
            Boundaries.GetChild(1).position.y,
            Boundaries.GetChild(2).position.x,
            Boundaries.GetChild(3).position.x
        );
    }

    void Update()
    {
//#if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseInput();
//#endif
    }

    private void HandleMouseInput()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // When the left mouse button is first pressed
        if (Input.GetMouseButtonDown(0))
        {
            if (PlayerCollider.OverlapPoint(mousePos))
            {
                LockedFingerID = 0; // Treat mouse as "finger 0"
                CanMove = true;
            }
        }

        // While holding mouse
        if (Input.GetMouseButton(0) && LockedFingerID == 0 && CanMove)
        {
            MoveToPosition(mousePos);
        }

        // When mouse released
        if (Input.GetMouseButtonUp(0))
        {
            if (LockedFingerID == 0)
            {
                LockedFingerID = null;
                CanMove = false;
            }
        }
    }

    public void MoveToPosition(Vector2 position)
    {
        Vector2 clampedPos = new Vector2(
            Mathf.Clamp(position.x, PlayerBounds.Left, PlayerBounds.Right),
            Mathf.Clamp(position.y, PlayerBounds.Down, PlayerBounds.Up)
        );

        PlayerRB.MovePosition(clampedPos);
    }

    private void OnEnable()
    {
        PC.Players.Add(this);
    }

    private void OnDisable()
    {
        PC.Players.Remove(this);
    }
}
