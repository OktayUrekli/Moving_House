using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class PlayerTempController : MonoBehaviour
{
    [SerializeField] MainCanvasManager mainCanvasManager;
    
    
    TemperatureManager temperatureManager;
    FuelStackManager fuelStack;

    [SerializeField] GameObject playerGameOverPanel;

    [SerializeField] PostProcessVolume globalVolume;
    Vignette globalVolumeVignette;


    [Header("Ui elements")]
    [SerializeField] TextMeshProUGUI playerTempText;
    [SerializeField] Image playerTempImage;

    [Header("Player Temp veriables")]
    [SerializeField] float startingPlayerTemp;
    [SerializeField] float maxPlayerTemp;
    [SerializeField] float minPlayerTemp;
    public float playerTemp;
    
  
    void Start()
    {
        
        fuelStack = GetComponent<FuelStackManager>();
        temperatureManager = FindObjectOfType<TemperatureManager>();

        playerTemp=startingPlayerTemp;
        InvokeRepeating("CompareTemperatures", 1, 3);

        StartCoroutine(UsingFuel());
    }

    IEnumerator UsingFuel()
    {
        while (true)
        {
            if (fuelStack.fuelCount >= 1&& playerTemp<40) 
            {
                fuelStack.fuelCount--;
                fuelStack.UpdateFuelCountText();
                playerTemp += 2;
            }
            yield return new WaitForSeconds(3f);
        }
    }

    public void UpdatePlayerTemp()
    {
        playerTempText.text=playerTemp.ToString() + " C";
        playerTempImage.fillAmount = playerTemp / (maxPlayerTemp-minPlayerTemp);

        // post processing etkisi
        if (globalVolume!=null && globalVolume.profile.TryGetSettings(out globalVolumeVignette) && playerTemp<0)
        {
            globalVolumeVignette.intensity.value = playerTemp /minPlayerTemp;
        }

    }

    void CompareTemperatures()
    {
        float tempDiff= temperatureManager.airTemprerature - playerTemp ;
        playerTemp += Convert.ToInt32((tempDiff * 5) / 100);
        UpdatePlayerTemp();

        if (playerTemp<-20)
        {
            mainCanvasManager.isGameEnded = true;
            Time.timeScale = 0;
            playerGameOverPanel.SetActive(true);
        }
       
    }

}
