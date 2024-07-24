using Common.Data.Character;
using UnityEngine;

namespace InGame.Enemy
{
    public class EnemyHp : CharacterHp
    {  
        /// <summary>
        /// ダメージを受けたときにHPを減少させるメソッド
        /// </summary>
        /// <param name="damage">受けるダメージの量</param>
        /// <param name="target">攻撃対象のゲームオブジェクト</param>
        public override void HP(int damage, GameObject target)
        {
            base.HP(damage, target); // 親クラスのHPメソッドを呼び出す

            if (currentHP <= 0)
            {
                TimeAndKill.IncrementEnemyKill();//倒した数
            }
        }
    }
}