using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameOfTheSceneToLoad = "";

    public void loadLevel()
    {

        // if (!(SceneManager.GetActiveScene().name.Equals(nameOfTheSceneToLoad)))
        //{
        //  GameManager.Instance.ResetBest();
        //}
        print("load level here");
        SceneManager.LoadScene(nameOfTheSceneToLoad);

    }
}
