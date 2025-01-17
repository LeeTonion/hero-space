using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGameObject : MonoBehaviour
{
    [SerializeField] private SpawnSO[] GameObjects;
    private void Start()
    {
        foreach( SpawnSO spawnSO in GameObjects )
        {
            StartCoroutine(SpawnEnergy(spawnSO));
        }
       

    }

    IEnumerator SpawnEnergy( SpawnSO spawm)
    {
        while (true)
        {
            Vector2 vector2 = new(Random.Range(-6, 27), Random.Range(-17, 14));
            GameObject gameobjectspawn= Instantiate(spawm.gameObject, vector2, Quaternion.identity);
            if ( spawm.TimeDestroy != 0)
            {
                Destroy(gameobjectspawn, spawm.TimeDestroy);
            }
            
            yield return new WaitForSeconds(spawm.TimeSpawn);
        }
        
    }
}
