using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class InfTrack : MonoBehaviour
{

    private GameObject player;
    public GameObject hallwayprefab;
    private GameObject copy;
    private int length = 150;
    private Vector3 delta_vec;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        //length = get length from hallway prefab
        delta_vec = new Vector3(0, 0, length);
        copy = Instantiate(hallwayprefab, delta_vec, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.z-10 > transform.position.z & player.transform.position.z-10 > copy.transform.position.z)
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
