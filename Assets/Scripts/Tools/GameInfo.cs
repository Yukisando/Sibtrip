using TMPro;
using UnityEngine;

public class GameInfo : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        GetComponent<TextMeshProUGUI>().text = "Stage: " + EnemyStats.stage.ToString() + " Health: " + EnemyStats.health;
	}
}
