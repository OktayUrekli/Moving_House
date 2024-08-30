using UnityEngine;

public class Fire : MonoBehaviour
{
    AudioSource playerAS;

    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;

    private void Start()
    {
        playerAS = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
            playerAS.Play();
            Instantiate(projectilePrefab, firePoint.position, firePoint.transform.rotation);
        }
    }
}
