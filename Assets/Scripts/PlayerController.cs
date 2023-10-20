using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerBody;
    private Animator playerAnim;
    public ParticleSystem explosionEffect;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    public float jumpForce = 10;
    public float gravityModifier = 1;
    private bool isGrounded = true;

    public bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver)
        {
            playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;

            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            dirtParticle.Play();

        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over!!");
            gameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionEffect.Play();
            dirtParticle.Stop();
            dirtParticle.gameObject.SetActive(false);
            playerAudio.PlayOneShot(crashSound,1.0f);
        }

        
    }
}
