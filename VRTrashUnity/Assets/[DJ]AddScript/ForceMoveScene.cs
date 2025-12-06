using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ForceMoveScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine("StartScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("BaseScene");
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);

    }
}
