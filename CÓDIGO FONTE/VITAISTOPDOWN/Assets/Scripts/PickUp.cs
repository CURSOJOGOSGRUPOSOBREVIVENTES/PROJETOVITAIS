using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdBox;
    public LayerMask pickUpMask;
    public GameObject destroyEffect;

    public Vector3 Direction { get; set; }
    private GameObject itemHolding;

   

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(itemHolding)
            {
                
                itemHolding.transform.position = transform.position + Direction;
                itemHolding.transform.parent = null;
                if (itemHolding.GetComponent<Rigidbody2D>())
                    itemHolding.GetComponent<Rigidbody2D>().simulated = true;
                itemHolding = null;
                
            }
            else
            {
               Collider2D pickUpItem = Physics2D.OverlapCircle(transform.position + Direction, .4f, pickUpMask);
                if(pickUpItem)
                {
                    itemHolding = pickUpItem.gameObject;
                    itemHolding.transform.position = holdBox.position;
                    itemHolding.transform.parent = transform;
                    if (itemHolding.GetComponent<Rigidbody2D>())
                        itemHolding.GetComponent<Rigidbody2D>().simulated = false;
                }
            }
        }


        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(itemHolding)
            {
                StartCoroutine(ThrowItem(itemHolding));
                itemHolding = null;
            }
        }
    }

    IEnumerator ThrowItem(GameObject item)
    {
        Vector3 startPoint = item.transform.position;
        Vector3 endPoint = transform.position + Direction * 2;
        item.transform.parent = null;
        for (int i = 0; i < 25; i++)
        {
            item.transform.position = Vector3.Lerp(startPoint, endPoint, i * .04f);
            yield return null;
        }
        if (item.GetComponent<Rigidbody2D>())
            item.GetComponent<Rigidbody2D>().simulated = true;
        Instantiate(destroyEffect, item.transform.position, Quaternion.identity);
        Destroy(item);
    }
}
