using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class BinTrashCan : MonoBehaviour
{
    [SerializeField] private NumberBank numberBank;
    private int BinPoint;



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
            BinPoint = numberBank.NumberBankList[0].BinPoint;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bin"))
        {
            Destroy(other.gameObject);
            Debug.Log("Bin Destroyed");
            PointCounter.prePoint += BinPoint;
            UIManager.prePoint += BinPoint; 
        }
    }
}
