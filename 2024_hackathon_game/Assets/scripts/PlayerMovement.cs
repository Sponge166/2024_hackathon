using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float seconds_to_lane_change = .1f;
    private GameObject player;
    private Transform tran;
    private Vector3 delta_vec;
    private Vector3 pos_when_pressed;
    private Vector3 goal_when_pressed;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        tran = player.transform;
        delta_vec = new Vector3(3, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            float perc = timer / seconds_to_lane_change;
            timer += Time.deltaTime;
            if (perc > 1)
            {
                perc = 1f;
                timer = 0f;
                tran.position = goal_when_pressed;
            }
            else
            {
                tran.position = Vector3.Lerp(pos_when_pressed, goal_when_pressed, perc);
            }
        }

        if (timer == 0 & Input.GetKeyDown(KeyCode.D) & player.transform.position.x < 7.5)
        {
            pos_when_pressed = tran.position;
            goal_when_pressed = tran.position + delta_vec;
            timer += Time.deltaTime;
        }

        if (timer == 0 & Input.GetKeyDown(KeyCode.A) & player.transform.position.x > 1.5)
        {
            pos_when_pressed = tran.position;
            goal_when_pressed = tran.position - delta_vec;
            timer += Time.deltaTime;
        }
    }
}
