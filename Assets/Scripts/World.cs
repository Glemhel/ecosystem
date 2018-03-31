using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    [SerializeField]
    Material skybox_clear, skybox_rainy; //materials for different skybox weathers

    [SerializeField]
    GameObject rainmaker; //prefab from unity assets that allow to make realistic rain

    [SerializeField]
    GameObject soil, stone; //prefabs for blocks out of which the world consists

    GameObject[,,] world = new GameObject[1000,100,1000]; //3-dimensional array of blocks that make up map

    [SerializeField]
    GameObject deer; // prefab for deer

    GameObject[] animals = new GameObject[100]; // array of all animals that exist

    int animalcount; // number of currently existing animals

    float seed; //seed is a thing used to generate world, it is generated once and forever
    // the lower the value of seed is, the calmer generated landcape will be

    float raindelay=10F;//delay wich determine when the rain will come again


    void Start () {
        StartCoroutine(ChangeWeather()); //start weather cycle
        seed = Random.Range(0.01F, 0.1F); // generate a seed for map generation
        GenerateChunk(0, 0, 0, 100, 100); //generate the map itself
        GenerateDeer(10); //generate animals
    }
	
	
	void FixedUpdate () {
        
        Animal_moves();
    }

    void GenerateChunk(int startx, int startz, int starty, int wz, int wx)
    //a procedure for generating a chunk of blocks starting from block startz, startx, starty
    //z -- front + back, x -- right + left, y -- up + down 
    //wz and wx define size of a chunk starting from block with coords startz, startx, starty
    {
        for (int i=0;i<=wz; i++)
            for (int j = 0; j <= wx; j++)
            {
                GameObject newblock=soil;

                int x=startx, y=starty, z=startz;

                //a general formula to calculate height
                y = Mathf.RoundToInt(Mathf.PerlinNoise(startz + i*seed, startx + j * seed) *15);
               
                newblock.transform.position = new Vector3(startz + i, y, startx + j);
                
                world[startz + i, y, startx + j] = newblock;
                Instantiate(newblock);
            }
    }

    //simply spawn given num of Deer
    void GenerateDeer(int num)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject newdeer = deer;
            // newdeer=newdeer.Reproduction(deer,deer);
            newdeer.transform.position = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            animals[animalcount++] = newdeer;
            Instantiate(newdeer);
        }
    }

    IEnumerator ChangeWeather() //If it is rainy changes to clear, if clear changes to rainy
    {
        while (true)
        {
            //ToDo make it better with making rain go in and out smoother
            if (!rainmaker.activeSelf)
            {
                RenderSettings.skybox = skybox_rainy;
                rainmaker.SetActive(true);
            }
            else
            {
                RenderSettings.skybox = skybox_clear;
                rainmaker.SetActive(false);
            }
            yield return new WaitForSeconds(raindelay);
        }
    }

    void Animal_moves()
    {
        for (int i = 0; i < animalcount; i++)
        {

        }
    }
}
