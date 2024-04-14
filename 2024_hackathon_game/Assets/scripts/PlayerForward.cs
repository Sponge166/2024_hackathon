using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    private float speed = 6.0f;
    private float acceleration = 1.1f;
    public Transform Player;
    private float timer = 10f;
    private float spawntimer = 2f;
    private float hardTimer = 100f;
    public GameObject Eva;
    public Queue<GameObject> Evas;
    // Start is called before the first frame update
    void Start()
    {
        Evas = new Queue<GameObject> ();
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
        RemoveEvaBehindPlayer();
    }

    void SpawnObject()
    {
        if (Eva != null)
        {
            float x = Random.Range(0,3);

            x *= 3;
            x += 1.5f;

            // x in {1.5, 4.5, 7.5}

            Vector3 spawnPosition = new Vector3(x, transform.position.y-.5f, transform.position.z + 12);

            Evas.Enqueue(Instantiate(Eva, spawnPosition, Quaternion.Euler(0,180,0)));
        }
    }

    void RemoveEvaBehindPlayer()
    {
        GameObject oldestEva = null;
        if (Evas.TryPeek(out oldestEva)) { 
            if (oldestEva.transform.position.z < transform.position.z-2) {
                // if oldest eva is at least 1 unit behind player delete it
                Object.Destroy(oldestEva);
                Evas.Dequeue();
            }
        }
    }

}
