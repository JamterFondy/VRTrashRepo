using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPortal : MonoBehaviour
{
    [SerializeField] GomiManager gomiManager;
    public GameObject startGomi;

    public AudioClip seClip;   // InspectorÇ≈ê›íË
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
      if (other.gameObject.CompareTag("StartGomi"))
      {
          UIManager.GameStart = true;

            Destroy(other.gameObject);

            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();

                if (audioSource == null)
                {
                    audioSource = gameObject.AddComponent<AudioSource>();
                    audioSource.playOnAwake = false; // îOÇÃÇΩÇﬂ
                }

                audioSource.clip = seClip;
            }

            audioSource.Play();


            gomiManager.StartTrashSpawn();

            startGomi.SetActive(false);
      }
    }
}
