using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float repeatWith;
    private Vector3 startPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        repeatWith = GetComponent<BoxCollider>().size.x / 2;
      //  startPos = transform.position - repeatWith;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < startPos.z - repeatWith)
        {
            transform.position = startPos;
        }

    }
}
