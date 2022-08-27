using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    // -10 to 10 x / 3.5 to -1.5f y
    public GameObject blade;
    float randomSpawnTime = 5;

    private void Start()
    {
        InvokeRepeating("SpawnBlade", 0, randomSpawnTime);
    }

    void SpawnBlade()
    {
        float x = Random.Range(0, 2);
        float y = Random.Range(3.5f, -1.5f);
        
        Vector3 pos = new Vector3( x < 1 ? -11 : 11 , y, 0f);
        Instantiate(blade, pos, Quaternion.identity);

        randomSpawnTime = Random.Range(2, 7);
    }

}


// Obj coletaveis = szadiart.itch.io/rocky-world-platformer-set
// Emotes = pipoya.itch.io/free-popup-emotes-pack