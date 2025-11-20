using UnityEngine;
using UnityEngine.UI;

public class ResultScoreUI : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        int testScore = 999;  // 仮スコア表示
        scoreText.text = "スコア："+testScore.ToString();
    }
}
