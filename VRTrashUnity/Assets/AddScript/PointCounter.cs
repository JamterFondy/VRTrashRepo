using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class PointCounter : MonoBehaviour
{
    [SerializeField] private NumberBank numberBank;
    public static int prePoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        prePoint = numberBank.NumberBankList[0].PointReset;
    }

    // Update is called once per frame
    void Update()
    { 
        Debug.Log(prePoint);   
    }
}
