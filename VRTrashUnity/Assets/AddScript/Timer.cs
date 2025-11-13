using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private NumberBank numberBank;
    private float time;
    private float logTimer = 0f; // ログ用のタイマー
    private const float LOG_INTERVAL = 1f; // 1秒ごとにログ出す

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

        if (time > 0)
        {
            time -= Time.deltaTime; // テスト減算
        }

        logTimer += Time.deltaTime;
        if (logTimer >= LOG_INTERVAL)
        {
            Debug.Log($"残り{(int)time}秒");
            logTimer = 0f;
        }
    }

        
}
