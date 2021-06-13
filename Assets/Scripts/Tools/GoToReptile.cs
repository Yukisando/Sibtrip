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
        image.color = MapSettings.reptileLocked ? Color.red : Color.green;
    }

    public void LoadReptile()
    {
        if (!MapSettings.reptileLocked)
        {
            SceneManager.LoadScene("Reptile");
        }
    }
}