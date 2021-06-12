#region

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion
public class GoHome : MonoBehaviour
{

    public void LoadHome()
    {
        SceneManager.LoadScene("Home");
    }
}