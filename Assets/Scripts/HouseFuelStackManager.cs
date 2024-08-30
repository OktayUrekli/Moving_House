using TMPro;
using UnityEngine;

public class HouseFuelStackManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI houseFuelCountText;
    [SerializeField] public int houseFuelCount;

    void Start()
    {
        UpdateFuelCount();
    } 

    public void UpdateFuelCount()
    {
        houseFuelCountText.text = "Remaing Fuel:"+houseFuelCount.ToString() + " Wood";
    }
}
