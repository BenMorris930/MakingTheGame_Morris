using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public GameObject backgroundPrefab;
    private Vector3 spawnLocation = new Vector3(30, 0, 0);
    private int initialWait = 1;
    private int spawnTime = 3;
    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", initialWait, spawnTime);
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        for(int i = 0; i < 20; i++)
        {
            Instantiate(backgroundPrefab, new Vector3(10 * i, 0, 3.5f), backgroundPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        if (playerController.gameOver == false) Instantiate(obstaclePrefab, spawnLocation, obstaclePrefab.transform.rotation);
    }
}
