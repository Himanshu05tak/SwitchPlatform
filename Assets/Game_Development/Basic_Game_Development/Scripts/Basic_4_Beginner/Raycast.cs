using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Raycast
{
    public class Raycast : MonoBehaviour
    {
        [SerializeField]
        private Transform objectToplace;
        [SerializeField]
        private Camera gameCamera;

        void Update()
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray,out hitInfo))
            {
                objectToplace.position = hitInfo.point;
                objectToplace.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            }
        }
    }
}

