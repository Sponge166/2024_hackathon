using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProfessorSpawn : MonoBehaviour
{
    float x = 5f;
    Vector3 spawn;
    public GameObject Professor;
    public GameObject[] Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        if (Player != null)
        {
            RandomSpawn();
        }
        else{
            Debug.LogError("error finding player");
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(Professor, spawn, Quaternion.identity);
        transform.Translate(Vector3.forward*5*Time.deltaTime);
    }

    void RandomSpawn()
    {
        if (Player != null && Professor != null)
        {
            Vector3 spawnPosition = Player[0].transform.position + new Vector3(Random.Range(-x, x), 0f, Random.Range(-x, x));

            Instantiate(Professor, spawnPosition, Quaternion.identity);
        }
    }
}
