using TopDownGame.Common;
using System;
using System.Collections;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(
    fileName = "DataList",//�t�@�C����
   menuName = "ScriptabledObject/CharacterDataList",//                          
    order = 0)
]
public class CharacterMasterDataTable : ScriptableObject
{
    //�f�[�^�����X�g�ŕۑ�
    public List<Data> Enemies = new List<Data>();

    //PlayerDataList�ۑ��o�X
    public const string PATH = "CharacterDataList";

    //����ScriptableObject�̎���
    private static CharacterMasterDataTable _Entity;

    public static CharacterMasterDataTable Entity
    {
        get
        {
            //���A�N�Z�X���Ƀ��[�h����
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
    /// �񋓌^�ɂ���Resources����l���擾
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
    [Header("���O")][SerializeField] private string _Name;
    public CharacterType Type => _Type;
    [Header("�^�C�v")][SerializeField] private CharacterType _Type;
    public int HP => _HP;
    [Header("HP")][SerializeField] private int _HP;
    public int Damage => _Damage;
    [Header("�_���[�W��")][SerializeField] private int _Damage;
    public float Walkspd => _Walkspd;
    [Header("�ړ����x")][SerializeField] private float _Walkspd;
}