


using UnityEngine;

using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject spawnPrefab;
    
    private Vector3 spawnPos=new Vector3(30,-0.24f,0);

    public float startDelay = 3;
    public float repeatDelay = 2;
    private PlayerController playercontrollerScript;
    public float increase = 0f;
   
   
    // Start is called before the first frame update
    void Start()
    {

        
        playercontrollerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnPrefab", startDelay, repeatDelay);
    }

    // Update is called once per frame
    void Update()
    {
        increase += Time.deltaTime;
    }
    void SpawnPrefab()
    {
        if (playercontrollerScript.gameOver == false)
        {
            
            Instantiate(spawnPrefab, spawnPos, spawnPrefab.transform.rotation); 
           
        }
    }
}
