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

    public SkinDatabase SDB;
    private int SelectedBGSkin;
    private int SelectedPaddleSkin;
    private int SelectedPuckSkin;
    public SpriteRenderer BGSprite;
    public SpriteRenderer BGBorder1;
    public SpriteRenderer BGBorder2;
    public SpriteRenderer Paddle1Sprite;
    public SpriteRenderer Paddle2Sprite;
    public SpriteRenderer PuckSprite;

    private void Awake()
    {
        Time.timeScale = 1f;
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 1;
    }
    void Start()
    {
        Player1WinScreen.SetActive(false);
        Player2WinScreen.SetActive(false);
        Player1ScoreToWin = GameValues.PointsToWin;
        Player2ScoreToWin = GameValues.PointsToWin;

        ScoreToWinText.text = "PTS TO WIN: " + GameValues.PointsToWin;

        if (!PlayerPrefs.HasKey("Selected BG Option"))
        {
            SelectedBGSkin = 0;
        }
        else
        {
            Load();
        }
        if (!PlayerPrefs.HasKey("Selected Paddle Option"))
        {
            SelectedPaddleSkin = 0;
        }
        else
        {
            Load();
        }
        if (!PlayerPrefs.HasKey("Selected Puck Option"))
        {
            SelectedPaddleSkin = 0;
        }
        else
        {
            Load();
        }
        UpdateBackground(SelectedBGSkin);
        UpdatePaddle(SelectedPaddleSkin);
        UpdatePuck(SelectedPuckSkin);

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

    private void UpdateBackground(int SelectedBGOption)
    {
        SkinInformation BGRef = SDB.GetSkin(SelectedBGOption);
        BGSprite.sprite = BGRef.BackgroundSprite;
        BGBorder1.sprite = BGRef.BackgroundBorder1Sprite;
        BGBorder2.sprite = BGRef.BackgroundBorder2Sprite;
    }
    private void UpdatePaddle(int SelectedPaddleOption)
    {
        SkinInformation PaddleRef = SDB.GetSkin(SelectedPaddleOption);
        Paddle1Sprite.sprite = PaddleRef.Player1PaddleSprite;
        Paddle2Sprite.sprite = PaddleRef.Player2PaddleSprite;
    }
    private void UpdatePuck(int SelectedPuckOption)
    {
        SkinInformation PuckRef = SDB.GetSkin(SelectedPuckOption);
        PuckSprite.sprite = PuckRef.PuckSprite;
    }
    private void Load()
    {
        SelectedBGSkin = PlayerPrefs.GetInt("Selected BG Option");
        SelectedPaddleSkin = PlayerPrefs.GetInt("Selected Paddle Option");
        SelectedPuckSkin = PlayerPrefs.GetInt("Selected Puck Option");
    }
}
