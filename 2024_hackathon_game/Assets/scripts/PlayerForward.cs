using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    public float speed = 6.0f;
    private float acceleration = 1.4f;
    public Transform Player;
    private float timer = 10f;
    private float spawntimer = 2f;
    public GameObject prof1;
    public GameObject prof2;
    public GameObject prof3;
    public Queue<GameObject> profs;
    private List<GameObject> prof_arr;
    // Start is called before the first frame update
    void Start()
    {
        profs = new Queue<GameObject> ();
        prof_arr = new List<GameObject>();
        prof_arr.Add(prof1);
        prof_arr.Add(prof2);
        prof_arr.Add(prof3);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        spawntimer -= Time.deltaTime;
        if (spawntimer < 0) { 
            SpawnObject();
            spawntimer = .5f;
        }
        if (timer < 0) { 
            speed *= acceleration;
            speed = Mathf.Min(speed, 30f);
            timer = 10;
        }
        float zPosUpdate = gameObject.transform.position.z;
        zPosUpdate += speed * Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zPosUpdate);
        RemoveEvaBehindPlayer();
    }

    void SpawnObject()
    {
        if (prof1 != null & prof2 != null & prof3 != null)
        {
            float x = Random.Range(0, 3);
            float x2;
            do
            {
                x2 = Random.Range(0, 3);
            } while (x2 == x);

            x *= 3;
            x += 1.5f;

            // x in {1.5, 4.5, 7.5}

            GameObject prof;

            prof = prof_arr[Random.Range(0, 3)];

            Vector3 spawnPosition = new Vector3(x, prof.transform.position.y, transform.position.z + 25);

            profs.Enqueue(Instantiate(prof, spawnPosition, Quaternion.Euler(0,180,0)));
            
            x2 *= 3;
            x2 += 1.5f;

            // x in {1.5, 4.5, 7.5}
            prof = prof_arr[Random.Range(0, 3)];

            spawnPosition.x = x2;

            profs.Enqueue(Instantiate(prof, spawnPosition, Quaternion.Euler(0, 180, 0)));

            BoxCollider existingCollider = prof1.GetComponent<BoxCollider>();

            if (existingCollider == null)
            {
                // Add BoxCollider component
                BoxCollider collider = prof1.AddComponent<BoxCollider>(); // Adjust collider type as needed
                collider.isTrigger = true; // Set as trigger for trigger-based collision detection
            }

            existingCollider = prof2.GetComponent<BoxCollider>();

            if (existingCollider == null)
            {
                // Add BoxCollider component
                BoxCollider collider = prof2.AddComponent<BoxCollider>(); // Adjust collider type as needed
                collider.isTrigger = true; // Set as trigger for trigger-based collision detection
            }

            existingCollider = prof3.GetComponent<BoxCollider>();

            if (existingCollider == null)
            {
                // Add BoxCollider component
                BoxCollider collider = prof3.AddComponent<BoxCollider>(); // Adjust collider type as needed
                collider.isTrigger = true; // Set as trigger for trigger-based collision detection
            }
        }
    }

    void RemoveEvaBehindPlayer()
    {
        GameObject oldestEva = null;
        if (profs.TryPeek(out oldestEva)) { 
            if (oldestEva.transform.position.z < transform.position.z-2) {
                // if oldest eva is at least 1 unit behind player delete it
                Object.Destroy(oldestEva);
                profs.Dequeue();
            }
        }
    }

}
