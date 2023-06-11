using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedCollider : MonoBehaviour
{
    public GameObject openColliderBeer;
    // Start is called before the first frame update
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(openColliderBeer);
        Destroy(this.gameObject);
    }
}
