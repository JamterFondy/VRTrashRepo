using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.XR.CoreUtils;
using System.Collections.Generic; // 追加: リストを使用するため
using System.Linq; // 追加: ソートのため

public class UIManager : MonoBehaviour
{
    [SerializeField] private NumberBank numberBank;
    public Canvas UICanvas;
    public Camera cam;

    public TMP_Text pointText;
    public static int prePoint;

    public TMP_Text timerText;
    private float time; // 表示用の残り時間（秒）

    private float baseTime; // 固有値（MaxTime）を保持

    private int timegoSeconds; // プレイ時間計測（秒）
    private int timekeepSeconds; // スタート前に蓄積された秒数（秒）
    private float secondAccumulator = 0f; // 1秒ごとのカウント用

    private float logTimer = 0f; // ログ出力タイマー
    private const float LOG_INTERVAL = 1f; // 1秒ごとにログ
    public static int cameraTimer;

    public TMP_Text resultPointText;

    public static bool GameStart;

    public bool toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameStart = false;
        toggle = false;


        if (numberBank == null)
        {
            Debug.LogError("NumberBankがアサインされていません");
            return;
        }
        else if (numberBank != null && numberBank.NumberBankList.Count > 0)
        {
            baseTime = numberBank.NumberBankList[0].MaxTime; // 固有値を保持
            time = baseTime; // 初期は残り時間 = 固有値
            prePoint = numberBank.NumberBankList[0].PointReset;
        }

        timegoSeconds = 0;
        timekeepSeconds = 0;
        secondAccumulator = 0f;
    }

    public void AssignCamera(Camera targetCam)
    {
        cam = targetCam;
        UICanvas.worldCamera = cam;
        UICanvas.transform.SetParent(cam.transform, false);
        UICanvas.transform.localPosition = new Vector3(0, 0, 2f);
        UICanvas.transform.localRotation = Quaternion.identity;
    }


    // Update is called once per frame
    void Update()
    {
        // 秒単位でカウントするための蓄積
        secondAccumulator += Time.deltaTime;
        if (secondAccumulator >= 1f)
        {
            // 経過した「整数秒」を取り出す（フレーム落ちで1秒以上経過した場合も対応）
            int elapsedWholeSeconds = Mathf.FloorToInt(secondAccumulator);
            secondAccumulator -= elapsedWholeSeconds;

            if (!GameStart && baseTime > 0f)
            {
                // スタート前：timego と timekeep を毎秒1ずつ増やす
                timegoSeconds += elapsedWholeSeconds;
                timekeepSeconds += elapsedWholeSeconds;
            }
            else if (baseTime > 0f)
            {
                // スタート後：timego のみ増やし、timekeep は停止（値は固定）
                timegoSeconds += elapsedWholeSeconds;
            }
        }

        // 残り時間を baseTime - (timego - timekeep) で計算
        time = baseTime - (timegoSeconds - timekeepSeconds);
        if (time < 0f) time = 0f;

        // UI 表示更新（常に表示）
        if(GameStart)
        {
            cameraTimer = (int)time;
            timerText.text = cameraTimer.ToString();
        }
        

        if (UIManager.GameStart) pointText.text = $"Point : {prePoint}";

        logTimer += Time.deltaTime;
        if (logTimer >= LOG_INTERVAL)
        {
            Debug.Log($"残り{(int)time}秒");
            logTimer = 0f;
        }

        if (time <= 0f && toggle == false)
        {
            time = 0f;
            StartCoroutine(MoveToResultScene());
            toggle = true;
        }

    }

    // スコアを保存するメソッド
    private void SaveScore(int score)
    {
        List<int> scores = GetRanking(); // 既存のランキングを取得
        scores.Add(score); // 新しいスコアを追加
        string json = JsonUtility.ToJson(new ScoreList { scores = scores }); // JSONに変換
        PlayerPrefs.SetString("ScoreRanking", json); // 保存
        PlayerPrefs.Save();
    }

    // ランキングを取得するメソッド (降順ソート)
    private List<int> GetRanking()
    {
        string json = PlayerPrefs.GetString("ScoreRanking", "{}");
        ScoreList scoreList = JsonUtility.FromJson<ScoreList>(json);
        return scoreList.scores.OrderByDescending(s => s).ToList(); // 降順ソート
    }

    // ランキングを表示するメソッド (上位5位まで)
    private void DisplayRanking()
    {
        List<int> ranking = GetRanking();
        string rankingText = "Ranking:\n";
        for (int i = 0; i < Mathf.Min(5, ranking.Count); i++)
        {
            rankingText += $"{i + 1}. {ranking[i]}\n";
        }
        resultPointText.text = $"TotalPoint : {prePoint}\n\n{rankingText}";
    }

    IEnumerator MoveToResultScene()
    {
        Debug.Log("Wait For 3sec...");
        timerText.text = "Finish!";

        yield return new WaitForSeconds(3f);  // 3秒待機


        timerText.text = " ";
        pointText.text = " ";

        // スコアを保存
        SaveScore(prePoint);

        // ランキングを表示
        DisplayRanking();

        yield return new WaitForSeconds(8f); // 8秒待機

        SceneManager.LoadScene("TitleScene");
        SceneManager.UnloadSceneAsync("SampleScene");
    }
}

// スコアリスト用のシリアライズ可能なクラス (JSON保存用)
[System.Serializable]
public class ScoreList
{
    public List<int> scores = new List<int>();

    void Start()
    {

    }
}