using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{

    public int money = 10;
    public int waterAmt;
    public int waterAmtClick;
    public int sugarAmt;
    public int sugarAmtClick;
    public TextMeshProUGUI moneytxt;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        moneytxt.text = "$ "+ money;

    }

    public void addWater() { 
    
        waterAmt += waterAmtClick;
    
    }

    public void addSugar() {

        sugarAmt += sugarAmtClick;
    
    }
}
