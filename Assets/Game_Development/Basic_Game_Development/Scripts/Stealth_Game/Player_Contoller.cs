using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Stealth_Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class Player_Contoller : MonoBehaviour
    {
        public static event System.Action OnReachedEndOfLevel;

        [Header("Speed")]
        [SerializeField]
        private float moveSpeed;
        [SerializeField]
        private float turnSpeed;
        [SerializeField]
        private float smoothMoveTime;

        [Header("CurrentTime")]
        [SerializeField]
        private float angle;
        [SerializeField]
        private float smoothInputMagnitude;
        [SerializeField]
        private float smoothMoveVelocity;
        [SerializeField]
        private Vector3 velocity;

        bool disabled;
        Rigidbody rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            Guard.OnGuardHasSpottedPlayer += Disable;
        }

        private void Update()
        {
            Vector3 inputMove = Vector3.zero;
            if (!disabled)
            {
                inputMove = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            }
            float inputMagnitude = inputMove.magnitude;
            smoothInputMagnitude = Mathf.SmoothDamp(smoothInputMagnitude, inputMagnitude, ref smoothMoveVelocity, smoothMoveTime);

            float targetAngle = Mathf.Atan2(inputMove.x, inputMove.z) * Mathf.Rad2Deg;
            angle = Mathf.LerpAngle(angle, targetAngle, Time.deltaTime * turnSpeed * inputMagnitude);

            velocity = transform.forward * moveSpeed * smoothInputMagnitude;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Finish")
            {
                Disable();
                if (OnReachedEndOfLevel != null) 
                {
                    OnReachedEndOfLevel();
                }
            }
            
        }

        void Disable()
        {
            disabled = true;
        }

        private void FixedUpdate()
        {
            rb.MoveRotation(Quaternion.Euler(Vector3.up * angle));
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }

        private void OnDestroy()
        {
            Guard.OnGuardHasSpottedPlayer -= Disable;
        }
    }
}
