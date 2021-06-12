#region

using UnityEngine;

#endregion
public class WinCheck : MonoBehaviour
{

    private void Update()
    {
        if (Settings.win)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}