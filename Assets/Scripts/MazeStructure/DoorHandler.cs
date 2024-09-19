using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHandler : MonoBehaviour
{

    public Animator Animator;

    void Start()
    {
        this.Animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Playable" && Inventory.GetInstance().Has("RustedKey"))
        {
            this.Animator.SetBool("IsOpened", true);
            this.Animator.SetBool("IsClosed", false);
            Inventory.GetInstance().RemoveFirst("RustedKey");
        } 
    }
}
