using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneWaveOne : MonoBehaviour {

//**** player ship information ****//

    public GameObject shot;
    public Transform shotSpawn;
    public Transform playerTransform;
    public float thrust = 3;

    private bool movingLeft = false;
    private bool movingRight = false;

//**** player ship information ****//


//**** wave and enemy information ****//

    // enemy spawn information
    public GameObject[] hazards;
    public int hazardCount;

    private float xPos = 3f;  // leftmost x position on playing field
    private float zPos = 6f;  // bottom-most z position on playing field
    private float xOffset = 0f;
    private float zOffset = 0f;
    private float xMax = 12f;  // rightmost x position on playing field
    private float zMax = 12f;  // uppermost z position on playing field
    // enemy spawn information

    // enemy location information
    private float[] enemyLocations = { 3, 6, 9, 12, 12, 9, 6, 3 };
    private int enemyCount;

    // the player's answer code to the exercise
    public InputField playerCodeInput;
    private string playerCode;

//**** wave and enemy information ****//


    private void Update()
    {
        playerCode = playerCodeInput.text;

        if (movingLeft && playerTransform.position.x <= enemyLocations[enemyCount])  // enemy and player x positions are the same, so just fire
        {
            Stop();
            Shoot();
            SeekNextEnemy();
        }

        else if (movingRight && playerTransform.position.x >= enemyLocations[enemyCount])
        {
            Stop();
            Shoot();
            SeekNextEnemy();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingLeft) { playerTransform.Translate(Vector3.left * thrust * Time.deltaTime); }
        else if (movingRight) { playerTransform.Translate(Vector3.right * thrust * Time.deltaTime); }
    }

    void Start ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        SpawnWaveOne();
    }

    private void SpawnWaveOne()
    {
        for (int i = 0; i < hazardCount; i++)
        {
            GameObject hazard = hazards[1];

            Vector3 spawnPosition = new Vector3(xPos + xOffset, 0f, zPos + zOffset);
            //Vector3 spawnPosition = new Vector3(8, 0f, zPos + zOffset);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);

            xOffset += 3;
            if (xOffset >= xMax) { xOffset = 0; zOffset += 3; }
        }
    }

    public void WaveOneAction()
    {
        enemyCount = 0;

        // here check if user input correctly solves coding problem
        // and respond to incorrect input accordingly via EnactWaveOne()
        if (playerCode == null) { Debug.Log("playerCode text is empty!"); }
        else { EnactWaveOne(enemyLocations[enemyCount]); }
        
    }

    private void EnactWaveOne(float enemyLocation)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        
        Debug.Log("****WaveOneAction invoked...");
        Debug.Log("Player location is: " + playerTransform.position);
        Debug.Log("Enemy's position: " + enemyLocations[enemyCount]);
        enemyLocation = enemyLocations[enemyCount];

        if (playerTransform.position.x < enemyLocation)
        {
            Debug.Log("enemy is farther right than player");
            movingRight = true;
        }
        else if (playerTransform.position.x > enemyLocation)
        {
            Debug.Log("enemy is farther left than player");
            movingLeft = true;
        }
    }

    private void Stop()
    {
        movingLeft = false;
        movingRight = false;
    }
    private void Shoot()
    {
        Debug.Log("enemy is at the same x position as player");
        // Instantiate shot from shotSpawn location
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        GetComponent<AudioSource>().Play();
    }

    private void SeekNextEnemy()
    {
        enemyCount++;
        if (enemyCount < enemyLocations.Length)  // Player has moves left
        {
            Debug.Log("Number of enemies left: " + GameObject.FindGameObjectsWithTag("Enemy").Length);
            EnactWaveOne(enemyCount);
        }
        else // Player has no moves left in this block
        { 
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                // all enemies are destroyed
                // Player wins the level
                Debug.Log("Player Wins the Level!");
            }
            else
            {
                // there are enemies left
                // Player gets feedback on why their code didn't work
                Debug.Log("That code didn't work!");
            }
        }
    }

}
