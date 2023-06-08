using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftWithIncrese : MonoBehaviour
{
    public float speed = 10f;
    
    private PlayerController playercontrollerScript;
    private SpawnManager increaseSpeed;
    private float leftBound = -15f;



    // Start is called before the first frame update
    void Start()
    {
        increaseSpeed= GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playercontrollerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        speed = speed + increaseSpeed.increase;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        if (playercontrollerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);

        }
    }
}
