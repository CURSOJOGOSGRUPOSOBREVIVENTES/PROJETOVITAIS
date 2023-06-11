using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBottom : MonoBehaviour
{
    private Animator anim;
    public Animator scadeAnim;

    public LayerMask layer;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    void OnPressed()
    {
        anim.SetBool("isPressed", true);
        scadeAnim.SetBool("isPressed", true);
    }

    void OnExit()
    {
        anim.SetBool("isPressed", false);
        scadeAnim.SetBool("isPressed", false);
    }

    private void FixedUpdate()
    {
        OnCollision();
    }

    void OnCollision()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 1, layer);
        
        if(hit != null)
        {
            OnPressed();
            hit = null;
        }
        else
        {
            OnExit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
