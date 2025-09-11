using UnityEngine;

public class SpawnManagerZ : MonoBehaviour
{

    public GameObject[] items;
    private float spawnPosZ = -4f;
    private float spawnPosYMin = 1.57f;
    private float spawnPosYMax = 8f;

    private float startDelay = 2f;
    private float repeatRate = 1.5f;

    private ItemController controller;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GameObject.Find("Player").GetComponent<ItemController>();

        InvokeRepeating("SpawnItem", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void SpawnItem() {

        if (!controller.gameOver) {
            Vector3 spawnPos = new Vector3(0, Random.Range(spawnPosYMin, spawnPosYMax), spawnPosZ);
            int itemIndex = Random.Range(0, items.Length);

            Instantiate(items[itemIndex], spawnPos, items[itemIndex].transform.rotation);
        }
       
    
    }
}
