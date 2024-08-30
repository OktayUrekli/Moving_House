using TMPro;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{

    PlayerTempController playerTempController;
    FuelStackManager fuelStackManager;
   

    void Start()
    {
        playerTempController=gameObject.GetComponent<PlayerTempController>();
        fuelStackManager=gameObject.GetComponent<FuelStackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Snowball"))
        {
            playerTempController.playerTemp -= 3;
            playerTempController.UpdatePlayerTemp();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(other.gameObject);
            fuelStackManager.CollectedFuel();
        }
    }


}
