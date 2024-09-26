using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject FollowableEntity;
    public float RelativeHeightOffSet = 5f;
    public float Sensitivity = 2.0f;
    public bool IsTopDown = true;

    private void Start()
    {
        
    }

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

    //https://discussions.unity.com/t/how-can-i-tell-if-the-mouse-is-over-the-game-window/139428/4
    private bool mouseIsOnScreen()
    {
        Vector3 mousePosition = Input.mousePosition;
        return !(0 > mousePosition.x || 0 > mousePosition.y || Screen.width < mousePosition.x || Screen.height < mousePosition.y);
    }

    private void SetFirstPersonCameraAngle()
    {
        if (this.mouseIsOnScreen())
        {
            this.transform.localEulerAngles = new Vector3(
                this.transform.localEulerAngles.x + (this.Sensitivity * Input.GetAxis("Mouse Y") * -1),
                this.transform.localEulerAngles.y + (this.Sensitivity * Input.GetAxis("Mouse X")),
                0);
        }
    }

    //https://discussions.unity.com/t/how-do-i-move-a-camera-with-mouse/194032/2
    private void FollowEntityInFirstPerson()
    {
        this.transform.position = new Vector3(
            this.FollowableEntity.transform.position.x,
            this.FollowableEntity.transform.position.y + 1.5f,
            this.FollowableEntity.transform.position.z
        );
        this.SetFirstPersonCameraAngle();
    }


    private void LateUpdate()
    {
        if (Input.GetKey(KeyCode.X)) this.IsTopDown = !this.IsTopDown;

        if (this.IsTopDown) this.FollowEntityInTopDown();
        else this.FollowEntityInFirstPerson();

        Debug.Log(Input.GetAxis("Mouse X"));
    }

}
