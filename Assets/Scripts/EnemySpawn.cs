using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public List<Transform> spawnPoints;
    public List<Enemy> enemyPrefabs;

    private void Awake()
    {
        Spawn();
    }

    private void Spawn()
    {
        int enemiesToSpawm = Random.Range(1, spawnPoints.Count + 1);

        Room room = GetComponentInParent<Room>();

        while (enemiesToSpawm > 0)
        {
            int index = Random.Range(0, spawnPoints.Count);
            var spawnPoint = spawnPoints[index];
            spawnPoints.RemoveAt(index);

            var enemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], spawnPoint);
            enemy.room = room;
            enemy._colorChange.isPink = Random.Range(0, 2) == 1;
            enemy._colorChange.SetLayerWeight();

            enemiesToSpawm--;
        }
    }
}
