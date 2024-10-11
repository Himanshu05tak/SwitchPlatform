using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Raycasting3d
{
    public class Raycasting_3d : MonoBehaviour
    {
        public  LayerMask mask;
        void Update()
        {
            Ray ray = new Ray(transform.position, transform.up);
            RaycastHit hitinfo;
            if (Physics.Raycast(ray, out hitinfo, 100, mask,QueryTriggerInteraction.Ignore)) 
            {
                Debug.Log(hitinfo.collider.gameObject.name);
                //Destroy(hitinfo.collider.gameObject);
                Destroy(hitinfo.transform.gameObject);
                Debug.DrawLine(ray.origin, hitinfo.point, Color.red);
            }
            else
            {
                Debug.DrawLine(ray.origin,  ray.direction * 100, Color.green);
            }
            
        }
    }
}

