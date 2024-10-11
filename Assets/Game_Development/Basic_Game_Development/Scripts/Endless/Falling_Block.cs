using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Endless
{
    public class Falling_Block : MonoBehaviour
    {
        [SerializeField]
        private Vector2 speedMinMax;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float visibleThresholdHeight;

        private void Start()
        {
            speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty_Level.GetDifficultPercent());
            visibleThresholdHeight = -Camera.main.orthographicSize - transform.localScale.y;
        }

        void Update()
        {            
          transform.Translate(Vector2.down * speed * Time.deltaTime, Space.Self);
            if (transform.position.y < visibleThresholdHeight) 
            {
                Destroy(gameObject);
            }
        }
    }
}
