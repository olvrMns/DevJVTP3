using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image HealthBarImage;
    private readonly float MAX_HEALTH = 1f;
    [Range(100f, 2000f)]
    public float VirtualMaxHealth = 500f;
    public float VirtualHealth;
    [Range(0.001f, 1f)]
    public float RegenerationPercentage = 0.01f;

    public TextMeshProUGUI DisplayText;

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
    }

    public void UpdateHealth(beforeSet execute)
    {
        execute();
        this.SetFillAmountToVirtualHealth();
    }

    public void ToFullHealth()
    {
        this.UpdateHealth(() => this.VirtualHealth = this.VirtualMaxHealth);
    }

    public void ToZeroHealth()
    {
        this.UpdateHealth(() => this.VirtualHealth = 0f);
    }

    //for different effects
    public void Heal(float by)
    {
        if (!(this.VirtualHealth + by >= this.VirtualMaxHealth))
            this.UpdateHealth(() => this.VirtualHealth += by);
        else this.UpdateHealth(() => this.ToFullHealth());
    }

    //for different effects
    public void ReduceHealth(float by)
    {
        if (!(this.VirtualHealth - by <= 0))
            this.UpdateHealth(() => this.VirtualHealth -= by);
        else this.UpdateHealth(() => this.ToZeroHealth());
    }

    void Update()
    {
        this.Heal(this.VirtualMaxHealth * this.RegenerationPercentage);
        this.DisplayText.SetText(((int)this.VirtualHealth).ToString());
    }
}
