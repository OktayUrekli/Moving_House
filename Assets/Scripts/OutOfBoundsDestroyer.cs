using UnityEngine;

public class OutOfBoundsDestroyer : MonoBehaviour
{
    [SerializeField] Vector3 playerStartingPoint;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = playerStartingPoint;
        }
    }
}
