using UnityEngine;


[CreateAssetMenu(fileName = "SnowballType", menuName = "Snowball")]
public class SnowballSO : ScriptableObject
{
    [SerializeField] public float minus_temperature;
    [SerializeField] public Vector3 scale;
    [SerializeField] public float mass;
    public int snowballBounceCount;


   //  [SerializeField] ParticleSystem breakeffect;
}
