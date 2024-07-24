using UnityEngine;

public abstract class SingletonMonoBehehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = ((T)FindObjectOfType(typeof(T)));
                if (instance == null)
                {
                    Debug.LogError(typeof(T) + "���A�^�b�`���Ă���I�u�W�F�N�g�����݂��܂���B");
                }
            }
            return instance;
        }
    }
    virtual protected void Awake()
    {
        // ���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă��邩���ׂ�
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
    }
}