using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "DataList",//ƒtƒ@ƒCƒ‹–¼
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