﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] obsitcles;
    public GameObject platform;
    public GameObject[] powerUps;
    public GameObject[] backgroundObjects;
    public float spawnCoolDown = 0f;
    public float objectCoolDown = 20f;
    public float backgroundCoolDown = 20f;
    public float prevBack;
    public bool debug;
    private void Start()
    {
        for (int i = -1; i < 7; i++)
        {
            GameObject plat = Instantiate(platform, new Vector3(Player.transform.position.x + 50 * i, 0f), transform.rotation) as GameObject;
        }
    }

    private void Update()
    {
        if (spawnCoolDown <= Player.transform.position.x)
        {
            SpawnGround();
        }
        if (backgroundCoolDown <= Player.transform.position.x)
        {
            BackGroundSpawn();
        }
        if (objectCoolDown <= Player.transform.position.x && debug)
        {
            SpawnObsitcles();
        }
    }
    void SpawnObsitcles()
    {
        GameObject obj = Instantiate(obsitcles[Random.Range(0, obsitcles.Length)], new Vector3(objectCoolDown + 100, 0f), transform.rotation) as GameObject;
        objectCoolDown = obj.GetComponent<PrefabModule>().cooldown + Player.transform.position.x;
    }

    void SpawnGround()
    {
        GameObject plat = Instantiate(platform, new Vector3(spawnCoolDown + 240, 0f), transform.rotation) as GameObject;
        spawnCoolDown += 50;
    }

    void BackGroundSpawn()
    {
        int temp = Random.Range(0, backgroundObjects.Length);
        while(temp==prevBack)
        {
            temp = Random.Range(0, backgroundObjects.Length);
        }
        GameObject back = Instantiate(backgroundObjects[temp], new Vector3(backgroundCoolDown + 100, 0f), transform.rotation) as GameObject;
        prevBack = temp;
        backgroundCoolDown += (float)Random.Range(6, 9);
    }
}
