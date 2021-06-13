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
        image.color = MapSettings.lunaLocked ? Color.red : Color.green;
    }

    public void LoadLuna()
    {
        if (!MapSettings.lunaLocked)
        {
            SceneManager.LoadScene("Luna Park");
        }
    }
}