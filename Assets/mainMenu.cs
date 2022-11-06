using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{

    public List<GameObject> toToggle;

    public void pushStart() {

        SceneManager.LoadScene("gameScene");
    
    }

    public void pushQuit() {

        Application.Quit();
    
    }

    public void pushInfo() {

        foreach (GameObject obj in toToggle) {

            obj.SetActive(!obj.activeSelf);
        
        }
    
    }

}
