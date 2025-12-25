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
    private float time;
    private float logTimer = 0f; // ���O�p�̃^�C�}�[
    private const float LOG_INTERVAL = 1f; // 1�b���ƂɃ��O�o��
    int cameraTimer;

    public TMP_Text resultPointText;

    public bool toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        toggle = false;


        if (numberBank == null)
        {
            Debug.LogError("NumberBank���A�^�b�`����Ă��܂���B");
            return;
        }
        else if (numberBank != null && numberBank.NumberBankList.Count > 0)
        {
            time = numberBank.NumberBankList[0].MaxTime;
            prePoint = numberBank.NumberBankList[0].PointReset;
        }
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
        pointText.text = $"Point : {prePoint}";

        if (time > 0)
        {
            time -= Time.deltaTime; // �e�X�g���Z
            cameraTimer = (int)time;
            timerText.text = cameraTimer.ToString();
        }

        logTimer += Time.deltaTime;
        if (logTimer >= LOG_INTERVAL)
        {
            Debug.Log($"�c��{(int)time}�b");
            logTimer = 0f;
        }


        if (time <= 0 && toggle == false)
        {
            time = 0;
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

        yield return new WaitForSeconds(3f);  // 3�b�҂�


        timerText.text = " ";
        pointText.text = " ";

        // スコアを保存
        SaveScore(prePoint);

        // ランキングを表示
        DisplayRanking();

        yield return new WaitForSeconds(8f); // 8�b�҂�

        SceneManager.LoadScene("TitleScene");
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