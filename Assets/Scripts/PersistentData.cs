using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    [SerializeField] int playerScore;
    [SerializeField] string playerName;
    [SerializeField] int levelNum;
    [SerializeField] int difficulty = 1;

    public static PersistentData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }

        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerName = "";
        playerScore = 0;

    }
    public void SetName(string name)
    {
        playerName = name;
    }

    public void SetScore(int score)
    {
        playerScore = score;
    }

    public void AddScore(int increment)
    {
        playerScore += increment;
    }
    public void SetDifficulty(int difficulty)
    {
        this.difficulty = difficulty;
    }

    public void AddDifficulty(int increment)
    {
        this.difficulty += increment;
    }

    public string GetName()
    {
        return playerName;
    }

    public int GetScore()
    {
        return playerScore;
    }

    public int GetDifficulty()
    {
        return difficulty;
    }

    public void ResetDate()
    {
        playerName = "";
        playerScore = 0;
        difficulty = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }
}