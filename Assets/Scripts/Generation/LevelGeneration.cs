using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] obsitcles;
    public GameObject platform;
    public GameObject[] powerUps;
    public float spawnCoolDown = 20f;

    private void Start()
    {

    }

    private void Update()
    {
        if (spawnCoolDown <= Player.transform.position.x)
        {
            spawnCoolDown += 50;
            SpawnObsitcles();
            SpawnGround();
        }
    }
    void SpawnObsitcles()
    {
        GameObject plat = Instantiate(obsitcles[Random.Range(0,obsitcles.Length)], new Vector3(Player.transform.position.x + 100, 0f), transform.rotation) as GameObject;
    }

    void SpawnGround()
    {
        GameObject plat = Instantiate(platform, new Vector3(Player.transform.position.x + 100, 0f), transform.rotation) as GameObject;
    }
}
