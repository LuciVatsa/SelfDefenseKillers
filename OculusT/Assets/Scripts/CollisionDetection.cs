﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{

    public Color greencolor = new Color(0.0f, 1.0f, 0.0f, 1.0f);
    public Color whitecolor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    bool bCollision;

    public Animator animator;
    public AssailantState assailant;
    public GameObject obj_assailant;
        
    // Start is called before the first frame update
    void Start()
    {
        //assailant = GetComponent<AssailantState>();
        //animator = GetComponent<Animator>();
        //animator = gameObject.GetComponent<Animator>();
        //assailant = gameObject.GetComponent<AssailantState>();
        GameObject obj_assailant = GameObject.FindWithTag("Assailant");
        //bCollision = false;
        if (obj_assailant != null)
        {
            animator = obj_assailant.GetComponent<Animator>();
            
        }
        if (obj_assailant == null)
        {
            Debug.Log("Cannot Find Assailaint object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (bCollision)
        {
            animator.SetBool("gotPoked", true);
        }
        */
        

        if (OVRInput.Get(OVRInput.Button.Two))
        {
            if (OVRInput.Get(OVRInput.Button.Two))
            {
                animator.SetBool("reset", true);
                animator.SetBool("gotPoked", false);


            }
            
        }
    }

    /*

    //at least one of the colliding objects needs a rigid body
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 point = collision.contacts[0].point;

        foreach( var contact in collision.contacts)//array of all contact points of collision
        {
            
        }
    }
    */
   
   
    private void OnTriggerEnter(Collider other)
    {
        transform.GetComponent<Renderer>().material.color = greencolor;
        //GameObject obj_assailant = GameObject.FindWithTag("Assailant");
        //GameObject obj_animator = GameObject.FindWithTag("Assailant");

        if (gameObject.tag == "Poke")
        {
            animator.SetBool("gotPoked", true);
        }
        /*
        if (obj_assailant != null)
        {
            animator = obj_assailant.GetComponent<Animator>();
            animator.SetBool("gotPoked", true);
        }
        if (obj_assailant == null)
        {
            Debug.Log("Cannot Find Assailaint object");
        }
        */
       
    }


    private void OnTriggerExit(Collider other)
    {
        transform.GetComponent<Renderer>().material.color = whitecolor;
    }
    
}
