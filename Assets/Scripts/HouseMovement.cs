using UnityEngine;


public class HouseMovement : MonoBehaviour
{
    Rigidbody houseRB;

    [SerializeField] public float houseSpeedMul;
    void Start()
    {
        houseRB = GetComponent<Rigidbody>();
       
    }
  
    void Update()
    {
        houseRB.AddForce(Vector3.right * houseSpeedMul*Time.deltaTime);
    }
}
