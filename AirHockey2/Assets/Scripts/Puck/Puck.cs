using System.Collections;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public GameManager GM;
    public bool GoalScored;
    Rigidbody2D PuckRB;
    public float ResetTime;
    public float GoalResetTime;
    public float MaxPuckSpeed;
    public AI PlayerAI;
    public AudioManager AM;
    void Start()
    {
        PuckRB = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player 1 Goal"))
        {
            Debug.Log("Player 2 Scored");
            GM.UpdatePlayer2Score();
            AM.PlayGoalSound();
            GoalScored = true;
            StartCoroutine(ResetPuckAfterGoal(true));
        }
        else if (collision.gameObject.CompareTag("Player 2 Goal"))
        {
            Debug.Log("Player 1 Scored");
            GM.UpdatePlayer1Score();
            AM.PlayGoalSound();
            GoalScored = true;
            StartCoroutine(ResetPuckAfterGoal(false));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AM.PlayPuckCollision();
    }

    public IEnumerator ResetPuckAfterGoal(bool DidPlayer2Score)
    {
        yield return new WaitForSeconds(GoalResetTime);

        GoalScored = false;
        PuckRB.linearVelocity = PuckRB.position = new Vector2 (0, 0);
        if (DidPlayer2Score)
        {
            PuckRB.position = new Vector2(0, -1);
        }
        else
        {
            PuckRB.position = new Vector2(0, 1);
        }
    }

    public IEnumerator ResetPuck()
    {
        yield return new WaitForSeconds(ResetTime);

        PuckRB.position = new Vector2(0, -1);
    }

    private void FixedUpdate()
    {
        PuckRB.linearVelocity = Vector2.ClampMagnitude(PuckRB.linearVelocity, MaxPuckSpeed);
        
        /*if(PuckRB.position.y > PlayerAI.AIRB.position.y && !GoalScored)
        {
            Debug.Log("Puck is Behind AI");
            StartCoroutine(ResetPuck());
        }*/
    }
}
