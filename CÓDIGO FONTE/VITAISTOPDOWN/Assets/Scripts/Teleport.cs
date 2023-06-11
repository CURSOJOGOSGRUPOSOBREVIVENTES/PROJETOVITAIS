using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Region region;

    [SerializeField] private GameObject portalMark;

    public bool isPlayerInRanger;
    public LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRanger = true;
            portalMark.SetActive(true);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRanger = false;
            portalMark.SetActive(false);
        }
            
    }
}
