using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void load(string name){
        SceneManager.LoadScene(name);
    }
}
