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

    GameObject[,,] world = new GameObject[1000, 100, 1000]; //3-dimensional array of blocks that make up map

    [SerializeField]
    GameObject deer; // prefab for deer

    GameObject[] animals = new GameObject[100]; // array of all animals that exist

    int animalcount; // number of currently existing animals

    [SerializeField]
    float seed; //seed is a thing used to generate world, it is generated once and forever
                // the lower the value of seed is, the calmer generated landcape will be

    [SerializeField]
    float raindelay = 120F;//delay wich determine when the rain will come again

    [SerializeField]
    bool can_weather_change=true; //determines whether weather cycle is active or not

    [SerializeField]
    GameObject charact; // character himself

    void Start () {
        if (can_weather_change) StartCoroutine(ChangeWeather()); //start weather cycle if allowed
        seed = Random.Range(0.01F, 0.04F); // generate a seed for map generation
        GenerateChunk(0, 0, 100, 100); //generate the map itself
        charact.transform.position = new Vector3(0, HeightFormula(0,0)+4, 0);
        GenerateDeer(10); //generate animals
    }
	
	
	void FixedUpdate () {
        
        Animal_moves();
    }


    int HeightFormula(float z, float x)
    {
        //a general formula to calculate height
        return Mathf.RoundToInt(Mathf.PerlinNoise(z, x) * 45);
    }

    void GenerateChunk(int startx, int startz, int wz, int wx)
    //a procedure for generating a chunk of blocks starting from block startz, startx
    //supposedly starting block doesnt exist
    //z -- front + back, x -- right + left, y -- up + down 
    //wz and wx define size of a chunk starting from block with coords startz, startx, starty
    {
        int x = startx, y = HeightFormula(startz, startx), z = startz;
        //coords of the fisrt block in chunk

        for (int i = 0; i <= wz; i++)
            for (int j = 0; j <= wx; j++)
            {
                GameObject newblock = soil;

                int block_x = x + j, block_z = z + i, block_y = HeightFormula(z + i * seed, x + j * seed);

                newblock.transform.position = new Vector3(block_z, block_y, block_x);
                Instantiate(newblock);

                world[block_z, block_y, block_x] = newblock;
                
            }
        //This was a part that generated ~90% of blocks in the world
        //Now we need to fix every hole that there is in generation

        for (int i = 1; i < wz; i++)
            for (int j = 1; j < wx; j++)
            {
                int block_x = x + j, block_z = z + i, block_y = HeightFormula(z + i * seed, x + j * seed);


                if (world[block_z - 1, block_y + 1, block_x] == null ||
                    world[block_z - 1, block_y, block_x] == null ||
                    world[block_z - 1, block_y - 1, block_x] == null)
                {
                    
                    if (world[block_z - 1, block_y + 2, block_x] != null)
                    {
                        GameObject newblock = soil;

                        newblock.transform.position = new Vector3(block_z - 1, block_y + 1, block_x);
                        Instantiate(newblock);

                        world[block_z - 1, block_y + 1, block_x] = newblock;
                        
                    }
                    else
                    {
                        if (world[block_z - 1, block_y - 2, block_x] != null)
                        {
                            GameObject newblock = soil;

                            newblock.transform.position = new Vector3(block_z - 1, block_y - 1, block_x);
                            Instantiate(newblock);

                            world[block_z - 1, block_y - 1, block_x] = newblock;
                            
                        }
                    }
                }

                if (world[block_z + 1, block_y + 1, block_x] == null ||
                    world[block_z + 1, block_y, block_x] == null ||
                    world[block_z + 1, block_y - 1, block_x] == null)
                {
                    if (world[block_z + 1, block_y + 2, block_x] != null)
                    {
                        GameObject newblock = soil;

                        newblock.transform.position = new Vector3(block_z + 1, block_y + 1, block_x);
                        Instantiate(newblock);

                        world[block_z + 1, block_y + 1, block_x] = newblock;
                        
                    }
                    else
                        if (world[block_z + 1, block_y - 2, block_x] != null)
                        {
                            GameObject newblock = soil;

                            newblock.transform.position = new Vector3(block_z + 1, block_y - 1, block_x);
                            Instantiate(newblock);

                            world[block_z + 1, block_y - 1, block_x] = newblock;
                            
                        }
                }

                if (world[block_z, block_y + 1, block_x + 1] == null ||
                   world[block_z, block_y, block_x + 1] == null ||
                   world[block_z, block_y - 1, block_x + 1] == null)
                {
                    if (world[block_z, block_y + 2, block_x + 1] != null)
                    {
                        GameObject newblock = soil;

                        newblock.transform.position = new Vector3(block_z + 1, block_y + 1, block_x + 1);
                        Instantiate(newblock);

                        world[block_z, block_y + 1, block_x + 1] = newblock;
                        
                    }
                    else
                        if (world[block_z, block_y - 2, block_x + 1] != null)
                        {
                            GameObject newblock = soil;

                            newblock.transform.position = new Vector3(block_z, block_y - 1, block_x + 1);
                            Instantiate(newblock);

                            world[block_z, block_y - 1, block_x + 1] = newblock;
                           
                        }
                }

                if (world[block_z, block_y + 1, block_x - 1] == null ||
                   world[block_z, block_y, block_x - 1] == null ||
                   world[block_z, block_y - 1, block_x - 1] == null)
                {
                    if (world[block_z, block_y + 2, block_x - 1] != null)
                    {
                        GameObject newblock = soil;

                        newblock.transform.position = new Vector3(block_z + 1, block_y + 1, block_x - 1);
                        Instantiate(newblock);

                        world[block_z, block_y + 1, block_x - 1] = newblock;
                        
                    }
                    else
                        if (world[block_z, block_y - 2, block_x - 1] != null)
                        {
                            GameObject newblock = soil;

                            newblock.transform.position = new Vector3(block_z, block_y - 1, block_x - 1);
                            Instantiate(newblock);

                            world[block_z, block_y - 1, block_x - 1] = newblock;
                            
                        }
                }
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
