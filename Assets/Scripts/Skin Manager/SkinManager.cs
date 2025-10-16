using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    public SkinDatabase SDB;
    [Header("Background and Border Sprites")]
    public SpriteRenderer BGSprite;
    public SpriteRenderer BGBorder1Sprite;
    public SpriteRenderer BGBorder2Sprite;
    public int SelectedBGSkin;

    [Header("Paddle Sprites")]
    public SpriteRenderer Paddle1Sprite;
    public int SelectedPaddleSkin;
    public SpriteRenderer Paddle2Sprite;

    [Header("Puck Sprites")]
    public SpriteRenderer PuckSprite;
    public int SelectedPuckSkin;

    [Header("General")]

    public AudioManager AM;

    void Start()
    {
        if(!PlayerPrefs.HasKey("Selected BG Option"))
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
            SelectedPuckSkin = 0;
        }
        else
        {
            Load();
        }
        UpdateBackground(SelectedBGSkin);
        UpdatePaddle(SelectedPaddleSkin);
        UpdatePuck(SelectedPuckSkin);
    }

    void Update()
    {
        
    }

    public void NextBGSkinOption()
    {
        AM.PlayUINoise();
        SelectedBGSkin++;
        if (SelectedBGSkin >= SDB.SkinCount)
        {
            SelectedBGSkin = 0;
        }
        UpdateBackground(SelectedBGSkin);
        Save();
    }

    public void PrevBGSkinOption()
    {
        AM.PlayUINoise();
        SelectedBGSkin--;
        if (SelectedBGSkin < 0)
        {
            SelectedBGSkin = SDB.SkinCount - 1;
        }

        UpdateBackground(SelectedBGSkin);
        Save();
    }

    public void NextPaddleSkinOption()
    {
        AM.PlayUINoise();
        SelectedPaddleSkin++;
        if (SelectedPaddleSkin >= SDB.SkinCount)
        {
            SelectedPaddleSkin = 0;
        }
        UpdatePaddle(SelectedPaddleSkin);
        Save();
    }
    public void PrevPaddleSkinOption()
    {
        AM.PlayUINoise();
        SelectedPaddleSkin--;
        if (SelectedPaddleSkin < 0)
        {
            SelectedPaddleSkin = SDB.SkinCount - 1;
        }
        UpdatePaddle(SelectedPaddleSkin);
        Save();
    }

    public void NextPuckOption()
    {
        AM.PlayUINoise();
        SelectedPuckSkin++;
        if (SelectedPuckSkin >= SDB.SkinCount)
        {
            SelectedPuckSkin = 0;
        }
        UpdatePuck(SelectedPuckSkin); 
        Save();
    }
    public void PrevPuckOption()
    {
        AM.PlayUINoise();
        SelectedPuckSkin--;

        if (SelectedPuckSkin < 0)
        {
            SelectedPuckSkin = SDB.SkinCount - 1;
        }
        UpdatePuck(SelectedPuckSkin);
        Save();
    }

    private void UpdateBackground(int SelectedBGOption)
    {
        SkinInformation BGRef = SDB.GetSkin(SelectedBGOption);
        BGSprite.sprite = BGRef.BackgroundSprite;
        BGBorder1Sprite.sprite = BGRef.BackgroundBorder1Sprite;
        BGBorder2Sprite.sprite = BGRef.BackgroundBorder2Sprite;
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

    private void Save()
    {
        PlayerPrefs.SetInt("Selected BG Option", SelectedBGSkin);
        PlayerPrefs.SetInt("Selected Paddle Option", SelectedPaddleSkin);
        PlayerPrefs.SetInt("Selected Puck Option", SelectedPuckSkin);
    }
    private void Load()
    {
        SelectedBGSkin = PlayerPrefs.GetInt("Selected BG Option");
        SelectedPaddleSkin = PlayerPrefs.GetInt("Selected Paddle Option");
        SelectedPuckSkin = PlayerPrefs.GetInt("Selected Puck Option");
    }
}