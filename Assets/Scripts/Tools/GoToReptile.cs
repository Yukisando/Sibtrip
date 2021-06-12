#region

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#endregion
public class GoToReptile : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        if (LevelUnlocker.reptileLocked)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.green;
        }
    }

    public void LoadReptile()
    {
        if (!LevelUnlocker.reptileLocked)
        {
            SceneManager.LoadScene("Reptile");
        }
    }
}