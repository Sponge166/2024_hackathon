using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfTrack : MonoBehaviour
{

    private GameObject player;
    public GameObject hallwayprefab;
    private GameObject copy;
    private int length = 100;
    private Vector3 delta_vec;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        //length = get length from hallway prefab
        delta_vec = new Vector3(0, 0, length);
        bool x = true;
        if (x)
        {
            copy = Instantiate(hallwayprefab, delta_vec, Quaternion.identity);
            x = false;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z > transform.position.z & player.transform.position.z > copy.transform.position.z)
        {
            if (transform.position.z < copy.transform.position.z)
            {
                transform.position += delta_vec;
            }
            else
            {
                copy.transform.position += delta_vec;
            }
        }
    }
}
