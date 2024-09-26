using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{

    [Range(10f, 300f)]
    public float To = 60f;
    private float deltaTotalTime = 0f;
    public TextMeshProUGUI Text;

    private void Start()
    {
        this.Text.text = "0";
    }

    private bool HasReachedTimeLimit()
    {
        if (this.deltaTotalTime >= this.To) return true;
        return false;
    }

    void Update()
    {
        Text.SetText("Time left: " + ((int)(this.To - this.deltaTotalTime)).ToString());
        this.deltaTotalTime += Time.deltaTime;

        if (HasReachedTimeLimit() )
        {
            //Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
