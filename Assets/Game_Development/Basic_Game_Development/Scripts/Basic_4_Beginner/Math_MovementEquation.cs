using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Math_MovementEquation
{
    public class Math_MovementEquation : MonoBehaviour
    {
        void Start()
        {
            float dist = DistanceBtwPointAtoPointB(0, 5, 10, 15);
            Debug.Log(dist);
        }

        float DistanceBtwPointAtoPointB(float x1, float y1, float x2, float y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float dxy = dx * dx + dy * dy;
            float dist = Mathf.Sqrt(dxy);
            return dist;
        }
    }
}
