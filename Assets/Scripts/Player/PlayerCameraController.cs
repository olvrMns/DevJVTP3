using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject FollowableEntity;
    public float RelativeHeightOffSet = 5f;
    public float Sensitivity = 2.0f;
    public bool IsTopDown = true;

    private void ToTopDownView()
    {
        this.transform.rotation = Quaternion.Euler(90, 0, 0);
    }

    private void FollowEntityInTopDown()
    {
        this.transform.position = new Vector3(
            FollowableEntity.transform.position.x,
            FollowableEntity.transform.position.y + this.RelativeHeightOffSet,
            FollowableEntity.transform.position.z
        );
        this.ToTopDownView();
    }

    private void SetFirstPersonCameraAngle()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        transform.RotateAround(FollowableEntity.transform.position, -Vector3.up, rotateHorizontal * this.Sensitivity); 
        transform.RotateAround(Vector3.zero, transform.right, rotateVertical * this.Sensitivity); 
    }

    //https://discussions.unity.com/t/how-do-i-move-a-camera-with-mouse/194032/2
    private void FollowEntityInFirstPerson()
    {
        this.transform.position = new Vector3(
            FollowableEntity.transform.position.x,
            FollowableEntity.transform.position.y,
            FollowableEntity.transform.position.z
        );
        this.SetFirstPersonCameraAngle();
    }


    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.X)) this.IsTopDown = !this.IsTopDown;

        if (this.IsTopDown) this.FollowEntityInTopDown();
        else this.FollowEntityInFirstPerson();
    }

}
