using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> spawningObjects;     //List of enemies for wave.


    [SerializeField] float minSpawnTime = 2f;
    [SerializeField] float maxSpawnTime = 4f;

    [SerializeField] int howManyToSpawn = 10;
    [SerializeField] int howManyVariance = 0;

    void Awake()
    {
        howManyVariance = Random.Range(-howManyVariance, howManyVariance);
        howManyToSpawn += howManyVariance;
    }

    public int GetSpawnableObjectCount() => spawningObjects.Count;          //Gets the number of enemies or an enemy at index.
    public GameObject GetSpawnableObject(int index) => spawningObjects[index];

    

    public int GetHowManyToSpawn() => howManyToSpawn;   //gets max to spawn each wave.



    public float GetRandomSpawnTime()
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        return Mathf.Clamp(spawnTime, minSpawnTime, float.MaxValue);        //Between these two boundaries, float.maxval is highest a float can hold. So basically no restriction on max, only min.
    }

}
