using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.TrigonoFunction
{
    public class TrigonoFunction : MonoBehaviour
    {
        //Getting Direction from angle
        /* [SerializeField]
         private float angleInDegrees;

         void Update()
         {
            Vector3 direction = new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
             Debug.DrawRay(transform.position, direction * 5, Color.green);
         }*/

            //Getting Angle from direction
        [SerializeField]
        private float angleInDegrees;

        private void Update()
        {
            Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            float inputAngle = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.up * inputAngle;
        }
    }
}
