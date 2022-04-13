using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    //public GameObject btnNextLevel;
    //public TMP_Text timeTxt;
    public GameObject player;
    public static GameManager Instance;
    public GameState gameState;
    public Scene thisScene;
    public static event Action<GameState> OnGameStateChanged;



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
       

    }

    private void HandlePlayingGame()
    {

    }

    private void FixedUpdate()
    {
        
        HandlePlayingGame();
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

