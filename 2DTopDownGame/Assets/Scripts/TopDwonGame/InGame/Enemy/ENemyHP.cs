using UnityEngine;

namespace InGame.Enemy
{
    public class EnemyHp : CharacterHp
    {
        public override void HP(int damage, GameObject target)
        {
            base.HP(damage, target); // 親クラスのHPメソッドを呼び出す

            if (currentHP <= 0)
            {
                TimeAndKill.IncrementEnemyKill();
            }
        }
    }
}