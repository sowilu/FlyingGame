using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public List<GameObject> meteors;
    public float diameter = 100;
    public int count = 50;

    void Start()
    {
        for (int i = 0; i < count; i++)
        {
            var pos = Random.insideUnitSphere * diameter;
            var rot = Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            var index = Random.Range(0, meteors.Count);

            var meteor = Instantiate(meteors[index], pos, rot);
        }
    }

    
}
