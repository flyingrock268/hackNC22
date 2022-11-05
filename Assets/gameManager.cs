using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{

    public float money = 10;

    public int waterAmt;
    public int waterAmtClick;

    public int sugarAmt;
    public int sugarAmtClick;

    public int lemonaidAmt;

    public int upgradeWaterClickCost = 5;
    public int upgradeSugarClickCost = 5;
    public int increasePriceCost = 5;

    public float sellAmt;
    public float waitTime = 1;

    public int autoWater = 0;
    public int autoSugar = 0;

    public TextMeshProUGUI moneytxt;
    public TextMeshProUGUI watertxt;
    public TextMeshProUGUI sugartxt;
    public TextMeshProUGUI lemonaidtxt;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(sellLemonaidLoop());
        StartCoroutine(genResources());

    }

    // Update is called once per frame
    void Update()
    {
        
        moneytxt.text = "$ "+ money;
        //watertxt.text = waterAmt.ToString();
        //sugartxt.text = sugarAmt.ToString();
        //lemonaidtxt.text = lemonaidAmt.ToString();

        if (waterAmt > 0 && sugarAmt > 0) {

            waterAmt--;
            sugarAmt--;
            lemonaidAmt++;
        
        }

    }

    public void addWater() { 
    
        waterAmt += waterAmtClick;
    
    }

    public void addSugar() {

        sugarAmt += sugarAmtClick;
    
    }

    public void upgradeWaterClick() {

        if (money >= upgradeWaterClickCost) {

            waterAmtClick++;
            money -= upgradeWaterClickCost;
            upgradeWaterClickCost *= 2;
        
        }
    
    }

    public void upgradeSugarClick()
    {

        if (money >= upgradeSugarClickCost)
        {

            sugarAmtClick++;
            money -= upgradeSugarClickCost;
            upgradeSugarClickCost *= 2;

        }

    }

    public void increasePrice() {

        if (money >= increasePriceCost) {

            sellAmt += .5f;
            money -= increasePriceCost;
            increasePriceCost *= 2;
        
        }
    
    }

    public IEnumerator sellLemonaidLoop()
    {

        while (true)
        {

            if (lemonaidAmt > 0)
            {

                money += sellAmt;
                lemonaidAmt--;

            }

            yield return new WaitForSeconds(waitTime + Random.Range(-waitTime/10,waitTime/10));

        }

    }

    public IEnumerator genResources() {

        while (true) {

            waterAmt += autoWater;
            sugarAmt += autoSugar;

            yield return new WaitForSeconds(2.5f);

        }
    
    }
}
