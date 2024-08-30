using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvasManager : MonoBehaviour
{
    AudioSource mainCanvasAudioSource;

    [SerializeField] AudioClip buttonClickSound;
    [SerializeField] GameObject gamePausedPanel;

    public bool isGameEnded;
   
    void Start()
    {
        isGameEnded=false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        mainCanvasAudioSource = GetComponent<AudioSource>();
        gamePausedPanel.SetActive(false);
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }
    }

    public void PauseButton()
    {
        if (isGameEnded==false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            mainCanvasAudioSource.PlayOneShot(buttonClickSound);
            Time.timeScale = 0;
            gamePausedPanel.SetActive(true);
        }
    }

    public void ContinueGameButton()
    {
        mainCanvasAudioSource.PlayOneShot(buttonClickSound);
        Time.timeScale = 1;
        gamePausedPanel.SetActive(false);
    }

    public void RestartGameButton() // play again button 
    {
        mainCanvasAudioSource.PlayOneShot(buttonClickSound);
        Time.timeScale = 1;
        gamePausedPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnMenuButton()
    {
        mainCanvasAudioSource.PlayOneShot(buttonClickSound);
        Time.timeScale = 1;
        SceneManager.LoadScene(0); // menu index = 0
    }
}
