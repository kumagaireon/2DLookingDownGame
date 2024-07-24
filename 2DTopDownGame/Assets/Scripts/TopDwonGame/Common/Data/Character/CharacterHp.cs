using UnityEngine;

namespace Common.Data.Character
{
    /// <summary>
    /// �L�����N�^�[��HP���Ǘ�����N���X
    /// </summary>
    public class CharacterHp : MonoBehaviour
    {
        public int currentHP { get; set; }
        public int maxHP { get; set; }
        public delegate void HPChanged(int currentHP);
        public event HPChanged OnHPChanged;

        public CharacterDead characterDead { get; set; }
        private void Start()
        {
            currentHP = maxHP;
        }

        // �_���[�W���󂯂��Ƃ���HP�����������郁�\�b�h
        public virtual void HP(int damage, GameObject target)
        {
            // �_���[�W���󂯂����HP���v�Z���A0����ő�HP�͈̔͂ɐ���
            currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);

            // HP���ς�������Ƃ�ʒm����C�x���g�𔭐�
            OnHPChanged?.Invoke(currentHP);

            // HP��0�ȉ��ɂȂ����ꍇ�A���S���������s
            if (currentHP <= 0)
            {
                characterDead.Dead(target);
            }
        }
    }
}