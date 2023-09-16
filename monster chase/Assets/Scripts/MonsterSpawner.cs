using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterReference;  //we are going to create copies from game objects (enemy)
    public Transform leftPos, rightPos;

    private GameObject spawnedMonster; //refence to do spawned game objects (enemy)

    private int randomIndex;//index of the spawned monster
    private int randomSide; //which side we are going to spawn oue enemies
    
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

   IEnumerator SpawnMonsters()  //we can call it over and over again every 5-10 sec
    {
        while (true)  //normally while loop runs very quicly but we are in the Coroutine
        {
            yield return new WaitForSeconds(Random.Range(1, 5)); // bc of this the loop will wait 1-5 sec

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);

            spawnedMonster = Instantiate(monsterReference[randomIndex]); //it is going to create a copy of a game object from the monsterReference aray

            if (randomSide == 0)
            {
                //left side
                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);//we call speed value form the Monster script 
            }
            else
            {
                //right side
                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);//we put minus(-) bc it needs to come from the right to left
                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);//enemy needs to look to the left
            }
        }
    } 
   
}
