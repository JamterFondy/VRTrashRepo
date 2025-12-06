using UnityEngine;
using UnityEngine.SceneManagement;

public class StartPortal : MonoBehaviour
{
    public GameObject player;

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
        if (player.CompareTag("Player"))
        {
            SceneManager.LoadScene("BaseScene");
            SceneManager.LoadScene("SampleScene",LoadSceneMode.Additive);
        }
    }
}
