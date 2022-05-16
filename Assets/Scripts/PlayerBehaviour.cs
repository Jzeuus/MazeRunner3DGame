using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public GameObject explosionPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Projectile")
        {

            print("player hit");
            //instantiate explsn
            if (explosionPrefab)
            {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosionPrefab, transform.position, transform.rotation);
            }
            Destroy(other.gameObject);
            
            
            //take damage and update health, every hit it -20
            GameManager.Instance.updateHealth();
        }

    }

}
