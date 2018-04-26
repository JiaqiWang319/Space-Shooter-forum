using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipLevel : MonoBehaviour {

    //**** player ship information ****//

    public GameObject shot;
    public Transform shotSpawn;
    public Transform playerTransform;
    public AudioSource playerBolt;
    public float thrust = 3;

    private bool movingLeft = false;
    private bool movingRight = false;

    //**** player ship information ****//



    //**** Enemy Ship Information ****//

    public AudioSource enemyBolt;
    public GameObject enemyShot;
    public Transform enemyShotSpawn;
    public Transform enemyTransform;

    private float enemyLocation;
    private bool enemyMovingLeft = false;
    private bool enemyMovingRight = false;

    private float[] enemyLocations = { 0, 0, 0, 0 };
    private int enemyCount;

    //**** Enemy Ship Information ****//



    //**** the player's answer code to the exercise ****//

    private enum Level { Win, Lose }
    Level level;
    private GameObject safeguardPanel;
    private GameObject nextLevelPanel;

    //**** the player's answer code to the exercise ****//


    private void Update()
    {
        if (enemyMovingLeft && enemyTransform.position.x <= playerTransform.position.x)  // enemy and player x positions are the same, so just fire
        {
            EnemyStop();
            EnemyShoot();
            //SeekNextEnemy();
            safeguardPanel.gameObject.SetActive(false);
        }
        else if (enemyMovingRight && enemyTransform.position.x >= playerTransform.position.x)
        {
            EnemyStop();
            EnemyShoot();
            //SeekNextEnemy();
            safeguardPanel.gameObject.SetActive(false);
        }

        if (movingLeft && playerTransform.position.x <= enemyTransform.position.x)  // enemy and player x positions are the same, so just fire
        {
            Stop();
            Shoot();
            //SeekNextEnemy();
            safeguardPanel.gameObject.SetActive(false);
            nextLevelPanel.gameObject.SetActive(false);
        }

        else if (movingRight && playerTransform.position.x >= enemyTransform.position.x)
        {
            Stop();
            Shoot();
            //SeekNextEnemy();
            safeguardPanel.gameObject.SetActive(false);
            nextLevelPanel.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (movingLeft) { playerTransform.Translate(Vector3.left * thrust * Time.deltaTime); }
        else if (movingRight) { playerTransform.Translate(Vector3.right * thrust * Time.deltaTime); }

        if (enemyMovingLeft) { enemyTransform.Translate(Vector3.left * thrust * Time.deltaTime); }
        else if (enemyMovingRight) { enemyTransform.Translate(Vector3.right * thrust * Time.deltaTime); }
    }

    void Start()
    {
        safeguardPanel = GameObject.FindGameObjectWithTag("WaveSafeguard");
        nextLevelPanel = GameObject.FindGameObjectWithTag("NextLevel");
    }

    public void EnactOption1()
    {
        level = Level.Lose;
        EnactWaveOne();
    }

    public void EnactOption2()
    {
        level = Level.Lose;
        EnactWaveOne();
    }

    public void EnactOption3()
    {
        level = Level.Lose;
        EnactWaveOne();
    }

    public void EnactOption4()
    {
        level = Level.Win;
        EnactWaveOne();
    }

    private void EnactWaveOne()
    {

        if (level == Level.Lose)
        {
            if (enemyTransform.position.x < playerTransform.position.x)
            {
                enemyMovingRight = true;
            }
            else if (enemyTransform.position.x > playerTransform.position.x)
            {
                enemyMovingLeft = true;
            }
        }
        else if (level == Level.Win)
        {
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


    }

    private void Stop()
    {
        movingLeft = false;
        movingRight = false;
    }

    private void EnemyStop()
    {
        enemyMovingLeft = false;
        enemyMovingRight = false;
    }

    private void Shoot()
    {
        Debug.Log("enemy is at the same x position as player");
        // Instantiate shot from shotSpawn location
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        playerBolt.Play();
    }

    void EnemyShoot()
    {
        Instantiate(enemyShot, enemyShotSpawn.position, enemyShotSpawn.rotation);
        enemyBolt.Play();
    }


}
