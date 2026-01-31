using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BGMStarter : MonoBehaviour
{
    [SerializeField] private AudioClip bgmClip;      // インスペクターで設定するBGM
    [SerializeField] private bool loop = true;       // ループするか
    [Range(0f, 1f)]
    [SerializeField] private float volume = 1f;      // 音量

    private AudioSource audioSource;
    private bool prevGameStartState = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
        audioSource.loop = loop;
        audioSource.volume = volume;
        if (bgmClip != null) audioSource.clip = bgmClip;
    }

    void Update()
    {
        // GameStart が false -> true へ遷移したタイミングで再生を開始
        bool current = UIManager.GameStart;
        if (current && !prevGameStartState)
        {
            if (bgmClip == null)
            {
                Debug.LogWarning("BGMStarter: Inspector に AudioClip が設定されていません。");
            }
            else
            {
                if (audioSource.clip != bgmClip) audioSource.clip = bgmClip;
                audioSource.loop = loop;
                audioSource.volume = volume;
                if (!audioSource.isPlaying) audioSource.Play();
            }
        }

        prevGameStartState = current;
    }
}