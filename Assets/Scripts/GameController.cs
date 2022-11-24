using System;
using UnityEngine.SceneManagement;

public class GameController : Singleton<GameController>
{
    public bool isGameActive;

    public string gameSceneName = "SampleScene";
    public string bossSceneName = "BossFight";
    public string mainMenuSceneName = "MainMenuScene";

    public bool bossSceneActive;

    private MenuUI menuUI;

    protected override void Awake()
    {
        menuUI = transform.Find("MainMenuUI").GetComponent<MenuUI>();
    }

    public void GoBackToMainMenu()
    {
        if (bossSceneActive)
        {
            SceneManager.UnloadSceneAsync(bossSceneName);
        }
        else
        {
            SceneManager.UnloadSceneAsync(gameSceneName);
        }
    }

    public void GameOver()
    {
        PrintDebugLog($"Is MenuUI null? : {menuUI == null}");
        if (menuUI)
        {
            return;
        }
        menuUI.ToggleVictoryWindow(true);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync(gameSceneName, LoadSceneMode.Additive);
        if (menuUI == null)
            return;

        menuUI.ToggleMainMenu(false);
    }

    public void LoadBossScene()
    {
        SceneManager.LoadSceneAsync(bossSceneName, LoadSceneMode.Additive);
    }
}
