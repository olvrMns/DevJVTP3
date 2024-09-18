using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [Range(0f, 20f)]
    public float Speed = 3.0f;
    [Range(0f, 20f)]
    public float StrafeSpeed = 5.0f;
    public Terrain InitialTerrain;
    private float horizontalInput;
    private float forwardInput;
    private Rigidbody rb;
    private Vector3 forwardMovementVector; 
    private Vector3 strafeMovementVector;

    public GameObject TempSpawnPrefab;

    //public float TurnSpeed = 60.0f;  
    //private boolean IsGrounded;
    //private boolean IsRunning;
    //private boolean ISWalking

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.ToDefaultPosition();
        //TEMPORARY
        Instantiate(
            TempSpawnPrefab, 
            new Vector3(this.transform.position.x, this.transform.position.y + 0.02f, this.transform.position.z + 15f), 
            Quaternion.Euler(0, 0, 0));
    }

    private void FixedUpdate()
    {
        this.horizontalInput = Input.GetAxis("Horizontal");
        this.forwardInput = Input.GetAxis("Vertical");

        this.forwardMovementVector = this.transform.forward * forwardInput * this.Speed * Time.fixedDeltaTime;  
        this.strafeMovementVector = this.transform.right * horizontalInput * this.StrafeSpeed * Time.fixedDeltaTime;  

        rb.MovePosition(this.rb.position + this.forwardMovementVector + this.strafeMovementVector);

        //Vector3 rotation = new Vector3(0f, horizontalInput * turnSpeed * Time.fixedDeltaTime, 0f);
        //this.rb.transform.Rotate(rotation);
    }

    public void ToDefaultPosition()
    {
        this.transform.position = new Vector3(
                this.InitialTerrain.transform.position.x + (this.InitialTerrain.terrainData.size.x * 0.5f),
                this.InitialTerrain.transform.position.y,
                this.InitialTerrain.transform.position.z + (this.InitialTerrain.terrainData.size.z * 0.05f));
    }
}