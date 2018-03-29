using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeS : MonoBehaviour {
    #region parametrs
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
    GameObject[] spawns;
    #endregion
  

    public void Grow()
    {
        if (CanGrow()) { } //ToDo Make our way to tree guidelines for Unity
}
    
    bool CanGrow()//Checks if the tree is or is not dead due to water and nutrients + checks if the tree can grow
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
            Death("nutrients");
            return false;
        }
        Death("humidity");
        return false;
    }
    bool HumidityCheck(bool flag) //flag defines wether we check it for growing or for the living amount
    {
        if (flag) return (humidity > desired_humidity);
        return (humidity > desired_humidity_tg);
    }
    bool NutrientsCheck(bool flag) //flag defines wether we check it for growing or for the living amount
    {
        if (flag) return (nutrients > desired_nutrients);
        return (nutrients > desired_nutrients_tg);
    }
    void Death(string reason)
    {
        //ToDo put a reson of death to use
        //matter what reason?
        Destroy(this.transform.gameObject); //Ideally start a couroutine, changing colour
                                            // and visuals of the tree
    }

}
