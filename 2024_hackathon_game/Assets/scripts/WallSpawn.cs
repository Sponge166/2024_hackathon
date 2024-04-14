using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{

    private GameObject player;
    public GameObject wall;
    private GameObject copy;
    private int length = 10;
    private Vector3 delta_vec;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        //length = get length from hallway prefab
        delta_vec = new Vector3(length, 0, 0);
        copy = Instantiate(wall, delta_vec, Quaternion.identity);
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
