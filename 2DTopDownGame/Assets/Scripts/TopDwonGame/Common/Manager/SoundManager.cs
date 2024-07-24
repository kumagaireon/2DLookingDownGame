using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehehaviour<SoundManager>
{
    //SE最大チャンネル数
    private const int SE_CHANNEL_NUM = 8;

    //各AudioSource
    [Header("SE")]
    [SerializeField] private AudioSource[] seSources = new AudioSource[SE_CHANNEL_NUM];
    [Header("BGM")]
    [SerializeField] private AudioSource bgmSource;
    [Header("Voice")]
    [SerializeField] private AudioSource voiceSource;

    //各AudioClip情報を保存する辞書
    [SerializeField] private Dictionary<string, AudioClip> seData = new Dictionary<string, AudioClip>();
    [SerializeField] private Dictionary<string, AudioClip> bgmData = new Dictionary<string, AudioClip>();
    [SerializeField] private Dictionary<string, AudioClip> voiceData = new Dictionary<string, AudioClip>();

    protected override void Awake()
    {
        // 基底クラスのシングルトン記述
        base.Awake();

        //必要なAudioSourceコンポーネントを追加
        for (int i = 0; i < seSources.Length; i++)
        {
            seSources[i] = gameObject.AddComponent<AudioSource>();
        }
        bgmSource = gameObject.AddComponent<AudioSource>();
        voiceSource = gameObject.AddComponent<AudioSource>();

        //BGMをループ設定にする
        bgmSource.loop = true;

        //Resourcesフォルダ以下のサウンドデータを取得
        var seClips = Resources.LoadAll<AudioClip>("Sound/Se");
        var bgmClips = Resources.LoadAll<AudioClip>("Sound/Bgm");
        var voiceClips = Resources.LoadAll<AudioClip>("Sound/Voice");

        //取得したサウンドデータを辞書に登録
        for (int i = 0; i < seClips.Length; i++)
        {
            seData[seClips[i].name] = seClips[i];
        }
        for (int i = 0; i < bgmClips.Length; i++)
        {
            bgmData[bgmClips[i].name] = bgmClips[i];
        }
        for (int i = 0; i < voiceClips.Length; i++)
        {
            voiceData[voiceClips[i].name] = voiceClips[i];
        }
    }

    public void PlaySe(string name)
    {
        //名前に該当するデータが辞書に無いとき
        if (!seData.ContainsKey(name))
        {
            Debug.LogError("se data isnt exist : " + name);
            return;
        }
        //辞書から該当するサウンドデータを探して再生
        foreach (AudioSource source in seSources)
        {
            if (!source.isPlaying)
            {
                source.clip = seData[name];
                source.Play();
                return;
            }
        }
    }
    public void PlaySeOneShot(string name)
    {
        //名前に該当するデータが辞書に無いとき
        if (!seData.ContainsKey(name))
        {
            Debug.LogError("se data isnt exist : " + name);
            return;
        }
        //辞書から該当するサウンドデータを探して再生
        foreach (AudioSource source in seSources)
        {
            if (!source.isPlaying)
            {
                source.clip = seData[name];
                source.PlayOneShot(source.clip);
                return;
            }
        }
    }

    public void StopAllSe()
    {
        foreach (AudioSource source in seSources)
        {
            source.Stop();
            source.clip = null;
        }
    }

    public void PlayBgm(string name)
    {
        PlayBgm(name, 1f);
    }

    public void PlayBgm(string name, float volume)
    {
        //名前に該当するデータが辞書に無いとき
        if (!bgmData.ContainsKey(name))
        {
            Debug.LogError("bgm data isnt exist : " + name);
            return;
        }
        //指定した名前のBGMがすでに再生中のとき(何もしない)

        if (bgmSource.clip == bgmData[name])
        {
            return;
        }

        //音量のクランプかけてから代入
        bgmSource.volume = Mathf.Clamp01(volume);
        bgmSource.Play();

        //BGM再生
        bgmSource.Stop();
        bgmSource.clip = bgmData[name];
        bgmSource.Play();
    }

    public void StopBgm()
    {
        bgmSource.Stop();
        bgmSource.clip = null;
    }

    public void PlayVoice(string name)
    {
        //名前に該当するデータが辞書に無いとき
        if (!voiceData.ContainsKey(name))
        {
            Debug.LogError("se data isnt exist : " + name);
            return;
        }
        //Voice再生
        voiceSource.Stop();
        voiceSource.clip = voiceData[name];
        voiceSource.Play();
    }

    public void StopVoice()
    {
        voiceSource.Stop();
        voiceSource.clip = null;
    }
}
