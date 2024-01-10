using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> monsterPrefabs; // Le prefab du monstre que vous voulez faire appara�tre.
    public List<Terrain> terrains; // La r�f�rence au composant Terrain dans votre sc�ne.

    public int numberOfMonstersToSpawn = 10; // Le nombre de monstres � g�n�rer.

    void Start()
    {
        Terrain terrain = terrains[Random.Range(0, terrains.Count)];
        TerrainCollider terrainCollider = terrain.GetComponent<TerrainCollider>();
        Bounds terrainBounds = terrainCollider.bounds;

        for (int i = 0; i < numberOfMonstersToSpawn; i++)
        {
            float randomX = Random.Range(terrainBounds.min.x, terrainBounds.max.x);
            float randomZ = Random.Range(terrainBounds.min.z, terrainBounds.max.z);
            float randomY = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));

            Vector3 randomSpawnPoint = new Vector3(randomX, randomY, randomZ);

            GameObject monsterPrefab = monsterPrefabs[Random.Range(0, monsterPrefabs.Count)];
            Instantiate(monsterPrefab, randomSpawnPoint, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //faire spawn des entit�es al�atoirement
    
}
