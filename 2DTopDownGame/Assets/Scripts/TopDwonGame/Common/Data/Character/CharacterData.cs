using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "DataList",//ファイル名
   menuName = "ScriptabledObject/DataList",//                          
    order = 0)
]
public class CharacterData : ScriptableObject
{
    public int PlayerHP;
    public int EnemyHP;
    public float MoveSpeed;
    public int Damage;
}