using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfessorTouch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
            Debug.Log("Player collided with obstacle!");
            SceneManager.LoadScene("loser");
    }

}
