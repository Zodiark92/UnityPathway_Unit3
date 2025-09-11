using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float repeatWith;
    private Vector3 startPos = new Vector3(-5.8f, 5.7253f, 0);
    public Transform spawnPoint;
    private float offset = 6.5f;

    private Vector3 playerPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        repeatWith = GetComponent<BoxCollider>().size.x/2;
        playerPos = GameObject.Find("Player").transform.position;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z + repeatWith < playerPos.z)
        {
            transform.position = spawnPoint.transform.position + new Vector3(0,0, repeatWith/2 + offset);
        }

    }
}
