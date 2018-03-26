using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockS : MonoBehaviour {
    [SerializeField]
    int durability;//прочность
    string type;//тип
    Vector3 coordinates;//координаты
    // Use this for initialization
    //Проверка, нужно ли уничтожать блок
    bool Ifdestroy()
    {
        return (durability <= 0);
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
