using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private Vector3 spawnPos = new Vector3(25,0,0);

    private float startDelay = 4;
    private float spawnInterval = 2;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    private void SpawnObstacle()
    {
        if (!playerController.gameOver)
        {
            int randomIndex = Random.Range(0, obstaclePrefabs.Length);
            Instantiate(obstaclePrefabs[randomIndex], spawnPos, obstaclePrefabs[randomIndex].transform.rotation);
        }
    }
       
}
