using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class gameManager : MonoBehaviour
{

    public float money = 10;
    public float mult = 1.0f;

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
    public int fruitMultiplerCost = 100;

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
    public TextMeshProUGUI fruitMultiplierCosttxt;
    public TextMeshProUGUI sugartxt;
    public TextMeshProUGUI lemonaidtxt;

    public GameObject pauseMenu;

    public AudioClip success;
    public AudioClip failure;

    AudioSource Aud;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(sellLemonaidLoop());
        StartCoroutine(genResources());
        Aud = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
        moneytxt.text = "$ "+ money.ToString("0.00");
        watertxt.text = waterAmt.ToString();
        sugartxt.text = sugarAmt.ToString();
        lemonaidtxt.text = lemonaidAmt.ToString();
        upPriceCost.text = "$ " + increasePriceCost;
        upSalesCost.text = "$ " + increaseSalesCost;
        waterClickCosttxt.text = "$ " + upgradeWaterClickCost;
        sugarClickCosttxt.text = "$ " + upgradeSugarClickCost;
        waterAutoCosttxt.text = "$ " + upgradeAutoWaterCost;
        sugarAutoCosttxt.text = "$ " + upgradeAutoSugarCost;
        fruitMultiplierCosttxt.text = "$ " + fruitMultiplerCost;

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

        if (money >= upgradeWaterClickCost)
        {

            waterAmtClick++;
            money -= upgradeWaterClickCost;
            upgradeWaterClickCost *= 2;

            Aud.PlayOneShot(success);

        }

        else {

            Aud.PlayOneShot(failure);
        
        }
    
    }

    public void upgradeWaterAuto() {

        if (money >= upgradeAutoWaterCost) {

            autoWater++;
            money -= upgradeAutoWaterCost;
            upgradeAutoWaterCost *= 2;
            Aud.PlayOneShot(success);

        }

        else
        {

            Aud.PlayOneShot(failure);

        }

    }

    public void upgradeSugarClick()
    {

        if (money >= upgradeSugarClickCost)
        {

            sugarAmtClick++;
            money -= upgradeSugarClickCost;
            upgradeSugarClickCost *= 2;

            Aud.PlayOneShot(success);

        }

        else
        {

            Aud.PlayOneShot(failure);

        }

    }

    public void upgradeSugarAuto() {

        if (money >= upgradeAutoSugarCost)
        {

            autoSugar++;
            money -= upgradeAutoSugarCost;
            upgradeAutoSugarCost *= 2;

            Aud.PlayOneShot(success);

        }

        else
        {

            Aud.PlayOneShot(failure);

        }

    }

    public void increasePrice() {

        if (money >= increasePriceCost) {

            sellAmt += .5f;
            money -= increasePriceCost;
            increasePriceCost *= 2;

            Aud.PlayOneShot(success);

        }

        else
        {

            Aud.PlayOneShot(failure);

        }

    }

    public void inscreaseSales() {

        if (money >= increaseSalesCost) {

            sellNum++;
            money -= increaseSalesCost;
            increaseSalesCost *= 2;

            Aud.PlayOneShot(success);

        }

        else
        {

            Aud.PlayOneShot(failure);

        }

    }

    public void increaseMultiplier() {

        if (money >= fruitMultiplerCost) {

            mult += .25f;
            money -= fruitMultiplerCost;
            fruitMultiplerCost *= 2;

            Aud.PlayOneShot(success);

        }

        else
        {

            Aud.PlayOneShot(failure);

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
                        money += sellAmt * mult;

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
