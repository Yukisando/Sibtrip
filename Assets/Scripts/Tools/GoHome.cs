using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour {

    public void LoadHome()
    {
        SceneManager.LoadScene("Home");
    }
}
