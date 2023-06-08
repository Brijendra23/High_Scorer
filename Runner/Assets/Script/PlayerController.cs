
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidrb;
    private float jumpForce = 700f;
    private float gravityModifier=1.75f;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem particleAnim;
    public ParticleSystem dirtParticleAnim;
    private AudioSource playerAudio;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    


    void Start()
    {
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        Debug.Log(Physics.gravity);
        
        rigidrb = GetComponent<Rigidbody>();
        Physics.gravity*=gravityModifier;
        playerAnim=GetComponent<Animator>();
        playerAudio=GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            if ((Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)|| (Input.touchCount>0 && isOnGround && !gameOver))
            {
                rigidrb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isOnGround = false;
                playerAnim.SetTrigger("Jump_trig");
                dirtParticleAnim.Stop();
                playerAudio.PlayOneShot(jumpSound, 1.0f);

            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround=true;
            dirtParticleAnim.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver=true;

            Invoke("GameOver",3);
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            particleAnim.Play();
            dirtParticleAnim.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        
    }
    
}

