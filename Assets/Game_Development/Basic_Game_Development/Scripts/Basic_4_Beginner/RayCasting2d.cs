using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Raycasting2d
{
    public class RayCasting2d : MonoBehaviour
    {
        void Start()
        {
            Physics2D.queriesStartInColliders = false;
        }


        void Update()
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, 100);
            if (hitInfo.collider != null) 
            {
                Debug.DrawLine(transform.position,transform.right, Color.red);
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position+transform.right * 100, Color.green);
            }
        }
    }
}
