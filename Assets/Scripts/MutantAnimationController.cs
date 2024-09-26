using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantAnimationController : MonoBehaviour
{

    public float Damage = 10f;
    public HealthBar PlayerHealthBar;

    private Animator animator;

    void Start()
    {
        this.animator = GetComponent<Animator>();
    }

    //SHOULD BE IN A UTILITY CLASS
    private bool CollisionObjectIsPlayer(Collision collision)
    {
        if (collision.gameObject.tag == "Playable") return true;
        else return false;
    }

    //SHOULD BE RANGED BASED / NOT BOOL
    private void OnCollisionStay(Collision collision)
    {
        if (this.CollisionObjectIsPlayer(collision))
        {
            this.animator.SetBool("PlayerIsNear", true);
            this.PlayerHealthBar.ReduceHealth(this.Damage);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (this.CollisionObjectIsPlayer(collision))
        {
            this.animator.SetBool("PlayerIsNear", false);
        }
    }

}
