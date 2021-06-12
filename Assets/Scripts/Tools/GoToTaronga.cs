#region

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion
public class GoToTaronga : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (LevelUnlocker.tarongaLocked)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
    }

    public void LoadTaronga()
    {
        if (!LevelUnlocker.tarongaLocked)
        {
            SceneManager.LoadScene("Taronga");
        }
    }
}