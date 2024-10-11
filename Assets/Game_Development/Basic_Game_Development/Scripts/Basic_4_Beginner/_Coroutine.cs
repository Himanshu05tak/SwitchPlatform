using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner._Corountine
{
    public class _Coroutine : MonoBehaviour
    {
        [SerializeField]
        private Transform[] path;

        IEnumerator currentMoveCoroutine;
        

        void Start()
        {
            string[] message = { "Welcome", "to", "My", "World" };
            StartCoroutine(PrintMessage(message, 2f));
            StartCoroutine(FollowPath());
            //StartCoroutine(Move(Random.onUnitSphere * 10, 10f));
        }

        private void Update()
        {  
            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                if (currentMoveCoroutine!=null)
                {
                    StopCoroutine(currentMoveCoroutine);
                }
                currentMoveCoroutine = Move(Random.onUnitSphere * 10, 10f);
                StartCoroutine(currentMoveCoroutine);
               
            }
        }

        IEnumerator PrintMessage(string[] messages, float delay)
        {
            foreach (string msg in messages)
            {
                Debug.Log(msg);
                yield return new WaitForSeconds(delay);
            }
        }
        IEnumerator Move(Vector3 destination, float speed)
        {
            while (transform.position!=destination)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                yield return new WaitForSeconds(0.5f);
            }
        }

        IEnumerator FollowPath()
        {
            foreach (Transform waypoint in path)
            {
                yield return StartCoroutine(Move(waypoint.position, 10));
            }
        }
    }
}
