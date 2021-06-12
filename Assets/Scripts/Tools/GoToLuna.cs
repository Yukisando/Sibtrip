#region

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion
public class GoToLuna : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (LevelUnlocker.lunaLocked)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
    }

    public void LoadLuna()
    {
        if (!LevelUnlocker.lunaLocked)
        {
            SceneManager.LoadScene("Luna Park");
        }
    }
}