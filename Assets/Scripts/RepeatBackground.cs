using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float halfLength;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        halfLength = GetComponent<BoxCollider>().size.x / 2;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - halfLength)
        {

            transform.position = startPos;
        }

    }
}
