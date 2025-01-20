using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject GroundTile;
    Vector3 NextSpawnPoint;

    public void Spawntile (){
        GameObject temp = Instantiate(GroundTile, NextSpawnPoint, Quaternion.identity);   // quaternion.identity means no rotation
        NextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    private void Start() {
       for(int i=0;i<15;i++){
        Spawntile();
       }
    }
}
