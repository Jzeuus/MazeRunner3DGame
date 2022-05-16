using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitMaze : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Exit")) 
        { 

            //Destroy(collision.gameObject);
            // print("target destroyed");

            GameManager.Instance.UpdateGameState(GameState.WinLevel);

        }
    }
}
