#region

using UnityEngine;

#endregion
public class PaulineMovementTrack : MonoBehaviour
{
    public Transform[] slots;

    private int currentSlot;
    private bool moving;

    // Use this for initialization
    private void Start()
    {
        transform.position = slots[0].GetComponent<Occupied>().freeSlot;
    }

    // Update is called once per frame
    private void Update()
    {
        float move = Input.GetAxisRaw("Vertical2");

        if (!moving && move != 0)
        {
            GoToNextSlot(move);
            moving = true;
        }
        if (move == 0)
        {
            moving = false;
        }

        if (slots[currentSlot].GetComponent<Occupied>().occupiedBy == "Adrien")
        {
            transform.position = slots[currentSlot].GetComponent<Occupied>().freeSlot;
        }
    }

    private void GoToNextSlot(float direction)
    {
        int nextMove = currentSlot - (int)direction;

        if (nextMove < slots.Length && nextMove >= 0)
        {
            transform.position = slots[nextMove].GetComponent<Occupied>().freeSlot;
            currentSlot = nextMove;
        }
    }
}