using UnityEngine;


public class SnowBallMechanic : MonoBehaviour
{
    AudioSource snowBallAudioSource;

    [SerializeField] SnowballSO[] snowballType;
    [SerializeField] SnowballSO snowballScriptableObject;

    [SerializeField] ParticleSystem snowballImpact;

    TemperatureManager tempManager;

    float minus_Temp;
    int bounceCount;

    

    private void Start()
    {
        snowBallAudioSource = GetComponent<AudioSource>();
        tempManager = GameObject.Find("TemperatureManager").GetComponent<TemperatureManager>();

        FindRandomSnowballType();
        SetSnowballVariables();
    }

    

    void FindRandomSnowballType()
    {
        int type=Random.Range(0,snowballType.Length);
        snowballScriptableObject=snowballType[type];
    }

    void SetSnowballVariables()
    {
        transform.localScale = snowballScriptableObject.scale;
        transform.GetComponent<Rigidbody>().mass = snowballScriptableObject.mass;
        minus_Temp = snowballScriptableObject.minus_temperature;
        bounceCount=snowballScriptableObject.snowballBounceCount;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( !collision.gameObject.CompareTag("Bullet"))
        {
            bounceCount--;
            snowBallAudioSource.Play();

            if (bounceCount < 0)
            {    
                
                if (snowballScriptableObject == snowballType[2]) // b�y�k kartopu par�aland�
                {
                    tempManager.airTempDecreasePoint += minus_Temp;
                }
                else if (snowballScriptableObject == snowballType[1])// e�er par�alanan kartopu orta boy ise
                {
                    tempManager.airTempDecreasePoint += minus_Temp;
                }
                else // k���k kartopu ise
                {
                    tempManager.airTempDecreasePoint += minus_Temp;
                }
                SnowballImpact();

            }
        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            // kartopu mermi ile vuruldu�unda olacaklar
            SnowballImpact();
        }
    }


    // mermi ile par�alanan kartopu yerine 2 k���k kartopu getiren metot
    void SnowballImpact()
    {
        snowballImpact.Play();
        Destroy(gameObject,0.2f);

     /*
        else if(snowballScriptableObject == snowballType[1])// e�er par�alanan kartopu orta boy ise
        {
            Destroy(gameObject);

            // iki tane k���k kartopu olu�turdu
            Instantiate(snowballType[0], gameObject.transform);
            Instantiate(snowballType[0], gameObject.transform);
        }
        else // k���k kartopu ise
        {
            Destroy(gameObject) ;
        }
     */
    }
}
