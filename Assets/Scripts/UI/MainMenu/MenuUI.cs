using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : Singleton<MenuUI>
{

    [SerializeField] ScoreSO Score;
    public GameObject howToPlay;
    public GameObject victoryWindow;
    public GameObject mainMenu;

    protected override void Awake()
    {
       if(PlayerPrefs.GetInt("Lost") == 1)
        {
            int result = PlayerPrefs.GetInt("Score");
            Score.score = result;
            ToggleVictoryWindow(true);
            PlayerPrefs.SetInt("Lost", 0);      
        }
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OnClickOpenHowToPlay()
    {
        howToPlay.SetActive(true);

    }
    public void OnClickCloseHowToPlay()
    {
        howToPlay.SetActive(false);

    }
    public void OnClickExit()
    {
        Application.Quit();
    }

    public void ToggleVictoryWindow(bool v)
    {
        victoryWindow.SetActive(v);
    }


    public void ToggleMainMenu(bool v)
    {
        mainMenu.SetActive(v);
    }
}
