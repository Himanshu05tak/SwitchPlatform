using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Local_Global_Rotation
{
    public class Local_Global_Rotation : MonoBehaviour
    {
        [SerializeField]
        private Transform sphereTransform;
       
        void Start()
        {
            sphereTransform.parent = transform;
            //sphereTransform.localScale = new Vector3(2, 2, 2);
            sphereTransform.localScale = Vector3.one * 2;
        }

        void Update()
        {
            // transform.eulerAngles += new Vector3(0, 180 * Time.deltaTime,);
            //transform.eulerAngles += Vector3.up * 180 * Time.deltaTime;
            transform.Rotate(Vector3.up * 180 * Time.deltaTime, Space.World);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // sphereTransform.position = Vector3.zero;
                sphereTransform.localPosition = Vector3.zero;
            }
            transform.Translate(Vector3.forward * Time.deltaTime * 5, Space.World);
        }
    }
}
