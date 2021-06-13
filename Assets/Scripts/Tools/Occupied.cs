#region

using UnityEngine;

#endregion
public class Occupied : MonoBehaviour
{
    public string occupiedBy;
    private Transform pos_1;
    private Transform pos_2;
    public Vector3 freeSlot;

    private void Awake()
    {
        pos_1 = transform.Find("Pos_1").transform;
        pos_2 = transform.Find("Pos_2").transform;
        freeSlot = pos_1.position;
    }

    private void FixedUpdate()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(pos_1.position, 1);
        freeSlot = pos_1.position;
        foreach (Collider2D detectedObject in detectedObjects)
        {
            if (detectedObject.gameObject.CompareTag("Pauline") || detectedObject.gameObject.CompareTag("Adrien"))
            {
                occupiedBy = detectedObject.gameObject.tag;
                freeSlot = pos_2.position;
            }
        }
    }
}