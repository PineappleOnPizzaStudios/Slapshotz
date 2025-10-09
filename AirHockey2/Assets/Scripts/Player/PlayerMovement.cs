using UnityEngine;
using Lean;
using Lean.Touch;

public class PlayerMovement : MonoBehaviour
{
    public bool WasClicked = true;
    public bool CanMove;
    public Collider2D PlayerCollider {  get; private set; }
    Rigidbody2D PlayerRB;
    public PlayerController PC;
    public Transform Boundaries;
    Boundary PlayerBounds;

    public int? LockedFingerID {  get; set; }


    void Start()
    {
        PlayerCollider = GetComponent<Collider2D>();
        PlayerRB = GetComponent<Rigidbody2D>();
        PlayerBounds = new Boundary(Boundaries.GetChild(0).position.y, Boundaries.GetChild(1).position.y,
            Boundaries.GetChild(2).position.x, Boundaries.GetChild(3).position.x);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Move();
        }
    }

    public void Move()
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (WasClicked)
        {
            WasClicked = false;

            if (PlayerCollider.OverlapPoint(MousePos))
            {
                CanMove = true;
            }
            else
            {
                CanMove = false;
            }

            if (CanMove)
            {
                Vector2 ClampMousePos = new Vector2(Mathf.Clamp(MousePos.x, PlayerBounds.Left, PlayerBounds.Right),
                    Mathf.Clamp(MousePos.y, PlayerBounds.Down, PlayerBounds.Up));
                PlayerRB.MovePosition(ClampMousePos);
            }
        }
        else
        {
            WasClicked = true;
        }
    }
    public void MoveToPosition (Vector2 Position)
    {
        Vector2 ClampMousePos = new Vector2(Mathf.Clamp(Position.x, PlayerBounds.Left, PlayerBounds.Right),
                    Mathf.Clamp(Position.y, PlayerBounds.Down, PlayerBounds.Up));
        PlayerRB.MovePosition(ClampMousePos);
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
