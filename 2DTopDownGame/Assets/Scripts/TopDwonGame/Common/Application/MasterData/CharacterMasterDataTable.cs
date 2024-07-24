using TopDownGame.Common;
using System;
using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(
    fileName = "DataList",//ファイル名
   menuName = "ScriptabledObject/CharacterDataList",//                          
    order = 0)
]
public class CharacterMasterDataTable : ScriptableObject
{
    //データをリストで保存
    public List<Data> Enemies = new List<Data>();

    //PlayerDataList保存バス
    public const string PATH = "CharacterDataList";

    //このScriptableObjectの実態
    private static CharacterMasterDataTable _Entity;

    public static CharacterMasterDataTable Entity
    {
        get
        {
            //初アクセス時にロードする
            if (_Entity == null)
            {
                _Entity = Resources.Load<CharacterMasterDataTable>(PATH);

                if (_Entity == null)
                {
                    Debug.LogError(PATH + " not  found");
                }
            }
            return _Entity;
        }
    }
    /// <summary>
    /// 列挙型にしてResourcesから値を取得
    /// </summary>
    /// 
    public Data GetData(Data.CharacterType type)
    {
        return Enemies.Find(item => item.Type == type);
    }
}
[System.Serializable]
public class Data
{
    public enum CharacterType
    {
        Player,
        Enemy,
    }
    public string Name => _Name;
    [Header("名前")][SerializeField] private string _Name;
    public CharacterType Type => _Type;
    [Header("タイプ")][SerializeField] private CharacterType _Type;
    public int HP => _HP;
    [Header("HP")][SerializeField] private int _HP;
    public int Damage => _Damage;
    [Header("ダメージ量")][SerializeField] private int _Damage;
    public float Walkspd => _Walkspd;
    [Header("移動速度")][SerializeField] private float _Walkspd;
}