using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForward : MonoBehaviour
{
    public float speed = 6.0f;
    public float acceleration = 1.05f;
    public Transform Player;
    private float timer = 10f;
    private float prev = 0;
    // Start is called before the first frame update
    void Start()
    {
        Update();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0) { 
            speed = speed*acceleration;
            speed = Mathf.Min(speed, 20f);
            timer = 10;
        }
        float zPosUpdate = gameObject.transform.position.z;
        zPosUpdate += speed * Time.deltaTime;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, zPosUpdate);
    }
}
