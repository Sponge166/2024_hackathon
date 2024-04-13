using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    public float speed = 6.0f;
    public float acceleration = 1.1f;
    public Transform Player;
    private float timer = 10f;
    private float spawntimer = 2f;
    private float hardTimer = 100f;
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
        hardTimer -= Time.deltaTime;
        if (hardTimer < 0) {
            SpawnObject();
            hardTimer = 0;
        }
        else if (spawntimer < 0) { 
            SpawnObject();
            spawntimer = 2;
        }
        if (timer < 0) { 
            speed *= acceleration;
            speed = Mathf.Min(speed, 20f);
            timer = 5;
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
