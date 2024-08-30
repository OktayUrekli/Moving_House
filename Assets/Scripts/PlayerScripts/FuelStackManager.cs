using TMPro;
using UnityEngine;

public class FuelStackManager : MonoBehaviour
{
    [SerializeField] public int fuelCount;
    [SerializeField] TextMeshProUGUI fuelCountText;

    private void Start()
    {
        UpdateFuelCountText();
    }

    public void CollectedFuel()
    {
        fuelCount += 5;

        if (fuelCount > 25)
        {
            fuelCount = 25;
        }
        UpdateFuelCountText();
    }

    public void UpdateFuelCountText()
    {
        fuelCountText.text = fuelCount.ToString() + " Wood";
    }
}
