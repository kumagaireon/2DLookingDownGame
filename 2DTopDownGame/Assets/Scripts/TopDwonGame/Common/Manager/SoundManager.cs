using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : SingletonMonoBehehaviour<SoundManager>
{
    //SE�ő�`�����l����
    private const int SE_CHANNEL_NUM = 8;

    //�eAudioSource
    [Header("SE")]
    [SerializeField] private AudioSource[] seSources = new AudioSource[SE_CHANNEL_NUM];
    [Header("BGM")]
    [SerializeField] private AudioSource bgmSource;
    [Header("Voice")]
    [SerializeField] private AudioSource voiceSource;

    //�eAudioClip����ۑ����鎫��
    [SerializeField] private Dictionary<string, AudioClip> seData = new Dictionary<string, AudioClip>();
    [SerializeField] private Dictionary<string, AudioClip> bgmData = new Dictionary<string, AudioClip>();
    [SerializeField] private Dictionary<string, AudioClip> voiceData = new Dictionary<string, AudioClip>();

    protected override void Awake()
    {
        // ���N���X�̃V���O���g���L�q
        base.Awake();

        //�K�v��AudioSource�R���|�[�l���g��ǉ�
        for (int i = 0; i < seSources.Length; i++)
        {
            seSources[i] = gameObject.AddComponent<AudioSource>();
        }
        bgmSource = gameObject.AddComponent<AudioSource>();
        voiceSource = gameObject.AddComponent<AudioSource>();

        //BGM�����[�v�ݒ�ɂ���
        bgmSource.loop = true;

        //Resources�t�H���_�ȉ��̃T�E���h�f�[�^���擾
        var seClips = Resources.LoadAll<AudioClip>("Sound/Se");
        var bgmClips = Resources.LoadAll<AudioClip>("Sound/Bgm");
        var voiceClips = Resources.LoadAll<AudioClip>("Sound/Voice");

        //�擾�����T�E���h�f�[�^�������ɓo�^
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
        //���O�ɊY������f�[�^�������ɖ����Ƃ�
        if (!seData.ContainsKey(name))
        {
            Debug.LogError("se data isnt exist : " + name);
            return;
        }
        //��������Y������T�E���h�f�[�^��T���čĐ�
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
        //���O�ɊY������f�[�^�������ɖ����Ƃ�
        if (!seData.ContainsKey(name))
        {
            Debug.LogError("se data isnt exist : " + name);
            return;
        }
        //��������Y������T�E���h�f�[�^��T���čĐ�
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
        //���O�ɊY������f�[�^�������ɖ����Ƃ�
        if (!bgmData.ContainsKey(name))
        {
            Debug.LogError("bgm data isnt exist : " + name);
            return;
        }
        //�w�肵�����O��BGM�����łɍĐ����̂Ƃ�(�������Ȃ�)

        if (bgmSource.clip == bgmData[name])
        {
            return;
        }

        //���ʂ̃N�����v�����Ă�����
        bgmSource.volume = Mathf.Clamp01(volume);
        bgmSource.Play();

        //BGM�Đ�
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
        //���O�ɊY������f�[�^�������ɖ����Ƃ�
        if (!voiceData.ContainsKey(name))
        {
            Debug.LogError("se data isnt exist : " + name);
            return;
        }
        //Voice�Đ�
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
