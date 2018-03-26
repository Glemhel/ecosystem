using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeS : MonoBehaviour {

    [SerializeField]
    int toughness;
    [SerializeField]
    int durability;
    int humidity;
    [SerializeField]
    int height;
    [SerializeField]
    int diameter;
    [SerializeField]
    int lifespan;
    [SerializeField]
    int weight;
    [SerializeField]
    int resourses;
    int nutrients;
    [SerializeField]
    int desired_nutrients;
    [SerializeField]
    int desired_humidity;
    [SerializeField]
    int desired_nutrients_tg;
    [SerializeField]
    int desired_humidity_tg;
    [SerializeField]
    bool dead;
    [SerializeField]
    Gameobject[] spawns; //ToDo Fix syntax
    
    //ToDo make a region out of all fields

    public void Grow()
    {
        if (CanGrow()) { } //ToDo Make our way to tree guidelines for Unity
}
    //fix returns and comment on logic of method
    bool CanGrow()
    {
        if (HumidityCheck(false))
    
    {
            if (NutrientsCheck(false))

        {
                if(HumidityCheck(true))

            {
                    if(NutrientsCheck(true))

                {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            Death(nutrients);
            //may be add "Death"? WTF is it?
        }
        Death(humidity);
    }
    bool HumidityCheck(bool flag)
    {
        if (flag) return (humidity > desired_humidity);
        return (humidity > desired_humidity_tg);
    }
    bool NutrientsCheck(bool flag)
    {
        if (flag) return (nutrients > desired_nutrients);
        return (nutrients > desired_nutrients_tg);
    }


}
