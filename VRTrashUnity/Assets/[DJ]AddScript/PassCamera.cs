using UnityEngine;

public class PassCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UIManager ui = Object.FindFirstObjectByType<UIManager>();
        ui.AssignCamera(GetComponent<Camera>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
