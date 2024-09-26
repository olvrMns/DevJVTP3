using System.Collections;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{

    public string Message = "slt";
    public TextMeshProUGUI Text;

    [Range(1, 300)]
    public int FrameLifespan = 100;

    void Start()
    {
        this.Text = GetComponent<TextMeshProUGUI>();
        this.Text.text = this.Message;
    }

    void Update()
    {
        StartCoroutine(Wait());
    }

    public IEnumerator Wait()
    {
        for (int elem = 0; elem < FrameLifespan ; elem++) {
            if (elem >= this.FrameLifespan - 1)
            {
                Destroy(this.gameObject);
                Destroy(this);
            }
            //TO TIME BY FRAMES
            yield return null;
        }
    }
}
