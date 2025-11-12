using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private NumberBank numberBank;
    private float time;

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
            time = numberBank.NumberBankList[0].MaxTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"残り{(int)time}秒");

        if (time > 0)
        {
            time -= Time.deltaTime; // テスト減算
        }
    }

        
}
