using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSnowballRain : MonoBehaviour
{
    [SerializeField] GameObject snowballPrefab;
    float rangeX,rangeY,rangeZ;
    
    void Start()
    {
        rangeX = gameObject.transform.localScale.x/2;
        rangeY= gameObject.transform.localScale.y/2;
        rangeZ= gameObject.transform.localScale.z / 2;

        InvokeRepeating("SnowballSpawner", 1, 7);
    }


    void SnowballSpawner()
    {
        int randSnowballCount = Random.Range(10, 15);
        for (int i = 0; i < randSnowballCount; i++)
        {
            Vector3 spawnPos = RandomSnowpallSpawnPoint();
            Instantiate(snowballPrefab, spawnPos, Quaternion.identity);
        }
    }


    Vector3 RandomSnowpallSpawnPoint()
    {
        float posX = Random.Range(-rangeX, rangeX);
        float posY = Random.Range(-rangeY, rangeY);
        float posZ = Random.Range(-rangeZ, rangeZ);

        Vector3 spawnPos= new Vector3(posX, transform.position.y+posY, posZ);
        return spawnPos;
    }
}
