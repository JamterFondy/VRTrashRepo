using TMPro;
using UnityEngine;
using UnityEngine.Experimental.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.XR.CoreUtils;

public class UIManager : MonoBehaviour
{
    [SerializeField] private NumberBank numberBank;
    public Canvas UICanvas;
    public Camera cam;

    public TMP_Text pointText;
    public static int prePoint;

    public TMP_Text timerText;
    private float time;
    private float logTimer = 0f; // ログ用のタイマー
    private const float LOG_INTERVAL = 1f; // 1秒ごとにログ出す
    int cameraTimer;

    public TMP_Text resultPointText;

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
            time -= Time.deltaTime; // テスト減算
            cameraTimer = (int)time;
            timerText.text = cameraTimer.ToString();
        }

        logTimer += Time.deltaTime;
        if (logTimer >= LOG_INTERVAL)
        {
            Debug.Log($"残り{(int)time}秒");
            logTimer = 0f;
        }


        if (time <= 0)
        {
            time = 0;
            StartCoroutine(MoveToResultScene());

        }

    }

    IEnumerator MoveToResultScene()
    {
        Debug.Log("Wait For 3sec...");
        timerText.text = "Finish!";

        yield return new WaitForSeconds(3f);  // 3秒待つ


        timerText.text = " ";
        pointText.text = " ";

        resultPointText.text = $"TotalPoint : {prePoint}";

        yield return new WaitForSeconds(8f); // 8秒待つ

        SceneManager.LoadScene("TitleScene");
    }
}
