using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject ObstaclePrefab;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.Spawntile(true);
        Destroy(gameObject, 2);    
    }


    public void SpawnObstacle(){
        //choose a random point to spawn the obstacle
        int ObstacleSpawnIndex = Random.Range(2,5);  // basically gives a rand no b/w 2 and 5 and only 2 inclusive
        Transform spawnPoint = transform.GetChild(ObstacleSpawnIndex).transform;

        //Spawn the obstacle at the position
        Instantiate(ObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);

    }


    public void SpawnCoins(){
        int coinsToSpawn = 10;
        for(int i=0; i<coinsToSpawn; i++){
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointInCollider(Collider collider){
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
        );
        if(point != collider.ClosestPoint(point)){
           point = GetRandomPointInCollider(collider);
        }
        point.y=1;
        return point;
    }
}
