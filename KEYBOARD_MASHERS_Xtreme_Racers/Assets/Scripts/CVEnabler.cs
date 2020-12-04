using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVEnabler : MonoBehaviour
{
    GameObject childObj;

    // Start is called before the first frame update
    void Start()
    {
        childObj = GameObject.Find("Script");
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalManager.openCV){
            childObj.SetActive(true);
        }else{
            childObj.SetActive(false);
        }
    }

}
