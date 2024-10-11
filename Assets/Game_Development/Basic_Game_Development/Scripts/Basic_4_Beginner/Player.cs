using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField]
        float speed;
        [SerializeField]
        //private Rigidbody myRigidbody;
       
        private Vector3 velocity;
        
        private void Start()
        {
            //myRigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
            Vector3 direction = input.normalized;
            velocity = direction * speed;

           Vector3 movement = velocity * Time.deltaTime;
           // transform.position += movement;
           transform.Translate(movement);
        }
       /* private void FixedUpdate()
        {
            myRigidbody.position += velocity * Time.deltaTime;
        }*/

       /* private void OnTriggerEnter(Collider otherCollider)
        {
            if (otherCollider.tag == "Coin")
            {
                Destroy(otherCollider.gameObject);
                Debug.Log(otherCollider.gameObject.name);
            }
            
           
        }*/
    }
}
