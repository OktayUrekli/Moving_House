using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light sun; // Güneþi temsil eden Directional Light
    public float dayLengthInMinutes = 1f; // Bir gün kaç dakika sürsün
    public Gradient sunColor; // Güneþin rengi gün boyunca deðiþebilir
    public AnimationCurve sunIntensityCurve; // Güneþin yoðunluðu için bir eðri (gündüz parlak, gece loþ)

    private float timeOfDay = 0f; // Günün zamaný (0-1 arasýnda)
    private float rotationSpeed; // Güneþin dönüþ hýzý

    void Start()
    {
        // Güneþin dönüþ hýzýný ayarla (360 derece bir tam gün)
        rotationSpeed = 360f / (dayLengthInMinutes * 60f); // Dakikadan saniyeye
    }

    void Update()
    {
        // Zamaný ilerlet
        timeOfDay += Time.deltaTime / (dayLengthInMinutes * 60f);

        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f; // Gün bittiðinde yeniden baþlat
        }

        // Güneþi döndür
        sun.transform.localRotation = Quaternion.Euler(new Vector3((timeOfDay * 360f) - 90f, 170f, 0f));

        // Güneþin rengini günün saatine göre ayarla
        sun.color = sunColor.Evaluate(timeOfDay);

        // Güneþin yoðunluðunu günün saatine göre ayarla
        sun.intensity = sunIntensityCurve.Evaluate(timeOfDay);
    }
}

