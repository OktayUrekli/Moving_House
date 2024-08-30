using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumperForce;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.up*jumperForce,ForceMode.Impulse);
        }
    }
}
