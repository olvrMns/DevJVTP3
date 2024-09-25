using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderSet : MonoBehaviour
{

    public Terrain CurrentTerrain;
    public CameraController CameraController;
    public GameObject WallTemplate;
    //(width, height, Length)
    private Vector3 terrainSizeVector;
    private Vector3 terrainPositionVector;

    void Start()
    {
        this.terrainSizeVector = CurrentTerrain.terrainData.size;
        this.terrainPositionVector = this.CurrentTerrain.GetPosition();   
        this.SetWalls();
    }

    //to make adaptable walls around the InitialTerrain (in a really unoptimized way)
    //there is still a bug where you can pass through a wall despite collisions
    //RelativeHeight so that the player will be able to see the objects (keys) in top down view
    private void SetWalls()
    {
        Transform parent = GameObject.Find("MazeStructure").transform;
        Quaternion xEulerAngle = Quaternion.Euler(0, 90, 0);
        Quaternion zEulerAngle = Quaternion.Euler(0, 0, 0);

        GameObject xWall1 = Instantiate(this.WallTemplate, this.terrainPositionVector, xEulerAngle, parent);
        
        xWall1.transform.localScale += new Vector3(0, CameraController.RelativeHeightOffSet, this.terrainSizeVector.x);
        xWall1.transform.position += new Vector3(this.terrainSizeVector.x/2, xWall1.transform.localScale.y/2, 0);

        GameObject xWall2 = Instantiate(xWall1, xWall1.transform.position, xEulerAngle, parent);
        xWall2.transform.position += new Vector3(0, 0, this.terrainSizeVector.z);

        GameObject zWall3 = Instantiate(this.WallTemplate, this.terrainPositionVector, zEulerAngle, parent);
        zWall3.transform.localScale += new Vector3(0, CameraController.RelativeHeightOffSet, this.terrainSizeVector.z);
        zWall3.transform.position += new Vector3(0, zWall3.transform.localScale.y/2, this.terrainSizeVector.z/2);

        GameObject zWall4 = Instantiate(zWall3, zWall3.transform.position, zEulerAngle, parent);
        zWall4.transform.position += new Vector3(this.terrainSizeVector.x, 0, 0);

    }
}
