using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
    public GameObject FlashlightOnPlayer;
    void Start()
    {
        FlashlightOnPlayer.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                FlashlightOnPlayer.SetActive(true);
            }
        }
    }

 
}
