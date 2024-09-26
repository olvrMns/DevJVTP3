
using UnityEngine;

public class HealingItem : MonoBehaviour
{

    public HealthBar HealthBar;
    [Range(0.01f, 1f)]
    public float HealingPercentage = 0.4f; 

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Playable")
        {
            this.HealthBar.Heal(this.HealingPercentage * this.HealthBar.VirtualMaxHealth);
            Destroy(this.gameObject);
        }
    }
}
