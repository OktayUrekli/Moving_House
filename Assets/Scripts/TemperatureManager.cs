using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TemperatureManager : MonoBehaviour
{

    [SerializeField] PostProcessVolume globalVolume;

    ColorGrading globalVolumeColorGradient;
    

    [SerializeField] TextMeshProUGUI airTempText;

    [SerializeField] float startingTemprerature=20;

    public float airTemprerature;
    public float airTempDecreasePoint;

    void Start()
    {
        airTemprerature = startingTemprerature;
        airTempDecreasePoint = 0;
        UpdateAirTemp();
        InvokeRepeating("AirTempControl", 0, 0.3f);
    }


    void AirTempControl()
    {
        if (airTempDecreasePoint >= 50)
        {
            airTemprerature -= 1;
            UpdateAirTemp();
            airTempDecreasePoint = 0;
        }
    }

    public void UpdateAirTemp()
    {
        if (globalVolume!=null && globalVolume.profile.TryGetSettings(out globalVolumeColorGradient))
        {
            globalVolumeColorGradient.temperature.value =airTemprerature;
        }
       
        airTempText.text=airTemprerature.ToString();
    }

}
