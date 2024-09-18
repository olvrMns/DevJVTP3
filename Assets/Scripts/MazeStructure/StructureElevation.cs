using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureElevation : MonoBehaviour
{

    [Range(0, 500)]
    public float Elevation = 100;
    void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + this.Elevation, this.transform.position.z);
    }
}
