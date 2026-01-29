using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPortal : MonoBehaviour
{
    [SerializeField] GomiManager gomiManager;
    public GameObject startGomi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.CompareTag("StartGomi"))
      {
          UIManager.GameStart = true;
         
          gomiManager.StartTrashSpawn();

            startGomi.SetActive(false);
      }
    }
}
