using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipLevel : MonoBehaviour {

    private AudioSource audioSource;
    public GameObject shot;
    public Transform shotSpawn;

    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        audioSource.Play();
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
