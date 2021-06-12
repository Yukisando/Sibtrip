#region

using TMPro;
using UnityEngine;

#endregion
public class GameInfo : MonoBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Stage: " + EnemyStats.stage + " Health: " + EnemyStats.health;
    }
}