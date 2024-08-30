using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class HouseLegsTempController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI legsTempText;
    [SerializeField] float legsCurrentTemp;
    [SerializeField] TextMeshProUGUI fuelAmountForLegsText;
    [SerializeField] float fuelAmountForLegs;


    TemperatureManager airTempManager;

    float legsMaxTemp, legsMinTemp;

    

    void Start()
    {
        airTempManager=FindAnyObjectByType<TemperatureManager>();

        InvokeRepeating("CompareTempBtwnLegsAndAir", 1, 2);

        StartCoroutine(UsingFuelForHouseLegs());
    }


    IEnumerator UsingFuelForHouseLegs()
    {
        while (true)
        {
            if (fuelAmountForLegs > 0)
            {
                fuelAmountForLegs--;
                UpdateFuelAmountForLegs();

                legsCurrentTemp +=2;
                UpdateTempOfLegs();
            }

            yield return new WaitForSeconds(2);
        }
    }

    void CompareTempBtwnLegsAndAir()
    {
        float tempDiff=airTempManager.airTemprerature-legsCurrentTemp;
        legsCurrentTemp += Convert.ToInt32((tempDiff * 3) / 100);
        UpdateTempOfLegs();

        if (legsCurrentTemp < -10) 
        {   // soðuktan dolayý bacaklar donar ve ev hareket etmez
            gameObject.GetComponent<HouseMovement>().houseSpeedMul = 0;
        }
        else
        { 
            gameObject.GetComponent<HouseMovement>().houseSpeedMul = 100;
        }
    }


    void UpdateFuelAmountForLegs()
    {
        fuelAmountForLegsText.text=fuelAmountForLegs.ToString();
    }

    void UpdateTempOfLegs()
    {
        legsTempText.text = legsCurrentTemp.ToString();
    }
}
