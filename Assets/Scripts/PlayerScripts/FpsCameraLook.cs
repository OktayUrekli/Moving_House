using UnityEngine;

public class FpsCameraLook : MonoBehaviour
{

    [SerializeField] float mouse_Sensitivity;
    [SerializeField] Transform playerBody;
    [SerializeField] Transform gunPoint;

    float xRotation = 0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouse_Sensitivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouse_Sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation=Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation,0,0);

        gunPoint.localRotation = Quaternion.Euler(xRotation,0,0) ;

        playerBody.Rotate(Vector3.up * mouseX);
    }
}
