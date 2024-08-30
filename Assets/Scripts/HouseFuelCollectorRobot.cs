using UnityEngine;

public class HouseFuelCollectorRobot : MonoBehaviour
{
    FuelStackManager playerFuelStack;
    HouseFuelStackManager houseFuelStackManager;


    private void Start()
    {
        houseFuelStackManager = FindAnyObjectByType<HouseFuelStackManager>();
        playerFuelStack=FindAnyObjectByType<FuelStackManager>();
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && playerFuelStack.fuelCount>0)
        {
            playerFuelStack.fuelCount--;
            playerFuelStack.UpdateFuelCountText();

            houseFuelStackManager.houseFuelCount++;
            houseFuelStackManager.UpdateFuelCount();
        }
    }
}
