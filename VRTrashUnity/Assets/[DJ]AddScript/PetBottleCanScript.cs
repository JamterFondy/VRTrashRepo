using UnityEngine;
using UnityEngine.Experimental.Rendering;


public class PetBottleCanScript : MonoBehaviour
{
    [SerializeField] private NumberBank numberBank;
    private int PetPoint;

    public AudioClip seClip;   // Inspectorで設定
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (numberBank == null)
        {
            Debug.LogError("NumberBankがアタッチされていません。");
            return;
        }
        else if (numberBank != null && numberBank.NumberBankList.Count > 0)
        {
            PetPoint = numberBank.NumberBankList[0].PetBottlePoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PetBottle"))
        {
            Destroy(other.gameObject);
            Debug.Log("PetBottle Destroyed");
            PointCounter.prePoint += PetPoint;
            UIManager.prePoint += PetPoint;
        }

        if (audioSource.clip == null)
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false; // 念のため
            }

            audioSource.clip = seClip;
        }

        audioSource.Play();
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("PetBottle"))
        {
            Destroy(other.gameObject);
            Debug.Log("PetBottle Destroyed");
            PointCounter.prePoint += PetPoint;
            UIManager.prePoint += PetPoint;
        }

        if (audioSource.clip == null)
        {
            audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
                audioSource.playOnAwake = false; // 念のため
            }

            audioSource.clip = seClip;
        }

        audioSource.Play();
    }
}
