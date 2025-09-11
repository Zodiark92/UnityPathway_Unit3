using UnityEngine;

public class PlayerControllerZ : MonoBehaviour
{
    private Rigidbody playerBody;
    private Vector3 upperBoundPos = new Vector3(0, 10.95f, -25.2f);
    public float jumpForce = 200f;
    private float maxJumpPos = 7.36f;

    private AudioSource audioSource;

    public AudioClip bongSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && transform.position.y <= maxJumpPos) {

            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        }

        if (transform.position.y >= upperBoundPos.y) { 
            transform.position = upperBoundPos;
        
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && !GetComponent<ItemController>().gameOver) {

            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            audioSource.PlayOneShot(bongSound, 1f);
            
        }
    }
}
