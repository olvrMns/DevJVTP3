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

    //https://discussions.unity.com/t/can-someone-help-me-make-a-simple-jump-script/145307/2
    private bool isGrounded = true;
    public float JumpForce = 2.0f;

    //public float TurnSpeed = 60.0f;

    void Start()
    {
        this.SetCollider();
        this.rb = this.GetComponent<Rigidbody>();
        this.Animator = this.GetComponent<Animator>();
        this.ToDefaultPosition();
    }

    private void SetIsGrounded()
    {
        this.isGrounded = this.transform.position.y <= this.InitialTerrain.transform.position.y + (this.InitialTerrain.transform.position.y * 0.01f);
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0, 0.5f * this.JumpForce, 0), ForceMode.Impulse);
    }

    private void SetCollider()
    {
        CapsuleCollider capsuleCollider = this.GetComponent<CapsuleCollider>();
        capsuleCollider.height = 2.3f;
        capsuleCollider.center = new Vector3(0, 1, 0);
    }
    public void ToDefaultPosition()
    {
        this.transform.position = new Vector3(
                this.InitialTerrain.transform.position.x + (this.InitialTerrain.terrainData.size.x * 0.5f),
                this.InitialTerrain.transform.position.y,
                this.InitialTerrain.transform.position.z + (this.InitialTerrain.terrainData.size.z * 0.10f));
    }

    private void FixedUpdate()
    {
        this.SetIsGrounded();
        if (Input.GetKey(KeyCode.Space) && this.isGrounded) this.Jump();

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) this.Animator.SetBool("IsWalking", true);  
        else this.Animator.SetBool("IsWalking", false);
         
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.forwardInput = Input.GetAxis("Vertical");

        this.forwardMovementVector = this.transform.forward * this.forwardInput * this.Speed * Time.fixedDeltaTime;  
        this.strafeMovementVector = this.transform.right * this.horizontalInput * this.StrafeSpeed * Time.fixedDeltaTime;  

        rb.MovePosition(this.rb.position + this.forwardMovementVector + this.strafeMovementVector);

        Debug.Log(isGrounded);

        //Vector3 rotation = new Vector3(0f, this.horizontalInput * this.TurnSpeed * Time.fixedDeltaTime, 0f);
        //this.rb.transform.Rotate(rotation);
    }

}