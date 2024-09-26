using TMPro;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{

    public FPSManager FPSManager;
    public GameObject FPSDisplayObject;
    private TextMeshProUGUI fpsTextDisplay;
    private RectTransform canvasRectTransform;
    private RectTransform fpsDisplayRectTransform;

    private void Start()
    {
        this.fpsTextDisplay = FPSDisplayObject.GetComponent<TextMeshProUGUI>();
        this.fpsDisplayRectTransform = FPSDisplayObject.GetComponent<RectTransform>();
        this.canvasRectTransform = this.GetComponent<RectTransform>();
        
        this.fpsTextDisplay.fontSize = 23;
        this.fpsTextDisplay.alignment = TextAlignmentOptions.Center;

        //1216 559
        this.fpsDisplayRectTransform.position = new Vector3(
            400, 
            200, 
            0);
        
    }

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(0, 0, 100, 50), "Top-Left");
    //}

    void Update()
    {
        this.fpsTextDisplay.SetText(((int)this.FPSManager.FrameRate).ToString());
    }
}
