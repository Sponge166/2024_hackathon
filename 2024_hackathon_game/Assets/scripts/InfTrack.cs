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
    public int length;
    private Vector3 delta_vec;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        //length = get length from hallway prefab
        delta_vec = new Vector3(0, 0, length);
        if (length==150){
            copy = Instantiate(hallwayprefab, delta_vec, Quaternion.identity);
        }
        else if(length == 65){
            copy = Instantiate(hallwayprefab, delta_vec + new Vector3(0, 2.5f, 0), Quaternion.Euler(90,0,270));
        }
        else{
             copy = Instantiate(hallwayprefab, delta_vec + new Vector3(9, 2.5f, 0), Quaternion.Euler(90,0,90));
        }
       
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
