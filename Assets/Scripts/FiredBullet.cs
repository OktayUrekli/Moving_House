using UnityEngine;

public class FiredBullet : MonoBehaviour
{
    [SerializeField] float bullet_force;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * bullet_force * Time.deltaTime,ForceMode.Impulse);
        Destroy(gameObject,5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
