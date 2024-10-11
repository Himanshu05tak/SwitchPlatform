using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Stealth_Game
{
    public class Guard : MonoBehaviour
    {
        public static event System.Action OnGuardHasSpottedPlayer;

        [Header("Velocity")]
        [SerializeField]
        private Transform pathHolder;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float waitTime;
        [SerializeField]
        private float turnSpeed;
        [SerializeField]
        private Transform player;
        [SerializeField]
        private float timeToSpotPlayer;
        [SerializeField]
        private float viewDistance;


        [Header("Light")]
        [SerializeField]
        private Light spotLight;
        [SerializeField]
        private float viewAngle;
        [SerializeField]
        private Color originalSpotLightColor;
        [SerializeField]
        private LayerMask viewMask;


        private float playerVisibleTimer;

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            originalSpotLightColor = spotLight.color;
            viewAngle = spotLight.spotAngle;

            Vector3[] wayPoints = new Vector3[pathHolder.childCount];
            for (int i = 0; i < wayPoints.Length; i++)
            {
                wayPoints[i] = pathHolder.GetChild(i).position;
                wayPoints[i] = new Vector3(wayPoints[i].x, transform.position.y, wayPoints[i].z);
            }
            StartCoroutine(FollowPath(wayPoints));
        }

        private void Update()
        {
            if (CanSeePlayer())
            {
                spotLight.color = Color.red;
               playerVisibleTimer += Time.deltaTime;
            }
            else
            {
                spotLight.color = originalSpotLightColor;
                playerVisibleTimer -= Time.deltaTime;
            }
            playerVisibleTimer = Mathf.Clamp(playerVisibleTimer, 0, timeToSpotPlayer);
            spotLight.color = Color.Lerp(originalSpotLightColor, Color.red, playerVisibleTimer / timeToSpotPlayer);

            if (playerVisibleTimer >= timeToSpotPlayer) 
            {
                if (OnGuardHasSpottedPlayer != null) 
                {
                    OnGuardHasSpottedPlayer();
                }
            }
        }

        private bool CanSeePlayer()
        {
            if (Vector3.Distance(transform.position, player.position) < viewDistance) 
            {
                Vector3 dirToPlayer = (player.position - transform.position).normalized;
                float angleBtwGuardAndPlayer = Vector3.Angle(transform.forward, dirToPlayer);
                if (angleBtwGuardAndPlayer < viewAngle / 2f)  
                {
                    if (!Physics.Linecast(transform.position,player.position,viewMask))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        IEnumerator FollowPath(Vector3[] wayPoints)
        {
            transform.position = wayPoints[0];

            int targetWayPointIndex = 1;
            Vector3 targetWayPoints = wayPoints[targetWayPointIndex];

            transform.LookAt(targetWayPoints);
            while (true) 
            {
                transform.position = Vector3.MoveTowards(transform.position, targetWayPoints, speed * Time.deltaTime);
                if (transform.position == targetWayPoints) 
                {
                    targetWayPointIndex = (targetWayPointIndex + 1) % wayPoints.Length;
                    targetWayPoints = wayPoints[targetWayPointIndex];
                    yield return new WaitForSeconds(waitTime);
                    yield return StartCoroutine(TurnToFace(targetWayPoints));
                }
                yield return null;
            }   
        }
           
        IEnumerator TurnToFace(Vector3 lookAtTarget)
        {
            Vector3 dirToLookTarget = (lookAtTarget - transform.position).normalized;
            float targetAngle = 90-Mathf.Atan2(dirToLookTarget.z, dirToLookTarget.x) * Mathf.Rad2Deg;

            while (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.y, targetAngle)) > 0.05f) 
            {
                float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetAngle, turnSpeed * Time.deltaTime);
                transform.eulerAngles = Vector3.up * angle;
                yield return null;
            }
        }

        private void OnDrawGizmos()
        {
            Vector3 startPosition = pathHolder.GetChild(0).position;
            Vector3 previousPosition = startPosition;
            foreach (Transform wayPoint in pathHolder)
            {
                Gizmos.DrawSphere(wayPoint.position, 0.3f);
                Gizmos.DrawLine(previousPosition, wayPoint.position);
                previousPosition = wayPoint.position;
            }
            Gizmos.DrawLine(previousPosition, startPosition);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.forward * viewDistance);
        }
    }
}
