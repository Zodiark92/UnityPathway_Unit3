using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ParticleSystem bombExplosionParticles;
    public ParticleSystem moneyExplosionParticles;

    public bool gameOver = false;

    private AudioSource audioSource;

    public AudioClip moneySound;
    public AudioClip explosionSound;

    private MeshRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            Debug.Log("Game Over!!");

            bombExplosionParticles.Play();
            audioSource.PlayOneShot(explosionSound, 1f);

            gameOver = true;
            renderer.enabled = false;
            Destroy(gameObject, 5f);

        }
        else if (other.gameObject.CompareTag("Money")) {

            moneyExplosionParticles.Play();
            audioSource.PlayOneShot(moneySound, 1f);
            Destroy(other.gameObject);
        }

        
    }
}
