using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.EnemyChase
{
    public class EnemyChase : MonoBehaviour
    {

        [SerializeField]
        Transform targetTransform;
        [SerializeField]
        float speed;

        void Update()
        {
            Vector3 displacementFromTargetPosition = targetTransform.position - transform.position;
            Vector3 directionToTarget = displacementFromTargetPosition.normalized;
            Vector3 velocity = directionToTarget * speed;

            float distanceToTarget = displacementFromTargetPosition.magnitude;
            Debug.Log(distanceToTarget);

            if (distanceToTarget > 1.5f)
            {
                transform.Translate(velocity * Time.deltaTime);
            }
        }
    }
}

