using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   
    //public GameObject btnNextLevel;
    //public TMP_Text timeTxt;
    public GameObject player;
    
    public static GameManager Instance;
    public GameState gameState;
    public Scene thisScene;
    //public String nextLevel;
    public int numKeysCollected = 0;
    public static event Action<GameState> OnGameStateChanged;
    private float currentTime = 0.0f;
    public TextMeshProUGUI bestTimeTxt;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI LevelText;
    public GameObject exitDoor;
    public int playerHealth = 100;

    public GameObject nextLvl;
    public GameObject restartLvl;
    private Boolean gameOver = false;
    public GameObject winTxt;
    public static int bestTime = 0;
    public AudioClip levelVictoryFX;


    private void Awake()
    {
        print("game started");
        Instance = this;
        thisScene = SceneManager.GetActiveScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Idle);
        winTxt.SetActive(false);
        restartLvl.SetActive(false);
        nextLvl.SetActive(false);

        //to lock in the centre of window
        Cursor.lockState = CursorLockMode.Locked;
        //to hide the curser
        Cursor.visible = false;
    }

    public void UpdateGameState(GameState newState)
    {
        switch (newState)
        {
            case GameState.Idle:
                gameState = GameState.Idle;
                break;
            case GameState.Playing:
                gameState = GameState.Playing;          
                break;
            case GameState.WinLevel:
                gameState = GameState.WinLevel;
                HandleWinLevel();
               
                break;
            case GameState.LoseLevel:
                gameState = GameState.LoseLevel;
                HandelLoseLevel();
              
                break;
            case GameState.WinGame:
                gameState = GameState.WinGame;
                break;
            case GameState.GameOver:
                gameState = GameState.GameOver;
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void HandelLoseLevel()
    {
        print("handeling lost");
        winTxt.SetActive(true);
        winTxt.GetComponent<TextMeshProUGUI>().text = "You Lose!";

        endLevel();

    }
    private void endLevel()
    {
        gameOver = true;
        restartLvl.SetActive(true);
        nextLvl.SetActive(true);
        player.SetActive(false);
        Cursor.lockState = CursorLockMode.None; // to unlock cursor
        Cursor.visible = true; // to make cursor visible
    }
    private void HandleWinLevel()
    {
        AudioSource.PlayClipAtPoint(levelVictoryFX, player.transform.position);
        endLevel();
        int score = (int)currentTime;
        print("score= " + score.ToString());
     
        if (score < bestTime || bestTime==0)
        {
            bestTime = score;
            winTxt.GetComponent<TextMeshProUGUI>().text = "New Best Time!";
            winTxt.SetActive(true);
            bestTimeTxt.SetText("BestTime: " + bestTime.ToString());

        }

            //loadLevel();

        }

    

    public void updateHealth()
    {
        playerHealth = playerHealth - 20;

    }

    private void HandlePlayingGame()
    {
        
            if (numKeysCollected == 4)
                exitDoor.SetActive(false);
            if (playerHealth <= 0)
            {
                UpdateGameState(GameState.LoseLevel);
            }
        
    }

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            HandlePlayingGame();
            keysText.SetText("keys: " + numKeysCollected + "/4");
            currentTime = currentTime + Time.deltaTime;
            int myTimer = (int)currentTime;
            timerText.SetText(myTimer.ToString());
            healthText.SetText("HP: " + playerHealth.ToString());
            bestTimeTxt.SetText("BestTime: " + bestTime.ToString());
            LevelText.SetText(thisScene.name);
        }

    }

    public int getTime()
    {
        return (int)currentTime;
    }

    public void updateKeyCount()
    {
        numKeysCollected += 1;
    }


}

public enum GameState
{
    Idle,
    Playing,
    WinLevel,
    LoseLevel,
    WinGame,
    GameOver
}


