using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SkinManager : MonoBehaviour
{
    [Header("Background and Border Sprites")]
    public SpriteRenderer BGSprite;
    public SpriteRenderer BGBorder1Sprite;
    public SpriteRenderer BGBorder2Sprite;
    public List<Sprite> BGSkins = new List<Sprite>();
    public List<Sprite> BGBorder1Skins = new List<Sprite>();
    public List<Sprite> BGBorder2Skins = new List<Sprite>();
    private int SelectedBGSkin;
    private int SelectedBGBorder1Skin;
    private int SelectedBGBorder2Skin;
    public GameObject BGSkin;
    public GameObject BGBorder1Skin;
    public GameObject BGBorder2Skin;

    [Header("Paddle 1 Sprites")]
    public SpriteRenderer Paddle1Sprite;
    public List<Sprite> Paddle1Skins = new List<Sprite>();
    private int SelectedPaddle1Skin;
    public GameObject Paddle1Skin;

    [Header("Paddle 2 Sprites")]
    public SpriteRenderer Paddle2Sprite;
    public List<Sprite> Paddle2Skins = new List<Sprite>();
    private int SelectedPaddle2Skin;
    public GameObject Paddle2Skin;

    [Header("Puck Sprites")]
    public SpriteRenderer PuckSprite;
    public List <Sprite> PuckSkins = new List<Sprite>();
    private int SelectedPuckSkin;
    public GameObject PuckSkin;

    [Header("General")]

    public AudioManager AM;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void NextBGSkinOption()
    {
        AM.PlayUINoise();
        SelectedBGSkin++;
        SelectedBGBorder1Skin++;
        SelectedBGBorder2Skin++;
        if(SelectedBGSkin == BGSkins.Count)
        {
            SelectedBGSkin = 0;
            SelectedBGBorder1Skin = 0;
            SelectedBGBorder2Skin = 0;
        }
        BGSprite.sprite = BGSkins[SelectedBGSkin];
        BGBorder1Sprite.sprite = BGBorder1Skins[SelectedBGBorder1Skin];
        BGBorder2Sprite.sprite = BGBorder2Skins[SelectedBGBorder2Skin];
    }

    public void PrevBGSkinOption()
    {
        AM.PlayUINoise();
        SelectedBGSkin--;
        SelectedBGBorder1Skin--;
        SelectedBGBorder2Skin--;
        if (SelectedBGSkin < 0)
        {
            SelectedBGSkin = BGSkins.Count - 1;
            SelectedBGBorder1Skin = BGBorder1Skins.Count - 1;
            SelectedBGBorder2Skin = BGBorder2Skins.Count - 1;
        }

        BGSprite.sprite = BGSkins[SelectedBGSkin];
        BGBorder1Sprite.sprite = BGBorder1Skins[SelectedBGBorder1Skin];
        BGBorder2Sprite.sprite = BGBorder2Skins[SelectedBGBorder2Skin];

    }

    public void NextPaddleSkinOption()
    {
        AM.PlayUINoise();
        SelectedPaddle1Skin++;
        SelectedPaddle2Skin++;
        if(SelectedPaddle1Skin == Paddle1Skins.Count && SelectedPaddle2Skin == Paddle2Skins.Count)
        {
            SelectedPaddle1Skin = 0;
            SelectedPaddle2Skin = 0;
        }
        Paddle1Sprite.sprite = Paddle1Skins[SelectedPaddle1Skin];
        Paddle2Sprite.sprite = Paddle2Skins[SelectedPaddle2Skin];
    }
    public void PrevPaddleSkinOption()
    {
        AM.PlayUINoise();
        SelectedPaddle1Skin--;
        SelectedPaddle2Skin--;
        if (SelectedPaddle1Skin < 0 && SelectedPaddle2Skin < 0)
        {
            SelectedPaddle1Skin = Paddle1Skins.Count - 1;
            SelectedPaddle2Skin = Paddle2Skins.Count - 1;

        }
        Paddle1Sprite.sprite = Paddle1Skins[SelectedPaddle1Skin];
        Paddle2Sprite.sprite = Paddle2Skins[SelectedPaddle2Skin];
    }

    public void NextPuckOption()
    {
        AM.PlayUINoise();
        SelectedPuckSkin++;

        if(SelectedPuckSkin == PuckSkins.Count)
        {
            SelectedPuckSkin = 0;
        }
        PuckSprite.sprite = PuckSkins[SelectedPuckSkin];
    }
    public void PrevPuckOption()
    {
        AM.PlayUINoise();
        SelectedPuckSkin--;

        if(SelectedPuckSkin < 0)
        {
            SelectedPuckSkin = PuckSkins.Count - 1;
        }
    }
}
