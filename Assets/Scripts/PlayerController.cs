using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    //public float TurnSpeed = 60.0f;  
    //private boolean IsGrounded

    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.ToDefaultPosition();
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

    private void ToDefaultPosition()
    {
        this.rb.transform.position = new Vector3(
            this.InitialTerrain.transform.position.x + (this.InitialTerrain.transform.position.x * 0.50f),
            this.InitialTerrain.transform.position.y,
            this.InitialTerrain.transform.position.z + (this.InitialTerrain.transform.position.z * 0.05f)
        );
    }
}