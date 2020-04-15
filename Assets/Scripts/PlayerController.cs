using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Animator playerAnim;
    public ParticleSystem obstacleExplosion;
    public ParticleSystem dirtSplat;
    public AudioClip jumpSound;
    public AudioClip explosionSound;
    private AudioSource audioSource;
    public float jumpHeight = 8;
    public float gravityMultiplier = 1;
    private bool canJump = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump && !gameOver)
        {
            playerRigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            canJump = false;
            dirtSplat.Stop();
            audioSource.PlayOneShot(jumpSound, 1.5f);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        canJump = true;
        dirtSplat.Play();
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            obstacleExplosion.Play();
            audioSource.PlayOneShot(explosionSound, 1.5f);
            dirtSplat.Stop();
            playerAnim.SetBool("Death_b", true);
            Debug.Log("Game Over!");
        }

    }

}
