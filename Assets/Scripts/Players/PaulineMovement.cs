namespace UnityStandardAssets._2D
{
    #region

    using UnityEngine;

#endregion
    [RequireComponent(typeof(Character))]
    public class PaulineMovement : MonoBehaviour
    {
        private Character m_Character;
        private bool m_Jump;
        private Vector3 spawnPosition;


        private void Awake()
        {
            m_Character = GetComponent<Character>();
        }

        private void Start()
        {
            spawnPosition = transform.position;
        }


        private void Update()
        {
            PaulineStats.facingRight = m_Character.m_FacingRight;
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump2");
                if (Settings.controller)
                {
                    m_Jump = Input.GetButtonDown("Jump2C");
                }
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetButton("Crouch2");
            if (Settings.controller)
            {
                crouch = Input.GetButtonDown("Crouch2C");
            }

            float h = Input.GetAxis("Horizontal2");
            if (Settings.controller)
            {
                h = Input.GetAxis("Horizontal2C");
            }

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

        private void OnBecameInvisible()
        {
            transform.position = spawnPosition;
        }
    }
}