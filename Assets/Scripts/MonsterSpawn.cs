using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> monsterPrefabs; // Le prefab du monstre que vous voulez faire apparaître.
    public List<Terrain> terrains; // La référence au composant Terrain dans votre scène.

    public int numberOfMonstersToSpawn = 1; // Le nombre de monstres à générer.

    public bool isTimerFinish = false;
    public int difficulty = 0;

    private int secondesToWait = 3; // Le nombre de secondes à attendre avant de générer un nouveau monstre.
    void Start()
    {
        //Récupère la difficulté
        //int difficulty = PlayerPrefs.GetInt("Difficulty");
        //Difficulté
        switch (difficulty)
        {
            case 0:
                numberOfMonstersToSpawn = 2;
                secondesToWait = 10;
                break;
            case 1:
                numberOfMonstersToSpawn = 3;
                secondesToWait = 8;
                break;
            case 2:
                numberOfMonstersToSpawn = 4;
                secondesToWait = 6;
                break;
            default:
                numberOfMonstersToSpawn = 3;
                secondesToWait = 8;
                break;
        }

        //fait apparaitre des monstre toute les x secondes
        StartCoroutine(SpawnMonster());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnMonster()
    {
        yield return new WaitForSeconds(secondesToWait);
        //Faire apparaitre un monstre
        /*
        foreach (Terrain terrain in terrains)
        {
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
        */
        Terrain terrain = terrains[0];
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
        if (!isTimerFinish)
        {
            StartCoroutine(SpawnMonster());
        }

    }

}
