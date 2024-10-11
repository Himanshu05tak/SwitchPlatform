using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Basic4Beginner.Prefab_Instantiation
{
    public class Prefab_Instantiation : MonoBehaviour
    {
        [SerializeField]
        private GameObject chairPrefab;
       
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3 spawnRandomPosition = new Vector3(Random.Range(-10f, 10f), 0, (Random.Range(-10f, 10f)));
                Vector3 spawnRandomRotation = Vector3.up * Random.Range(0, 360);
                GameObject newChairPrefab = Instantiate(chairPrefab, spawnRandomPosition, Quaternion.Euler(spawnRandomRotation));
                newChairPrefab.transform.parent = transform;
            }
        }
    }
}
