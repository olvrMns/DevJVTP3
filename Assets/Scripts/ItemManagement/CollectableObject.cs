using UnityEngine;

public abstract class CollectableObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Playable")
        {
            Inventory.GetInstance().AddObject(this.gameObject, () => this.gameObject.SetActive(false));
        }
    }
}
