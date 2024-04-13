using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    private float speed = 6.0f;
    private float acceleration = 1.1f;
    public Transform Player;
    private float timer = 10f;
    private float spawntimer = 2f;
    public GameObject Eva;
    // Start is called before the first frame update
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        spawntimer -= Time.deltaTime;
        if (spawntimer < 0) { 
            SpawnObject();
            spawntimer = 2;
        }
        if (timer < 0) { 
            speed *= acceleration;
            speed = Mathf.Min(speed, 20f);
            timer = 10;
        }
        float zPosUpdate = gameObject.transform.position.z;
        zPosUpdate += speed * Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zPosUpdate);
    }

    void SpawnObject()
    {
        if (Eva != null)
        {
            Vector3 spawnDirection = transform.forward;

            Vector3 spawnPosition = transform.position + spawnDirection * 10;

            spawnPosition += spawnDirection * 2f;

            spawnPosition.y = transform.position.y;

            int x = Random.Range(1,4);

            x *= 2;
            x -= 1;

            spawnPosition.x = transform.position.x-x;

            Instantiate(Eva, spawnPosition, Quaternion.identity);
        }
    }

}
