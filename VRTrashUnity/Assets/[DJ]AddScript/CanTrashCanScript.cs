using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class CanTrashCanScript : MonoBehaviour
{
    [SerializeField] private NumberBank numberBank;
    private int CanPoint;

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
            CanPoint = numberBank.NumberBankList[0].CanPoint;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Can"))
        {
            Destroy(other.gameObject);
            Debug.Log("Can Destroyed");
            PointCounter.prePoint += CanPoint;
            UIManager.prePoint += CanPoint;
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
        if (other.gameObject.CompareTag("Can"))
        {
            Destroy(other.gameObject);
            Debug.Log("Can Destroyed");
            PointCounter.prePoint += CanPoint;
            UIManager.prePoint += CanPoint;
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
