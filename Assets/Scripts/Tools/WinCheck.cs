using UnityEngine;

public class WinCheck : MonoBehaviour {

    void Update () {
        if(Settings.win) transform.GetChild(0).gameObject.SetActive(true);
	}
}
