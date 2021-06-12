#region

using UnityEngine;

#endregion
public class Occupied : MonoBehaviour
{
    public bool occupied = false;
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
        occupied = false;
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(pos_1.position, 1);
        freeSlot = pos_1.position;
        foreach (Collider2D detectedObject in detectedObjects)
        {
            if (detectedObject.gameObject.tag == "Pauline" || detectedObject.gameObject.tag == "Adrien")
            {
                occupied = true;
                occupiedBy = detectedObject.gameObject.tag;
                freeSlot = pos_2.position;
            }
        }
    }
}