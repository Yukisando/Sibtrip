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
        image.color = MapSettings.tarongaLocked ? Color.red : Color.green;
    }

    public void LoadTaronga()
    {
        if (!MapSettings.tarongaLocked)
        {
            SceneManager.LoadScene("Taronga");
        }
    }
}