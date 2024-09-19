using UnityEngine;

public class Reset : MonoBehaviour
{

    public Terrain Terrain;
    public PlayerController PlayerController;

    void LateUpdate()
    {
        if (this.transform.position.y < 90)
        {
            PlayerController.ToDefaultPosition();
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) PlayerController.ToDefaultPosition();
    }
}
