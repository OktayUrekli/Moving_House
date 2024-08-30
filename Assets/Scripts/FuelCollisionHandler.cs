using UnityEngine;

public class FuelCollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject fuelCanvas;

    private void Start()
    {
        fuelCanvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fuelCanvas.SetActive(true);
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            fuelCanvas.SetActive(false);
        }
    }
}
