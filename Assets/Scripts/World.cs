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

    [SerializeField]
    GameObject deer;

 //   GameObject[,,] world = new GameObject[100,100,100]; //3-dimensional array of blocks that make up map

    GameObject[] animals = new GameObject[100];
    int animalcount;
	void Start () {
        GenerateChunk(0, 0, 0, 20, 20);
        GenerateDeer(10);
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
                y = Mathf.RoundToInt(Mathf.PerlinNoise(startz + i, startx + j)*150);
                //multipling was implemented because PerlinNoise returns a number somewhere inbetween 0 and 1
                //which after rounding go either to 0 or to 1 and therefore completely negate the purpose of PerlinNoise
                newblock.transform.position = new Vector3(startz + i, startx + j, y);
                //world[startz + i, startx + j, y] = newblock;
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
            newdeer.transform.position = new Vector3(Random.Range(-50,50),0, Random.Range(-50, 50));
            animals[animalcount++] = newdeer;
            Instantiate(newdeer);
        }
    }
    void ChangeWeather() //If it is rainy changes to clear, if clear changes to rainy
    {
        //ToDo make it better with making rain go in and out smoother
        if (RenderSettings.skybox == skybox_clear)
        {
            RenderSettings.skybox = skybox_rainy;
            rainmaker.SetActive(true);
        }
        else
        {
            RenderSettings.skybox = skybox_clear;
            rainmaker.SetActive(false);
        }
    }
    void Animal_moves()
    {
        for (int i=0;i<animalcount;i++)
        {

        }
    }
}
