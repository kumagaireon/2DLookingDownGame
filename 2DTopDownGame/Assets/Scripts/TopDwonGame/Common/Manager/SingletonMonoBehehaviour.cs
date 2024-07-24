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
                    Debug.LogError(typeof(T) + "をアタッチしているオブジェクトが存在しません。");
                }
            }
            return instance;
        }
    }
    virtual protected void Awake()
    {
        // 他のゲームオブジェクトにアタッチされているか調べる
        if (this != Instance)
        {
            Destroy(this);
            return;
        }
        DontDestroyOnLoad(this);
    }
}