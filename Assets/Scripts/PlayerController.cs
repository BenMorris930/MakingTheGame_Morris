using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidBody;
    private Animator playerAnim;
    public float jumpHeight = 8;
    public float gravityMultiplier = 1;
    private bool canJump = true;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            playerRigidBody.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig");
            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        canJump = true;
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            playerAnim.SetBool("Death_b", true);
            Debug.Log("Game Over!");
        }

    }

}
