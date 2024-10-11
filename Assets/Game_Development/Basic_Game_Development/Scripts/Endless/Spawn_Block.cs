using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game_Development.Basic_Game_Development.Scripts.Endless
{
    public class Spawn_Block : MonoBehaviour
    {
        [Header("Prefab")]
        [SerializeField]
        private GameObject obstaclePrefeb;
        [Header("Time")]
        [SerializeField]
        private float nextSpawnTime;
        [SerializeField]
        private Vector2 secondBtwSpawnMinMax;
        [Header("ScreenSize")]
        [SerializeField]
        private Vector2 screenHalfSizeWorldUnit;
        [Header("SpawnSize")]
        [SerializeField]
        private Vector2 spawnSizeMinMax;
        [SerializeField]
        private float spawnSize;
        [SerializeField]
        private float spawnAngleMinMax;
        [SerializeField]
        private float spawnAngle;
      

        void Start()
        {
            screenHalfSizeWorldUnit = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
        }

        void Update()
        {
            if (Time.time > nextSpawnTime) 
            {
                float secondBtwSpawn = Mathf.Lerp(secondBtwSpawnMinMax.y, secondBtwSpawnMinMax.x, Difficulty_Level.GetDifficultPercent());
                nextSpawnTime = Time.time + secondBtwSpawn;
                spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
                spawnAngle = Random.Range(-spawnAngleMinMax, spawnAngleMinMax);
                RandomSpawnPrefab();
            }
        }

        void RandomSpawnPrefab()
        {
            //Vector2 randomPosition = new Vector2(Random.Range(-3.1f, 3.1f), (Random.Range(0f, 5f)) * 0.5f);
            Vector2 randomPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnit.x, screenHalfSizeWorldUnit.x), screenHalfSizeWorldUnit.y + spawnSize);

            GameObject newRandomBlock = Instantiate(obstaclePrefeb, randomPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
            newRandomBlock.transform.localScale = Vector3.one * spawnSize;
            newRandomBlock.transform.parent = transform;
        }
    }
}
