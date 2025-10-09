using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int Player1Score;
    public int Player2Score;
    public int Player1ScoreToWin;
    public int Player2ScoreToWin;
    public TMP_Text Player1ScoreText;
    public TMP_Text Player2ScoreText;
    public TMP_Text ScoreToWinText;
    public GameObject Player1WinScreen;
    public GameObject Player2WinScreen;
    public GameObject PauseButton;

    public GameObject SelectedBGSkin;
    public GameObject SelectedBorder1Skin;
    public GameObject SelectedBorder2Skin;
    public GameObject SelectedPaddle1Skin;
    public GameObject SelectedPaddle2Skin;
    public GameObject SelectedPuckSkin;
    public GameObject BGSkin;
    public GameObject Border1Skin;
    public GameObject Border2Skin;
    public GameObject Paddle1Skin;
    public GameObject Paddle2Skin;
    public GameObject PuckSkin;
    private Sprite BGSprite;
    private Sprite BGBorder1Sprite;
    private Sprite BGBorder2Sprite;
    private Sprite Paddle1Sprite;
    private Sprite Paddle2Sprite;
    private Sprite PuckSprite;

    void Start()
    {
        Player1WinScreen.SetActive(false);
        Player2WinScreen.SetActive(false);
        Player1ScoreToWin = GameValues.PointsToWin;
        Player2ScoreToWin = GameValues.PointsToWin;

        ScoreToWinText.text = "PTS TO WIN: " + GameValues.PointsToWin;

        BGSprite = SelectedBGSkin.GetComponent<SpriteRenderer>().sprite;
        BGSkin.GetComponent<SpriteRenderer>().sprite = BGSprite;

        BGBorder1Sprite = SelectedBorder1Skin.GetComponent<SpriteRenderer>().sprite;
        Border1Skin.GetComponent<SpriteRenderer>().sprite = BGBorder1Sprite;

        BGBorder2Sprite = SelectedBorder2Skin.GetComponent<SpriteRenderer>().sprite;
        Border2Skin.GetComponent<SpriteRenderer>().sprite = BGBorder2Sprite;

        Paddle1Sprite = SelectedPaddle1Skin.GetComponent<SpriteRenderer>().sprite;
        Paddle1Skin.GetComponent<SpriteRenderer>().sprite = Paddle1Sprite;

        Paddle2Sprite = SelectedPaddle2Skin.GetComponent<SpriteRenderer>().sprite;
        Paddle2Skin.GetComponent<SpriteRenderer>().sprite = Paddle2Sprite;

        PuckSprite = SelectedPuckSkin.GetComponent<SpriteRenderer>().sprite;
        PuckSkin.GetComponent <SpriteRenderer>().sprite = PuckSprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayer1Score()
    {
        Player1Score++;
        Player1ScoreText.text = Player1Score.ToString();
        if (Player1Score == Player1ScoreToWin)
        {
            Time.timeScale = 0f;
            Player1WinScreen.SetActive(true);
            PauseButton.SetActive(false);
        }
    }
    public void UpdatePlayer2Score()
    {
        Player2Score++;
        Player2ScoreText.text = Player2Score.ToString();
        if(Player2Score == Player2ScoreToWin)
        {
            Time.timeScale = 0f;
            Player2WinScreen.SetActive(true);
            PauseButton.SetActive(false);
        }
    }
}
