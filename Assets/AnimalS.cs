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
    public AnimalS Reproduction(AnimalS a1, AnimalS a2)
    {
        if (a1.specimen == a2.specimen && a1.sex != a2.sex)
        {
            AnimalS a3;
            a3.model = a1.model;//fix model--add to SerField and comment
            a3.health_max = (a2.health_max + a1.health_max) / 4;
            a3.satiety = (a2.satiety + a1.satiety) / 2;
            a3.sex = random(1); //ToDo Fix Random
            a3.temperature = (a2.temperature + a1.temperature) / 2;
            a3.herbivore = a1.herbivore;
            a3.flesh_eating = a1.flesh_eating;
            a3.alive = true;
            a3.age = 0;
            a3.age_max = a1.age_max;
            a3.size = 1;
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