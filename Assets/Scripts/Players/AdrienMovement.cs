using UnityEngine;

namespace UnityStandardAssets._2D {
    [RequireComponent(typeof(Character))]
    public class AdrienMovement : MonoBehaviour {
        private Character m_Character;
        private bool m_Jump;
        private Vector3 spawnPosition;


        private void Awake() {
            m_Character = GetComponent<Character>();
        }

        private void Start() {
            spawnPosition = transform.position;
        }


        private void Update() {
            AdrienStats.facingRight = m_Character.m_FacingRight;
            if(!m_Jump) {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump");
                if(Settings.controller) m_Jump = Input.GetButtonDown("JumpC");
            }
        }


        private void FixedUpdate() {
            // Read the inputs.
            bool crouch = Input.GetButton("Crouch");
            if(Settings.controller) crouch = Input.GetButtonDown("CrouchC");

            float h = Input.GetAxis("Horizontal");
            if(Settings.controller) h = Input.GetAxis("HorizontalC");

            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

        private void OnBecameInvisible() {
            transform.position = spawnPosition;
        }
    }
}
