using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private PlayerController playerController;

    private Vector3 spawnPos = new Vector3(25f, 0, 0);
    private float startDelay = 2f;
    private float repeatTime = 4f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("SpawnObstacle", startDelay, repeatTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnObstacle() {

        if (!playerController.gameOver) {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
        
    
    }
}
