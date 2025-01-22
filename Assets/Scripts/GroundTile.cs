using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnObstacle();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.Spawntile();
        Destroy(gameObject, 2);    
    }

    public GameObject ObstaclePrefab;

    void SpawnObstacle(){
        //choose a random point to spawn the obstacle
        int ObstacleSpawnIndex = Random.Range(2,5);  // basically gives a rand no b/w 2 and 5 and only 2 inclusive
        Transform spawnPoint = transform.GetChild(ObstacleSpawnIndex).transform;

        //Spawn the obstacle at the position
        Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }
}
