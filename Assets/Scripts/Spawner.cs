﻿
using System.Collections;
using UnityEngine;

namespace Tools
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] private GameObject toSpawnObject;

        [Header("Limit Options")]
        [SerializeField] private int spawnLimit;
        [SerializeField] private bool limitSpawns;

        private GameObject p_spawnedObj;
        [SerializeField] private bool infiniteSpawn;
        [SerializeField] private int spawnWaitTime;

        private int p_totalObjectsSpawned;

        private void Awake() => CreateSpawnedObjectParent();

        private void CreateSpawnedObjectParent()
        {
            if (p_spawnedObj != null) Destroy(p_spawnedObj);
            p_spawnedObj = new GameObject();
            p_spawnedObj.transform.name = "Objects Spawned";
        }


        public void SpawnObject()
        {
          
            if (limitSpawns && p_totalObjectsSpawned >= spawnLimit) return;
            Instantiate(toSpawnObject, transform.position, Quaternion.identity, p_spawnedObj.transform);
            p_totalObjectsSpawned++;
        }


        public void SpawnObjectAt() { }
        private void Update()
        {
            if (infiniteSpawn) StartCoroutine(SpawnObjectEveryXtime());
        }

        private IEnumerator SpawnObjectEveryXtime()
        {
            infiniteSpawn = false;
            yield return new WaitForSeconds(spawnWaitTime);
            SpawnObject();
            infiniteSpawn = true;
        }

        public void OnEnable()
        {
            if (infiniteSpawn) SpawnObject();
        }
    }
}
