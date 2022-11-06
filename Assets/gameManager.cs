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
    public int upgradeAutoWaterCost = 5;
    public int upgradeAutoSugarCost = 5;
    public int increaseSalesCost = 5;

    public float sellAmt;
    public float waitTime = 1;

    public int autoWater = 0;
    public int autoSugar = 0;
    public int sellNum = 1;

    public TextMeshProUGUI moneytxt;
    public TextMeshProUGUI watertxt;
    public TextMeshProUGUI waterClickCosttxt;
    public TextMeshProUGUI waterAutoCosttxt;
    public TextMeshProUGUI sugarClickCosttxt;
    public TextMeshProUGUI sugarAutoCosttxt;
    public TextMeshProUGUI upPriceCost;
    public TextMeshProUGUI upSalesCost;
    public TextMeshProUGUI sugartxt;
    public TextMeshProUGUI lemonaidtxt;

    public GameObject pauseMenu;

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
        watertxt.text = waterAmt.ToString();
        sugartxt.text = sugarAmt.ToString();
        lemonaidtxt.text = lemonaidAmt.ToString();
        upPriceCost.text = "$ " + increasePriceCost;
        upSalesCost.text = "$ " + increaseSalesCost;
        waterClickCosttxt.text = "$ " + upgradeWaterClickCost;
        sugarClickCosttxt.text = "$ " + upgradeSugarClickCost;
        waterAutoCosttxt.text = "$ " + upgradeAutoWaterCost;
        sugarAutoCosttxt.text = "$ " + upgradeAutoSugarCost;

        if (waterAmt > 0 && sugarAmt > 0) {

            waterAmt--;
            sugarAmt--;
            lemonaidAmt++;
        
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {

            togglePause();
        
        }

    }

    public void togglePause() {

        if (Time.timeScale == 1)
        {

            Time.timeScale = 0;
            pauseMenu.SetActive(true);

        }

        else
        {

            Time.timeScale = 1;
            pauseMenu.SetActive(false);

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

    public void upgradeWaterAuto() {

        if (money >= upgradeAutoWaterCost) {

            autoWater++;
            money -= upgradeAutoWaterCost;
            upgradeAutoWaterCost *= 2;
        
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

    public void upgradeSugarAuto() {

        if (money >= upgradeAutoSugarCost)
        {

            autoSugar++;
            money -= upgradeAutoSugarCost;
            upgradeAutoSugarCost *= 2;

        }

    }

    public void increasePrice() {

        if (money >= increasePriceCost) {

            sellAmt += .5f;
            money -= increasePriceCost;
            increasePriceCost *= 2;
        
        }
    
    }

    public void inscreaseSales() {

        if (money >= increaseSalesCost) {

            sellNum++;
            money -= increaseSalesCost;
            increaseSalesCost *= 2;
        
        }
    
    }

    public IEnumerator sellLemonaidLoop()
    {

        while (true)
        {

            if (lemonaidAmt > 0)
            {

                for (int i = 0; i < sellNum; i++) {

                    if (lemonaidAmt > 0)
                    {

                        lemonaidAmt--;
                        money += sellAmt;

                    }

                    else {

                        break;

                    }
                
                }

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
