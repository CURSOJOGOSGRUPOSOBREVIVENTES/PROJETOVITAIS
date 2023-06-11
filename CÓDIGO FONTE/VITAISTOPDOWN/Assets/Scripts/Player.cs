using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    public bool isPaused;
    [SerializeField]public float speed;
    private Rigidbody2D rig;
    private Vector2 _direction;
    public PickUp pickUp;

    public Vector2 direction
    {
        get { return _direction; }
        set { _direction = value; }
    }
    
    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip portalSFX;

    [Header("Interact")]

    public KeyCode interactKey = KeyCode.E;
    bool canPortal = false;
    Region tmpRegion;

    

    private void Start()
    {
        
        rig = GetComponent<Rigidbody2D>();
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(0, -1);
        
    }


    private void Update()
    {
        {
            if (!isPaused)
            {
                OnInput();
            }

            if (canPortal && tmpRegion != null && Input.GetKeyDown(interactKey))
            {
                audioSource.PlayOneShot(portalSFX);
                this.transform.position = tmpRegion.warpLocation.position;
                
            }
        }   

    }


    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Portal")
        {
            tmpRegion = collider.GetComponent<Teleport>().region;
            canPortal = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Portal")
        {
            tmpRegion = tmpRegion = null;
            canPortal = false;
        }
    }


    private void FixedUpdate()
    {
        OnMove();
    }   

    #region Moviment


    void OnInput()
    {
        
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(_direction.sqrMagnitude >.1f)
        {
            pickUp.Direction = _direction.normalized;
        }
       
    }

    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);
    }


    #endregion


}
