using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float seconds_to_lane_change = .1f;
    private GameObject player;
    private GameObject cam;
    private Transform ptran;
    private Transform ctran;
    private Vector3 delta_vec;
    private Vector3 ppos_when_pressed;
    private Vector3 pgoal_when_pressed;
    private Vector3 cpos_when_pressed;
    private Vector3 cgoal_when_pressed;
    private float timer = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        ptran = player.transform;
        delta_vec = new Vector3(3, 0, 0);
        cam = GameObject.Find("3rd_person_cam");
        ctran = cam.transform;
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
                timer = 0f;
                ptran.position = pgoal_when_pressed;
                ctran.position = cgoal_when_pressed;
            }
            else
            {
                ptran.position = Vector3.Lerp(ppos_when_pressed, pgoal_when_pressed, perc);
                ctran.position = Vector3.Lerp(cpos_when_pressed, cgoal_when_pressed, perc);
            }
        }

        if (timer == 0 & Input.GetKeyDown(KeyCode.D) & ptran.position.x < 7.5)
        {
            ppos_when_pressed = ptran.position;
            pgoal_when_pressed = ptran.position + delta_vec;

            cpos_when_pressed = ctran.position;
            cgoal_when_pressed = cpos_when_pressed + delta_vec / 2;

            timer += Time.deltaTime;
        }

        if (timer == 0 & Input.GetKeyDown(KeyCode.A) & ptran.position.x > 1.5)
        {
            ppos_when_pressed = ptran.position;
            pgoal_when_pressed = ptran.position - delta_vec;

            cpos_when_pressed = ctran.position;
            cgoal_when_pressed = cpos_when_pressed - delta_vec / 2;

            timer += Time.deltaTime;
        }
    }
}
