using UnityEngine;

public class AI : MonoBehaviour
{
    public Rigidbody2D AIRB;
    public float AIMaxMoveSpeed;
    public float AIEasyMoveSpeed;
    public float AIMediumMoveSpeed;
    public float AIHardMoveSpeed;
    public float AIMaxMoveSpeedPercentage;
    Vector2 StartPos;
    public Rigidbody2D PuckRB;
    public Transform AIPlayerBoundaries;
    private Boundary AIPlayerBounds;
    public Transform PuckBoundaries;
    private Boundary PuckBounds;
    public Vector2 TargetPos;
    public bool IsFirstTimeInOpponentHalf = true;
    public float XOffset;
    public float MinXOffset;
    public float MaxXOffset;

    private void Start()
    {
        AIRB = GetComponent<Rigidbody2D>();
        StartPos = AIRB.position;
        AIPlayerBounds = new Boundary(AIPlayerBoundaries.GetChild(0).position.y, AIPlayerBoundaries.GetChild(1).position.y,
            AIPlayerBoundaries.GetChild(2).position.x, AIPlayerBoundaries.GetChild(3).position.x);
        PuckBounds = new Boundary(PuckBoundaries.GetChild(0).position.y, PuckBoundaries.GetChild(1).position.y,
            PuckBoundaries.GetChild(2).position.x, PuckBoundaries.GetChild(3).position.x);

        switch (GameValues.Difficulty)
        {
            case GameValues.Difficulties.Easy:
                AIMaxMoveSpeed = AIEasyMoveSpeed;
                break;

            case GameValues.Difficulties.Medium:
                AIMaxMoveSpeed = AIMediumMoveSpeed;
                break;

            case GameValues.Difficulties.Hard:
                AIMaxMoveSpeed = AIHardMoveSpeed;
                break;
        }
    }

    private void FixedUpdate()
    {
        float MoveSpeed;

        if (PuckRB.position.y < PuckBounds.Down)
        {
            if (IsFirstTimeInOpponentHalf)
            {
                IsFirstTimeInOpponentHalf = false;
                XOffset = Random.Range(MinXOffset, MaxXOffset);
            }
            MoveSpeed = AIMaxMoveSpeed * Random.Range(0.1f, 0.3f);
            TargetPos = new Vector2(Mathf.Clamp(PuckRB.position.x + XOffset, AIPlayerBounds.Left, AIPlayerBounds.Right),
                StartPos.y);
        }
        else
        {
            MoveSpeed = Random.Range(AIMaxMoveSpeed * AIMaxMoveSpeedPercentage, AIMaxMoveSpeed);
            TargetPos = new Vector2(Mathf.Clamp(PuckRB.position.x, AIPlayerBounds.Left, AIPlayerBounds.Right),
                Mathf.Clamp(PuckRB.position.y, AIPlayerBounds.Down, AIPlayerBounds.Up));
        }
        if (PuckRB.position.y > transform.position.y)
        {
            MoveSpeed = Random.Range(AIMaxMoveSpeed * AIMaxMoveSpeedPercentage, AIMaxMoveSpeed);
            TargetPos = new Vector2(Mathf.Clamp(PuckRB.position.x + XOffset, AIPlayerBounds.Left, AIPlayerBounds.Right),
                Mathf.Clamp(PuckRB.position.y, AIPlayerBounds.Down, AIPlayerBounds.Up));
        }

        AIRB.MovePosition(Vector2.MoveTowards(AIRB.position, TargetPos, MoveSpeed * Time.fixedDeltaTime));
    }
}
