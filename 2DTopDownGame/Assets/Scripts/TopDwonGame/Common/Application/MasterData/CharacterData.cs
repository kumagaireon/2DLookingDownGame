using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{

    [CreateAssetMenu(
        fileName = "DataList",//ƒtƒ@ƒCƒ‹–¼
       menuName = "ScriptabledObject/DataList",//                          
        order = 0)
    ]
    public class CharacterData : ScriptableObject
    {
        public int HP;
        public float MoveSpeed;
        public int Damage;


        public int PlayerHP;
        public int EnemyHP;
        public float playerMoveSpeed;
        public float EnemyMoveSpeed;
    }
}