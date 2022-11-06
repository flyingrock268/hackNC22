using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableThing : MonoBehaviour
{

    public List<GameObject> things;

    public void doDisable() {

        foreach (GameObject obj in things) { 
        
            obj.SetActive(false);
        
        }
    
    }

}
