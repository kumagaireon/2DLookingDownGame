using UnityEngine;

namespace InGame.Enemy
{
    public class EnemyHp : CharacterHp
    {
        public override void HP(int damage, GameObject target)
        {
            base.HP(damage, target); // �e�N���X��HP���\�b�h���Ăяo��

            if (currentHP <= 0)
            {
                TimeAndKill.IncrementEnemyKill();
            }
        }
    }
}