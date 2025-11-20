using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var button = GetComponent<Button>();

        button.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("BaseScene");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
