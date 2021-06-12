#region

using UnityEngine;

#endregion
public class Vibrator : MonoBehaviour
{
    private float vibrationIterrator;
    public float vibrationStrength = 0.01f;
    public bool vibrateX = false;
    public bool vibrateY = true;


    // Update is called once per frame
    private void Update()
    {
        vibrationIterrator++;

        float vibrationY = 0;
        if (vibrateY)
        {
            vibrationY = Mathf.Sin(vibrationIterrator) * vibrationStrength;
        }
        else
        {
            vibrationY = 0;
        }

        float vibrationX = 0;
        if (vibrateX)
        {
            vibrationX = Mathf.Sin(vibrationIterrator) * vibrationStrength;
        }
        else
        {
            vibrationX = 0;
        }

        transform.position = new Vector3(transform.position.x + vibrationX, transform.position.y + vibrationY, transform.position.z);
    }
}