using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTwoExercise : MonoBehaviour {

    //**** player ship information ****//

    public GameObject shot;
    public Transform shotSpawn;
    public Transform playerTransform;
    public float thrust = 3;

    private bool movingLeft = false;
    private bool movingRight = false;

    //**** player ship information ****//


    //**** wave and enemy information ****//

    // enemy location information
    private float[] enemyLocations = { 0, 0, 0, 0 };
    private int enemyCount;

    // the player's answer code to the exercise
    private enum Level { Win, Lose }
    Level level;
    private GameObject safeguardPanel;
    private GameObject nextLevelPanel;

    //**** wave and enemy information ****//


    private void Update()
    {
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

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        safeguardPanel = GameObject.FindGameObjectWithTag("WaveSafeguard");
        nextLevelPanel = GameObject.FindGameObjectWithTag("NextLevel");
    }

    public void EnactOption1()
    {
        level = Level.Lose;

        enemyLocations[0] = 1;
        enemyLocations[1] = 1;
        enemyLocations[2] = 1;
        enemyLocations[3] = 1;
        enemyCount = 0;

        EnactWaveOne(enemyLocations[enemyCount]);
    }

    public void EnactOption2()
    {
        level = Level.Lose;

        enemyLocations[0] = 1;
        enemyLocations[1] = 3;
        enemyLocations[2] = 5;
        enemyLocations[3] = 7;
        enemyCount = 0;

        EnactWaveOne(enemyLocations[enemyCount]);
    }

    public void EnactOption3()
    {
        level = Level.Lose;

        enemyLocations[0] = 1;
        enemyLocations[1] = 4;
        enemyLocations[2] = 7;
        enemyLocations[3] = 10;
        enemyCount = 0;

        EnactWaveOne(enemyLocations[enemyCount]);
    }

    public void EnactOption4()
    {
        level = Level.Win;

        enemyLocations[0] = 3;
        enemyLocations[1] = 6;
        enemyLocations[2] = 9;
        enemyLocations[3] = 12;
        enemyCount = 0;

        EnactWaveOne(enemyLocations[enemyCount]);
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
            safeguardPanel.gameObject.SetActive(false);
            //safeGuardPanel.SetActive(false);

            if (level == Level.Win)
            {
                // all enemies are destroyed
                // Player wins the level
                // SetActive a button to go to next level
                nextLevelPanel.gameObject.SetActive(false);

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
