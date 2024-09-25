using UnityEngine;

//https://www.youtube.com/watch?v=FF6kezDQZ7s&list=PLwyUzJb_FNeTQwyGujWRLqnfKpV-cj-eO&index=3 (Animation)
public class PlayerController : MonoBehaviour
{
    
    [Range(0f, 20f)]
    public float Speed = 3.0f;
    [Range(0f, 20f)]
    public float StrafeSpeed = 5.0f;
    public Terrain InitialTerrain;
    public Animator Animator;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;
    private Vector3 forwardMovementVector; 
    private Vector3 strafeMovementVector;
    //public float TurnSpeed = 60.0f;

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.Animator = this.GetComponent<Animator>();
        this.ToDefaultPosition();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) this.Animator.SetBool("IsWalking", true);  
        else this.Animator.SetBool("IsWalking", false);

        this.horizontalInput = Input.GetAxis("Horizontal");
        this.forwardInput = Input.GetAxis("Vertical");

        this.forwardMovementVector = this.transform.forward * this.forwardInput * this.Speed * Time.fixedDeltaTime;  
        this.strafeMovementVector = this.transform.right * this.horizontalInput * this.StrafeSpeed * Time.fixedDeltaTime;  

        rb.MovePosition(this.rb.position + this.forwardMovementVector + this.strafeMovementVector);

        //Vector3 rotation = new Vector3(0f, this.horizontalInput * this.TurnSpeed * Time.fixedDeltaTime, 0f);
        //this.rb.transform.Rotate(rotation);
    }

    public void ToDefaultPosition()
    {
        this.transform.position = new Vector3(
                this.InitialTerrain.transform.position.x + (this.InitialTerrain.terrainData.size.x * 0.5f),
                this.InitialTerrain.transform.position.y,
                this.InitialTerrain.transform.position.z + (this.InitialTerrain.terrainData.size.z * 0.10f));
    }
}