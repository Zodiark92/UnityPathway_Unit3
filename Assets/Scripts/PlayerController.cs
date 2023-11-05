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

    [SerializeField]
    public float jumpForce = 10;

    [SerializeField]
    public float gravityModifier = 1;

    private bool isGrounded = true;
    private bool canDoubleJump = false;
    public bool superSpeed = false;
    public bool gameOver = false;
    public bool gameStart = false;
    private float startPositionX = 3f;
    private float initialSpeed = 10f;
   


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
        if (!gameStart)
        {
            InitialPlayerMoving();
        }

        if(Input.GetKeyDown(KeyCode.Space) && !gameOver && gameStart)
        {
            if (isGrounded)
            {
                playerJump();

            } else if (canDoubleJump)
            {
                playerDoubleJump();
            }

        }

        SuperSpeedControl();
    }

    private void InitialPlayerMoving()
    {
        if(transform.position.x < startPositionX)
        {
            transform.Translate(Vector3.forward * initialSpeed * Time.deltaTime);
        } else
        {
            gameStart = true;
        }
    }

    private void playerJump()
    {
        playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        canDoubleJump = true;

        playerAnim.SetTrigger("Jump_trig");
        dirtParticle.Stop();
        playerAudio.PlayOneShot(jumpSound, 1.0f);
       

    }

    private void playerDoubleJump()
    {
        canDoubleJump = false;

        playerBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnim.SetTrigger("double_jump");
        playerAudio.PlayOneShot(jumpSound, 1.0f);
        playerAnim.SetBool("Grounded", false);

    }

    private void SuperSpeedControl()
    {
        if (Input.GetKey(KeyCode.Z) && !gameOver)
        {
            superSpeed = true;
            playerAnim.speed = 1.5f;
        }
        else
        { 
            superSpeed = false;
            playerAnim.speed = 1f;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = false;
            playerAnim.SetBool("Grounded", true);

            dirtParticle.Play();
        } 
        
        if (collision.gameObject.CompareTag("Obstacle"))
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
