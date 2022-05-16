using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
    public AudioClip pickUpSFX;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.updateKeyCount();
            AudioSource.PlayClipAtPoint(pickUpSFX, other.transform.position);
        }
    }
}
