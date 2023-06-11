using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    
    private Player player;
    private Animator anim;

   
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        OnMove();
          
    }

    #region Moviment

    void OnMove()
    {

        if (player.direction.sqrMagnitude > 0)
        {
            anim.SetInteger("transition", 1);    
        }       
        else
        {
            anim.SetInteger("transition", 0);
        }
        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

    }

    #endregion
   
}
