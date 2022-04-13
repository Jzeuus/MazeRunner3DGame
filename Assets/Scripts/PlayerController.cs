using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerController : MonoBehaviour
{
    private Vector2 vector2;
    private Rigidbody rb;
    //public Text scoreHolder;
    public GameObject player;
    private GameState state;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.OnGameStateChanged += GMOnGameStateChanged;


        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void GMOnGameStateChanged(GameState obj)
    {
        state = obj;
    }

    private void OnDestroy()
    {
        GameManager.OnGameStateChanged -= GMOnGameStateChanged;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(vector2.x, 0, vector2.y);

    }

    private void OnMove(InputValue inputValue)
    {
        vector2 = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter(Collider other)
    {
      
    }
}





    


