using Common.Data.Character;
using UnityEngine;

namespace InGame.Enemy
{
    public class EnemyHp : CharacterHp
    {  
        /// <summary>
        /// �_���[�W���󂯂��Ƃ���HP�����������郁�\�b�h
        /// </summary>
        /// <param name="damage">�󂯂�_���[�W�̗�</param>
        /// <param name="target">�U���Ώۂ̃Q�[���I�u�W�F�N�g</param>
        public override void HP(int damage, GameObject target)
        {
            base.HP(damage, target); // �e�N���X��HP���\�b�h���Ăяo��

            if (currentHP <= 0)
            {
                TimeAndKill.IncrementEnemyKill();//�|������
            }
        }
    }
}