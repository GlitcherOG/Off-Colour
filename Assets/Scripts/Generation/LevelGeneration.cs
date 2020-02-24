using System.Collections;
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
    public bool debug;
    private void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject plat = Instantiate(platform, new Vector3(Player.transform.position.x + 50 * i, 0f), transform.rotation) as GameObject;
            GameObject back = Instantiate(backgroundObjects[Random.Range(0, backgroundObjects.Length)], new Vector3(Player.transform.position.x + 30 * i, 0f), transform.rotation) as GameObject;
        }
    }

    private void Update()
    {
        if (spawnCoolDown <= Player.transform.position.x)
        {
            spawnCoolDown += 50;
            SpawnGround();
        }
        if (objectCoolDown <= Player.transform.position.x && debug)
        {
            SpawnObsitcles();
        }
    }
    void SpawnObsitcles()
    {
        GameObject obj = Instantiate(obsitcles[Random.Range(0, obsitcles.Length)], new Vector3(Player.transform.position.x + 100, 0f), transform.rotation) as GameObject;
        objectCoolDown = obj.GetComponent<PrefabModule>().cooldown + Player.transform.position.x;
    }

    void SpawnGround()
    {
       GameObject plat = Instantiate(platform, new Vector3(Player.transform.position.x + 250, 0f), transform.rotation) as GameObject;
    }
}
