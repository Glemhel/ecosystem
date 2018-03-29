using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilS : BlockS {
    [SerializeField]
    int clayness;//глинистость
    string state;//состояние почвы(тип)
    int nutriens;//удобрения
    byte herbaceousness;//травянистость
    int humidity;//увлажнённость
    void Change_type() {
        if (clayness >= 15 && nutriens >= 15 && humidity >= 50)
        {
            //глина
            this.state = "глина";
        }
        else
            if (clayness >= 10 && nutriens >= 10 && humidity >= 60)
        {
            //торф
            this.state = "торф";
        }
        else
            if (clayness >= 5 && nutriens >= 5 && humidity >= 30)
        {
            //илистые почвы
            this.state = "ил";
        }
        else
        {
            //песок
            this.state = "песок";
        }
        return;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
