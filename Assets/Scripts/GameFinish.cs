using UnityEngine;

public class GameFinish : MonoBehaviour
{
    [SerializeField] MainCanvasManager mainCanvasManager;
    [SerializeField] GameObject finishPanel;

    private void Start()
    {
        finishPanel.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingHouse")) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            mainCanvasManager.isGameEnded = true;
            Time.timeScale = 0;
            finishPanel.gameObject.SetActive(true);
        }
    }
}
