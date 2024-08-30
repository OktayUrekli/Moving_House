using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun; // G�ne�i temsil eden Directional Light
    public float dayLengthInMinutes = 1f; // Bir g�n ka� dakika s�rs�n
    public Gradient sunColor; // G�ne�in rengi g�n boyunca de�i�ebilir
    public AnimationCurve sunIntensityCurve; // G�ne�in yo�unlu�u i�in bir e�ri (g�nd�z parlak, gece lo�)

    private float timeOfDay = 0f; // G�n�n zaman� (0-1 aras�nda)
    private float rotationSpeed; // G�ne�in d�n�� h�z�

    void Start()
    {
        // G�ne�in d�n�� h�z�n� ayarla (360 derece bir tam g�n)
        rotationSpeed = 360f / (dayLengthInMinutes * 60f); // Dakikadan saniyeye
    }

    void Update()
    {
        // Zaman� ilerlet
        timeOfDay += Time.deltaTime / (dayLengthInMinutes * 60f);

        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f; // G�n bitti�inde yeniden ba�lat
        }

        // G�ne�i d�nd�r
        sun.transform.localRotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170f, 0f));

        // G�ne�in rengini g�n�n saatine g�re ayarla
        sun.color = sunColor.Evaluate(timeOfDay);

        // G�ne�in yo�unlu�unu g�n�n saatine g�re ayarla
        sun.intensity = sunIntensityCurve.Evaluate(timeOfDay);
    }
}

