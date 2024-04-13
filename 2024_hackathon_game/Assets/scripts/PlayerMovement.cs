using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float lane_change_speed;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) & player.transform.position.x < 6.5)
        {
            player.transform.position += new Vector3(2, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.A) & player.transform.position.x > 2.5)
        {
            player.transform.position -= new Vector3(2, 0, 0);
        }
    }
}
