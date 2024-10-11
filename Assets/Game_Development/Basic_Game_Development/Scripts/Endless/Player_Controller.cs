using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Endless
{
    public class Player_Controller : MonoBehaviour
    {
        [SerializeField]
        private float speed;
        [SerializeField]
        private float screenHalfWidth;
        public event System.Action OnPlayerDeath;

        void Start()
        {
            float halfPlayerWidth = transform.localScale.x / 2;
            screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
        }

        void Update()
        {
            float input = Input.GetAxisRaw("Horizontal");
            float velocity = input * speed;
            transform.Translate(Vector2.right * velocity * Time.deltaTime);

            if (transform.position.x > screenHalfWidth) 
            {
                transform.position = new Vector2(-screenHalfWidth, transform.position.y);
            }
            else if (transform.position.x < -screenHalfWidth)
            {
                transform.position = new Vector2(screenHalfWidth, transform.position.y);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Obstacle")
            {
                if (OnPlayerDeath!=null)
                {
                    OnPlayerDeath();
                }    
                Destroy(gameObject);
            }
        }
    }
}

