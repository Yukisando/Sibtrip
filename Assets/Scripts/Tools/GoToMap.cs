#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion
public class GoToMap : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Adrien") || collision.gameObject.CompareTag("Pauline"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name == "Home" ? "Map" : "Home");
        }
    }

    private void OnEnable()
    {
        if (SceneManager.GetActiveScene().name != "Home")
        {
            Invoke(nameof(GoMap), 6);
        }
    }

    private void GoMap()
    {
        SceneManager.LoadScene("Home");
    }
}