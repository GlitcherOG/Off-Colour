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
    public float objectCoolDown = 20f;

    private void Start()
    {

    }

    private void Update()
    {
        if (spawnCoolDown <= Player.transform.position.x)
        {
            spawnCoolDown += 50;
            SpawnGround();
        }
        if (objectCoolDown <= Player.transform.position.x)
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
        GameObject plat = Instantiate(platform, new Vector3(Player.transform.position.x + 100, 0f), transform.rotation) as GameObject;
    }
}
