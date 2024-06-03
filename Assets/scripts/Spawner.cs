using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //singleton
    public static Spawner Instance { get; private set; }
    
    //references to planes prefabs
    public GameObject redPlane;
    public GameObject greenPlane;
    public GameObject rainbowPlane;
    
    //Turret position
    private Vector3 turretPosition;
    
    //Create singleton before start app

    public void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
   
    /// <summary>
    /// save the turret position. This pos will be the ancor at spawn new planes 
    /// </summary>
    /// <param name="p_turretPosition">Turret position</param>
    
    public void setTurretPosition(Vector3 p_turretPosition)
    {
        turretPosition = p_turretPosition;
    }

    public void spawnPlane(GameObject plane)
    {
        //create empty gameobjet to work with transform 
        GameObject planeSpawnPoint = new GameObject();
        
        //Random heigh to add to turret pos
        float extraHeight = Random.Range(0.5f, 1.5f);
        
        //Random depth to add to turret pos
        float extraDepth = Random.Range(0.5f, 1.5f);
        
        //create spawn pos
        Vector3 planeSpawnPosition = new Vector3(0.0f, this.turretPosition.y + extraHeight, this.turretPosition.x + extraDepth);
        
        //Set the pos of the spawn
        planeSpawnPoint.transform.position = planeSpawnPosition;
        
        //Instance the plane of the spawn pos
        Instantiate(plane, planeSpawnPoint.transform);
    }

    public void spawnRedPlane()
    {
        spawnPlane(redPlane);
    }
    public void spawnGreenPlane()
    {
        spawnPlane(greenPlane);
    }
    public void spawnRainbowPlane()
    {
        spawnPlane(rainbowPlane);
    }

    public void spawnRedPlaneAfterTime(float time)
    {
        Invoke("spawnRedPlane",time);
    }
    public void spawnGreenPlaneAfterTime(float time)
    {
        Invoke("spawnGreenPlane",time);
    }
    public void spawnRainbowPlaneAfterTime(float time)
    {
        Invoke("spawnRainbowPlane",time);
    }
    
}
