using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image HealthBarImage;
    private readonly float MAX_HEALTH = 1f;
    [Range(100f, 2000f)]
    public float VirtualMaxHealth = 500f;
    public float VirtualHealth;
    public delegate void beforeSet();

    void Start()
    {
        this.HealthBarImage = GetComponent<Image>();
        this.HealthBarImage.fillAmount = this.MAX_HEALTH;
        this.VirtualHealth = this.VirtualMaxHealth;
    }

    private void SetFillAmountToVirtualHealth()
    {
        this.HealthBarImage.fillAmount = this.VirtualHealth/this.VirtualMaxHealth;
        Debug.Log(this.HealthBarImage.fillAmount);
    }

    public void UpdateHealth(beforeSet execute)
    {
        execute();
        this.SetFillAmountToVirtualHealth();
    }


    //for different effects
    public void Heal(float by)
    {
        this.UpdateHealth(() => this.VirtualHealth += by);
    }

    //for different effects
    public void ReduceHealth(float by)
    {
        this.UpdateHealth(() => this.VirtualHealth -= by);
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.K)) 
    //    {
    //        this.ReduceHealth(10);
    //    }

    //}
}
