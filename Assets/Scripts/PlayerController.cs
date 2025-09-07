using UnityEditor.Animations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticles;

    public AudioClip crashSound;
    public AudioClip jumpSound;

    public float jumpForce = 200;
    public float gravityModifier = 1.5f;
    private bool isOnGround = true;

    public bool gameOver = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            isOnGround = false;

            dirtParticles.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

        if (gameOver)
        {
            dirtParticles.Stop();
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle")) {

            Debug.Log("Game Over!");
            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticles.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
