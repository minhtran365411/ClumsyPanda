using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//------------------------------
public class Health : MonoBehaviour
{
    //public GameObject DeathParticlesPrefab = null;
    private Transform ThisTransform = null;
    public bool ShouldDestroyOnDeath = true;
    public GameObject LosingCanvas;

    //------------------------------
    [SerializeField]
    private float _HealthPoints = 100f;

    // //HealthBar
    public Slider healthBar;
    // private float HP = 100;

    //------------------------------
    void Start()
    {
        ThisTransform = GetComponent<Transform>();
        healthBar.value = _HealthPoints;

    }
    //------------------------------
    public float HealthPoints
    {
        get
        {
            return _HealthPoints;
            //return HP;
            
        }

        set
        {
            _HealthPoints = value;
            

            if (_HealthPoints <= 0)
            {
                //SendMessage("Die", SendMessageOptions.DontRequireReceiver);

                LosingCanvas.SetActive(true);

                if (ShouldDestroyOnDeath) {
                    Destroy(gameObject);
                    Destroy(ThisTransform);
                }
                
            }
        }
    }
    //------------------------------
    private void Update()
    {
        healthBar.value = (_HealthPoints/100);

    }
    
}
//------------------------------