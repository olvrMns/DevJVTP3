using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject FollowableEntity;
    public float RelativeHeightOffSet = 5f;

    void Start()
    {
        this.ToTopDownView();
    }


    private void LateUpdate()
    {
        this.FollowEntity();
    }

    private void FollowEntity()
    {
        this.transform.position = new Vector3(
            FollowableEntity.transform.position.x,
            FollowableEntity.transform.position.y + this.RelativeHeightOffSet,
            FollowableEntity.transform.position.z
        );  
    }

    private void ToTopDownView()
    {
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
    }
}
