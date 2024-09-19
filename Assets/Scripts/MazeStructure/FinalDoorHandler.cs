using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoorHandler : DoorHandler
{
    public int ItemCount = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Playable" && Inventory.GetInstance().HasAtLeast(this.RequiredItem.name, this.ItemCount))
        {
            this.Animator.SetBool("IsOpened", true);
            this.Animator.SetBool("IsClosed", false);
            for (int elem = 0; elem < 3; elem++) Inventory.GetInstance().RemoveFirst(this.RequiredItem.name);
        }
    }
}
