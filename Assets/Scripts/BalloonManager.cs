using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalloonManager : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;
    public GameObject levelCompleteUI;
    public GameObject pauseMenuUI;
    public Text scoreText;

    public static bool GameIsPaused = false;
    [SerializeField] public static int balloonPoints;
    public int pointDecay = 500;

    // Start is called before the first frame update
    void Start()
    {
        balloonPoints = 1000;
        UnfreezeGame();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Balloon").Length == 0)
        {
            FreezeGame();
            levelCompleteUI.SetActive(true);
            //Debug.Log(GameObject.FindGameObjectsWithTag("Balloon").Length);
        }

        if(Input.GetKeyDown(KeyCode.P) && !levelCompleteUI.activeInHierarchy)
        {
            //Debug.Log("pressed!");
            if(!GameIsPaused)
            {
                FreezeGame();
                pauseMenuUI.SetActive(true);
            } else
            {
                UnfreezeGame();
                pauseMenuUI.SetActive(false);
            }
        }


        if (balloonPoints >= 50) balloonPoints -= (int) (pointDecay * Time.deltaTime);

        scoreText.text = PersistentData.Instance.GetScore().ToString();
    }

    private void Spawn()
    {
        int xMin = -1;
        int xMax = 8;
        int yMin = -4;
        int yMax = 4;

        for (int i = 0; i < 3; i++)
        {
            Vector2 position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(balloonPrefab, position, Quaternion.identity);

        }

    }

    public void FreezeGame()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
    }

    public void UnfreezeGame()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
    }
}
