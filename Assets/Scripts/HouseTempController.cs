using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HouseTempController : MonoBehaviour
{
    [SerializeField] MainCanvasManager mainCanvasManager;

    TemperatureManager airTempManager;
    HouseFuelStackManager houseFuelStack;

    [SerializeField] TextMeshProUGUI houseTempText;
    [SerializeField] float houseCurrentTemp;

    [SerializeField] GameObject houseGameOverPanel;




    // Start is called before the first frame update
    void Start()
    {
        airTempManager = FindAnyObjectByType<TemperatureManager>();
        houseFuelStack=gameObject.GetComponent<HouseFuelStackManager>();

        UpdateTempOfHouse();

        InvokeRepeating("CompareTempBtwnHouseAndAir", 1, 2);

        StartCoroutine(UsingFuelForHouse());
    }

   

    IEnumerator UsingFuelForHouse()
    {
        while (true)
        {
            if ( houseFuelStack.houseFuelCount> 0 && houseCurrentTemp<30)
            {
                houseFuelStack.houseFuelCount--;
                houseFuelStack.UpdateFuelCount();

                houseCurrentTemp += 2;
                UpdateTempOfHouse();
            }

            yield return new WaitForSeconds(2);
        }
    }

    void CompareTempBtwnHouseAndAir()
    {
        float tempDiff = airTempManager.airTemprerature - houseCurrentTemp;
        houseCurrentTemp += Convert.ToInt32((tempDiff * 3) / 100);
        UpdateTempOfHouse();

        if (houseCurrentTemp < -15)
        {
            mainCanvasManager.isGameEnded = true;
            Time.timeScale = 0;
            houseGameOverPanel.SetActive(true);
        }
        
    }

    void UpdateTempOfHouse()
    {
        houseTempText.text=houseCurrentTemp.ToString()+" C";
    }
}
