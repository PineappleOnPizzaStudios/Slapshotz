using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    public List<PlayerMovement> Players = new List <PlayerMovement>();


    void Update()
    {
        
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 TouchWorldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

            foreach (var Player in Players)
            {
                if(Player.LockedFingerID == null)
                {
                    if(Input.GetTouch(i).phase == TouchPhase.Began && Player.PlayerCollider.OverlapPoint(TouchWorldPos))
                    {
                        Player.LockedFingerID = Input.GetTouch(i).fingerId;
                    }
                }
                else if (Player.LockedFingerID == Input.GetTouch(i).fingerId)
                {
                    Player.MoveToPosition(TouchWorldPos);
                    Debug.Log("Touch Move");
                    if (Input.GetTouch(i).phase == TouchPhase.Ended || Input.GetTouch(i).phase == TouchPhase.Canceled)
                    {
                        Debug.Log("Finger ID cleared");
                        Player.LockedFingerID = null;

                    }
                }
            }
        }
    }
}
