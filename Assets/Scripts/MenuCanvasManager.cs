using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvasManager : MonoBehaviour
{

    AudioSource canvasAudioSource;
    [SerializeField] AudioClip buttonClickClip;

   
    void Start()
    {
        canvasAudioSource = GetComponent<AudioSource>();       
    }


    public void PlayButton()
    {
        canvasAudioSource.PlayOneShot(buttonClickClip);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void QuitButton()
    {
        canvasAudioSource.PlayOneShot(buttonClickClip);
        Application.Quit();
    }
}
