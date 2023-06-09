using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public enum Scene
    {
        MainMenu,
        Level1,
        Level2,
        Level3,
        HowToPlay
    }

    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(Scene.Level1.ToString());
    }

    public void LoadNextLevel()
    {
        PersistentData.Instance.AddDifficulty(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        PersistentData.Instance.ResetDate();
        SceneManager.LoadScene(Scene.MainMenu.ToString());
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(Scene.HowToPlay.ToString());
    }
}
