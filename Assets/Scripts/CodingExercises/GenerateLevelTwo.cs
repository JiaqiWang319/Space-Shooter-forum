﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevelTwo : MonoBehaviour
{
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

    public void SpawnWaveOne()
    {
        if (hazards.Length != 0)
        {
            GameObject[] destroyHazards = GameObject.FindGameObjectsWithTag("Enemy");

            for (var i = 0; i < destroyHazards.Length; i++)
                Destroy(destroyHazards[i]);
        }

        for (int i = 0; i < hazardCount; i++)
        {
            GameObject hazard = hazards[i];

            Vector3 spawnPosition = new Vector3(xPos + xOffset, 0f, zPos + zOffset);
            //Vector3 spawnPosition = new Vector3(8, 0f, zPos + zOffset);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(hazard, spawnPosition, spawnRotation);

            xOffset += 3;
            if (xOffset >= xMax) { xOffset = 0; /*zOffset += 3;*/ }
        }
    }

    public void TryAgain()
    {
        GameObject[] destroyHazards = GameObject.FindGameObjectsWithTag("Enemy");

        if (destroyHazards.Length != 0)
        {
            for (var i = 0; i < destroyHazards.Length; i++)
                Destroy(destroyHazards[i]);
        }

        SpawnWaveOne();
    }
}