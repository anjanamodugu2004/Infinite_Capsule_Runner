using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject GroundTile;
    Vector3 NextSpawnPoint;

    public void Spawntile (bool spawnItems){
        GameObject temp = Instantiate(GroundTile, NextSpawnPoint, Quaternion.identity);   // quaternion.identity means no rotation
        NextSpawnPoint = temp.transform.GetChild(1).transform.position;
        if(spawnItems){
            temp.GetComponent<GroundTile>().SpawnObstacle();
            temp.GetComponent<GroundTile>().SpawnCoins();
        }
    }

    private void Start() {
       for(int i=0;i<15;i++){
        if(i<3){
            Spawntile(false);
        }else{
        Spawntile(true);
        }
       }
    }
}
