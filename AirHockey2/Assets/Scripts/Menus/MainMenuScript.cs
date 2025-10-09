using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization.Settings;

public class MainMenuScript : MonoBehaviour
{
    public GameObject HomeScreenPanel;
    public GameObject GameSetupPanel;
    public GameObject SelectedSkinHolder;
    public SkinManager SkinManager;
    public string VsCPUScene;
    public string PVPScene;
    public string SceneToPlay;
    public TMP_Text SingleOrMultiplayerText;
    public bool EasyMode;
    public bool MediumMode;
    public bool HardMode;
    public bool Multiplayer;
    public int PlayModeSelectionIndex;
    public TMP_Text PointsToWinText;
    public int PointsToWin;
    public int MinPointsToWin;
    public int MaxPointsToWin;
    public AudioManager AM;

    void Start()
    {
        HomeScreenPanel.SetActive(true);
        GameSetupPanel.SetActive(false);
        SelectedSkinHolder.SetActive(false);
        SceneToPlay = VsCPUScene;
        EasyMode = true;
        Multiplayer = GameValues.Multiplayer;
        GameValues.Difficulty = GameValues.Difficulties.Easy;
        Multiplayer = false;
        PlayModeSelectionIndex = 1;
        GameValues.PointsToWin = PointsToWin;

        if(LocalizationSettings.SelectedLocale.Identifier == "fr")
        {
            PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
            SingleOrMultiplayerText.text = "1 Jouer - FACILE";
        }
        else
        {
            PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
            SingleOrMultiplayerText.text = "1 Player - EASY";
        }
    }

    public void ActivatePlayerSelectPanel()
    {
        HomeScreenPanel.SetActive(false);
        GameSetupPanel.SetActive(true);
    }
    public void ActivateGameSetupPanel()
    {
        AM.PlayGoalSound();
        HomeScreenPanel.SetActive(false);
        GameSetupPanel.SetActive(true);
        SelectedSkinHolder.SetActive(true);
    }

    public void PlayGame()
    {

        PrefabUtility.SaveAsPrefabAsset(SkinManager.BGSkin, "Assets/Prefabs/Selected Skins/Selected Background.prefab");
        PrefabUtility.SaveAsPrefabAsset(SkinManager.BGBorder1Skin, "Assets/Prefabs/Selected Skins/Selected Background Border 1.prefab");
        PrefabUtility.SaveAsPrefabAsset(SkinManager.BGBorder2Skin, "Assets/Prefabs/Selected Skins/Selected Background Border 2.prefab");
        PrefabUtility.SaveAsPrefabAsset(SkinManager.Paddle1Skin, "Assets/Prefabs/Selected Skins/Selected Player 1 Paddle.prefab");
        PrefabUtility.SaveAsPrefabAsset(SkinManager.Paddle2Skin, "Assets/Prefabs/Selected Skins/Selected Player 2 Paddle.prefab");
        PrefabUtility.SaveAsPrefabAsset(SkinManager.PuckSkin, "Assets/Prefabs/Selected Skins/Selected Puck.prefab");
        SceneManager.LoadScene(SceneToPlay);
    }
    public void SelectPlayMode()
    {
        AM.PlayUINoise();
        PlayModeSelectionIndex++;
        if (PlayModeSelectionIndex == 2)
        {
            SceneToPlay = VsCPUScene;
            EasyMode = false;
            MediumMode = true;
            HardMode = false;
            Multiplayer = false;
            GameValues.Difficulty = GameValues.Difficulties.Medium;
            if(LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                SingleOrMultiplayerText.text = "1 Jouer - MOYEN";
            }
            else
            {
                SingleOrMultiplayerText.text = "1 Player - MEDIUM";
            }
        }
        if (PlayModeSelectionIndex == 3)
        {
            SceneToPlay = VsCPUScene;
            EasyMode = false;
            MediumMode = false;
            HardMode = true;
            Multiplayer = false;
            GameValues.Difficulty = GameValues.Difficulties.Hard;
            if(LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                SingleOrMultiplayerText.text = "1 Jouer - DUR";
            }
            else
            {
                SingleOrMultiplayerText.text = "1 Player - HARD";
            }

        }
        if (PlayModeSelectionIndex == 4)
        {
            SceneToPlay = PVPScene;
            EasyMode = false;
            MediumMode = false;
            HardMode = false;
            Multiplayer = true;
            if (LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                SingleOrMultiplayerText.text = "2 Jouers";
            }
            else
            {
                SingleOrMultiplayerText.text = "2 Players";
            }
        }
        if(PlayModeSelectionIndex == 5)
        {
            SceneToPlay = VsCPUScene;
            EasyMode = true;
            MediumMode = false;
            HardMode = false;
            Multiplayer = false;
            PlayModeSelectionIndex = 1;
            GameValues.Difficulty = GameValues.Difficulties.Easy;
            if (LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                SingleOrMultiplayerText.text = "1 JOUER - FACILE";
            }
            else
            {
                SingleOrMultiplayerText.text = "1 PLAYER - EASY";
            }
        }
    }
    public void SelectPlayModeBack()
    {
        AM.PlayUINoise();
        PlayModeSelectionIndex--;
        if (PlayModeSelectionIndex ==1)
        {
            SceneToPlay = VsCPUScene;
            EasyMode = true;
            MediumMode = false;
            HardMode = false;
            Multiplayer = false;
            GameValues.Difficulty = GameValues.Difficulties.Easy;
            if(LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                SingleOrMultiplayerText.text = "1 JOUER - FACILE";
            }
            else
            {
                SingleOrMultiplayerText.text = "1 PLAYER - EASY";
            }
                
        }
        if (PlayModeSelectionIndex == 2)
        {
            SceneToPlay = VsCPUScene;
            EasyMode = false;
            MediumMode = true;
            HardMode = false;
            Multiplayer = false;
            GameValues.Difficulty = GameValues.Difficulties.Medium;
            if(LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                SingleOrMultiplayerText.text = "1 JOUER - MOYEN";
            }
            else
            {
                SingleOrMultiplayerText.text = "1 PLAYER - MEDIUM";
            }
                
        }
        if (PlayModeSelectionIndex == 3)
        {
            SceneToPlay = VsCPUScene;
            EasyMode = false;
            MediumMode = false;
            HardMode = true;
            Multiplayer = false;
            GameValues.Difficulty = GameValues.Difficulties.Hard;
            if (LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                SingleOrMultiplayerText.text = "1 Jouer - DUR";
            }
            else
            {
                SingleOrMultiplayerText.text = "1 Player - HARD";
            }

        }

        if (PlayModeSelectionIndex == 0)
        {
            SceneToPlay = PVPScene;
            EasyMode = false;
            MediumMode = false;
            HardMode = false;
            Multiplayer = true;
            PlayModeSelectionIndex = 4;
            if (LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                SingleOrMultiplayerText.text = "2 Jouers";
            }
            else
            {
                SingleOrMultiplayerText.text = "2 Players";
            }
        }
    }
    public void IncreasePointsToWin()
    {
        AM.PlayUINoise();
        PointsToWin++;
        if(LocalizationSettings.SelectedLocale.Identifier == "fr")
        {
            PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
        }
        else
        {
            PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
        }
        GameValues.PointsToWin = PointsToWin;

        if(PointsToWin > MaxPointsToWin)
        {
            PointsToWin = MaxPointsToWin;
            if (LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
            }
            else
            {
                PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
            }
            GameValues.PointsToWin = PointsToWin;
        }
    }
    public void DecreasePointsToWin()
    {
        AM.PlayUINoise();
        PointsToWin--;
        if (LocalizationSettings.SelectedLocale.Identifier == "fr")
        {
            PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
        }
        else
        {
            PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
        }
        GameValues.PointsToWin = PointsToWin;

        if(PointsToWin <= MinPointsToWin)
        {
            PointsToWin = MinPointsToWin;
            if (LocalizationSettings.SelectedLocale.Identifier == "fr")
            {
                PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
            }
            else
            {
                PointsToWinText.text = "POINTS - " + PointsToWin.ToString();
            }
            GameValues.PointsToWin = PointsToWin;
        }
    }
}
