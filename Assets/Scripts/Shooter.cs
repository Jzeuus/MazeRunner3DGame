using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public float power = 50.0f;

    // public AudioClip shootSFX;


    void Start() { 
        InvokeRepeating("DoSomething", 5, 5);
    }

    void DoSomething()
    {
        if (projectile)
        {
            GameObject nProjectile = Instantiate(projectile, transform.position +
                transform.forward, transform.rotation) as GameObject;

            if (!nProjectile.GetComponent<Rigidbody>())
            {
                nProjectile.AddComponent<Rigidbody>();
            }

            nProjectile.GetComponent<Rigidbody>().AddForce(
                transform.forward * power, ForceMode.VelocityChange);
        }
    }





void Update()
    {
      
        
    }


}
