using UnityEngine;

public class MoveLeftZ : MonoBehaviour
{
    public float speed = 15f;

    private float leftBound = -46f;

    private ItemController itemController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        itemController = GameObject.Find("Player").GetComponent<ItemController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!itemController.gameOver) {
            transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);
        }
        

        if (transform.position.z < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }
    }


}
