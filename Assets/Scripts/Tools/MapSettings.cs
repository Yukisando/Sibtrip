#region

using TMPro;
using UnityEngine;

#endregion
public class MapSettings : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI codeInputField;

    public static bool tarongaLocked = true;
    public static bool lunaLocked = true;
    public static bool reptileLocked = true;

    private void Start()
    {
        if (PlayerPrefs.HasKey("taronga") && PlayerPrefs.GetInt("taronga") == 1)
        {
            Debug.Log("Taronga unlocked");
            tarongaLocked = false;
        }

        if (PlayerPrefs.HasKey("luna") && PlayerPrefs.GetInt("luna") == 1)
        {
            Debug.Log("Luna unlocked");
            lunaLocked = false;
        }

        if (PlayerPrefs.HasKey("reptile") && PlayerPrefs.GetInt("reptile") == 1)
        {
            Debug.Log("Reptile unlocked");
            reptileLocked = false;
        }
    }

    public void UnlockLevel()
    {
        var code = codeInputField.text;

        switch (code)
        {
            case "2061":
                PlayerPrefs.SetInt("taronga", 1);
                Debug.Log("Taronga unlocked");

                lunaLocked = false;
                break;
            case "safari":
                PlayerPrefs.SetInt("luna", 1);
                Debug.Log("Luna unlocked");

                tarongaLocked = false;
                break;
            case "i love spiders":
                PlayerPrefs.SetInt("reptile", 1);
                Debug.Log("Reptile unlocked");

                reptileLocked = false;
                break;
            default:
                Debug.Log($"Wrong Password: {codeInputField.text}");
                break;
        }

    }

    public void ResetGame()
    {
        lunaLocked = true;
        reptileLocked = true;
        tarongaLocked = true;

        PlayerPrefs.DeleteAll();
    }

    public void FriendlyFireToggle()
    {
        Settings.friendlyFire = !Settings.friendlyFire;
    }
}