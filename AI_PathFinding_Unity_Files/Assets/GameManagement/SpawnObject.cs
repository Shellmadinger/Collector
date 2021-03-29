using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {
    //Initializing Variables
    public GameObject asset;
    public Transform spawnPoint;
    public float spawnRange;
    public float spawnHeight;
    public float spawnZ;
    public float spawnRate;


    // Use this for initialization
    void Start()
    {
        //Repeat Invoke to spawn more gems
        InvokeRepeating("SpawnGems", 0, spawnRate);
    }
    
    void SpawnGems()
    {
        //Instantiate Game Object with random range
        GameObject gem =Instantiate(asset, new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(spawnHeight, spawnHeight+3), Random.Range(-spawnZ,spawnZ)), Quaternion.identity) as GameObject;
        //Make each gem parent of gem spawner
        gem.transform.SetParent(transform);
    }
}
