using UnityEngine;
namespace Common.Data.Character
{
    /// <summary>
    /// �L�����N�^�[�̍U�����Ǘ����钊�ۃN���X
    /// </summary>
    public abstract class CharacterAttack : MonoBehaviour
    {
        public int damage { get; set; }
        protected GameObject currentObject;

        // �U�����\�b�h�B�U���\�ȏꍇ�Ƀ^�[�Q�b�g��HP������������
        public virtual void Attack()
        {
            if (IsAttack()) // �U���\���ǂ������`�F�b�N
            {
                // �^�[�Q�b�g��CharacterHp�R���|�[�l���g���擾
                CharacterHp hp = currentObject.GetComponent<CharacterHp>();

                // �^�[�Q�b�g��HP������������
                hp.HP(damage, currentObject);

                // �U����Ƀ^�[�Q�b�g���N���A
                currentObject = null;
            }
        }

        // �U���\���ǂ����𔻒肷�钊�ۃ��\�b�h
        protected abstract bool IsAttack();

        // �g���K�[�ɓ������Ƃ��ɌĂяo����郁�\�b�h
        private void OnTriggerEnter2D(Collider2D collision)
        {
            // �g���K�[�ɓ������I�u�W�F�N�g�����݂̃^�[�Q�b�g�Ƃ��Đݒ�
            currentObject = collision.gameObject;
        }
    }
}