using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMap : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Adrien" || collision.gameObject.tag == "Pauline") {
            if(SceneManager.GetActiveScene().name == "Home")
                SceneManager.LoadScene("Map");
            else
                SceneManager.LoadScene("Home");
        }
    }

    private void OnEnable() {
        if(SceneManager.GetActiveScene().name != "Home") Invoke("GoMap", 6);
    }

    void GoMap() {
        SceneManager.LoadScene("Home");
    }
}
