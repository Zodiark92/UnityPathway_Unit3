using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float score = 0;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerController.gameOver && playerController.gameStart)
        {
            if (playerController.superSpeed)
            {
                score += 2 * Time.deltaTime;
            } else
            {
                score += Time.deltaTime;
            }
        }
        
        Debug.Log("Score: " + (int)score);
    }
}
