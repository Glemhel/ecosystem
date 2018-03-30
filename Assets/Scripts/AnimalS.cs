using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[SerializeField]
//ToDo model;
//MAIN QUESTION
//scripts are named as classes. Is it OK that it is "Animals" class?(same for all others)
public class AnimalS : MonoBehaviour
{
    [SerializeField]
    GameObject deer;
    GameObject model;
    [SerializeField]
    int health_max;
    int health;
    [SerializeField]
    int size; //ToDo Add to list
    [SerializeField]
    int agression;
    int age;
    [SerializeField]
    int age_max;
    [SerializeField]
    bool sex;
    int temperature;
    [SerializeField]
    bool herbivore;
    [SerializeField]
    bool flesh_eating;
    [SerializeField]
    string specimen;
    Vector3 destination;
    Vector3 coordinates;
    [SerializeField]
    bool alive;
    int time_not_alive;
    [SerializeField]
    int satiety;
    public static AnimalS CreateNew()
    {
        AnimalS animal = new AnimalS
        {
            health_max = 100,
            satiety = 20,
            sex = Random.Range(0, 1) == 0,
            temperature = 42,
            herbivore = true,
            flesh_eating = true,
            alive = true,
            age = 5,
            age_max = 15,
            size = 1,
           // model = deer,//нужно перенести модельку отдельно в оленя, её брать из её Ser field, а тут не маяться гейством
        };
        return animal;
    }
    public AnimalS Reproduction(AnimalS a1, AnimalS a2)
    {
        if (a1.specimen == a2.specimen && a1.sex != a2.sex)
        {
            AnimalS a3 = new AnimalS
            {
                 //fix model--add to SerField and comment
                health_max = (a2.health_max + a1.health_max) / 4,
                satiety = (a2.satiety + a1.satiety) / 2,
                sex=Random.Range(0,1)==0,
                temperature = (a2.temperature + a1.temperature) / 2,
                herbivore = a1.herbivore,
                flesh_eating = a1.flesh_eating,
                alive = true,
                age = 0,
                age_max = a1.age_max,
                size = 1
            };
            a3.health = a3.health_max - a3.health_max / 4;
            return a3;
        }
        return null;
    }
    public void Feed(int n)
    {
        this.satiety += n;
        //ToDo Animations
    }

    //ToDo Add all funсtions connected to Animals 
}