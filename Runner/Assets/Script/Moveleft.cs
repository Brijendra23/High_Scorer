
using UnityEngine;
using UnityEngine.UI;

public class Moveleft : MonoBehaviour
{
    public float speed = 10;
    private PlayerController playercontrollerScript;
    private float leftBound = -15f;
   

    
    // Start is called before the first frame update
    void Start()
    {
       playercontrollerScript=GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    // Update is called once per frame
    void Update()
    {
       
        if (playercontrollerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x<leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
            
        }
    } 
}
