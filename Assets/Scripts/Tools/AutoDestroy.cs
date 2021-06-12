#region

using UnityEngine;

#endregion
public class AutoDestroy : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 5);
    }
}