using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;

    [SerializeField]
    public float superSpeed = 20f;

    private PlayerController playerController;
    private float leftBound = -15f;
    private float speedMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.superSpeed)
        {
            speedMovement = superSpeed;

        } else
        {
            speedMovement = speed;
        }

        
        if(!playerController.gameOver && playerController.gameStart)
        {
            transform.Translate(Vector3.left * speedMovement * Time.deltaTime);
        }

        if(transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        
    }
}
