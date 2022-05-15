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
    public Scene nextLevel;
    public int numKeysCollected = 0;
    public static event Action<GameState> OnGameStateChanged;
    private float currentTime = 0.0f;
    public TextMeshProUGUI keysText;
    public TextMeshProUGUI timertext;
    public GameObject exitDoor;


    private void Awake()
    {
        Instance = this;
        thisScene = SceneManager.GetActiveScene();
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.Idle);
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
                //Rigidbody playerRigidBody = player.GetComponent<Rigidbody>();
               // playerRigidBody.isKinematic = false;             
                break;
            case GameState.WinLevel:
                gameState = GameState.WinLevel;
                HandleWinLevel();
               
                break;
            case GameState.LoseLevel:
                gameState = GameState.LoseLevel;
              
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
      
    }

    private void HandleWinLevel()
    {
        loadLevel();

    }

    private void loadLevel()
    {
        SceneManager.LoadScene(nextLevel.ToString());
    }

    private void HandlePlayingGame()
    {

    }

    private void FixedUpdate()
    {
        
        HandlePlayingGame();
        keysText.SetText("keys: " + numKeysCollected + "/4");
        currentTime = currentTime + Time.deltaTime;
        int myTimer = (int)currentTime;
        timertext.SetText(myTimer.ToString());
       

    }



    public void updateKeyCount()
    {
        numKeysCollected += 1;
    }

    private void unlockMazeDoor()
    {
        if (numKeysCollected == 4)
            exitDoor.SetActive(false);
       

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


