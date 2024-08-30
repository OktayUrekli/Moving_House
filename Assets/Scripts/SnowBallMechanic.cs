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
                
                if (snowballScriptableObject == snowballType[2]) // büyük kartopu parçalandý
                {
                    tempManager.airTempDecreasePoint += minus_Temp;
                }
                else if (snowballScriptableObject == snowballType[1])// eðer parçalanan kartopu orta boy ise
                {
                    tempManager.airTempDecreasePoint += minus_Temp;
                }
                else // küçük kartopu ise
                {
                    tempManager.airTempDecreasePoint += minus_Temp;
                }
                SnowballImpact();

            }
        }
        else if(collision.gameObject.CompareTag("Bullet"))
        {
            // kartopu mermi ile vurulduðunda olacaklar
            SnowballImpact();
        }
    }


    // mermi ile parçalanan kartopu yerine 2 küçük kartopu getiren metot
    void SnowballImpact()
    {
        snowballImpact.Play();
        Destroy(gameObject,0.2f);

     /*
        else if(snowballScriptableObject == snowballType[1])// eðer parçalanan kartopu orta boy ise
        {
            Destroy(gameObject);

            // iki tane küçük kartopu oluþturdu
            Instantiate(snowballType[0], gameObject.transform);
            Instantiate(snowballType[0], gameObject.transform);
        }
        else // küçük kartopu ise
        {
            Destroy(gameObject) ;
        }
     */
    }
}
