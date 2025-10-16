using UnityEngine;

[System.Serializable]
public class SkinInformation
{
    [Header("Background")]
    public string BackgroundName;
    public Sprite BackgroundSprite;
    public Sprite BackgroundBorder1Sprite;
    public Sprite BackgroundBorder2Sprite;

    [Header("Paddles and Puck")]

    public Sprite Player1PaddleSprite;
    public Sprite Player2PaddleSprite;
    public Sprite PuckSprite;
}
