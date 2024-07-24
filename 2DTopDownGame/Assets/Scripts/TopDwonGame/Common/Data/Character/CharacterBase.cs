using Common;
using UnityEngine;
namespace Common.Data.Character
{
    /// <summary>
    /// �L�����N�^�[�̊�{�I�Ȑݒ�Ɠ�����Ǘ�����N���X
    /// </summary>
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField] CharacterData data; // �L�����N�^�[�̃f�[�^
        [SerializeField] CharacterMove move; // �L�����N�^�[�̈ړ����Ǘ�����R���|�[�l���g
        [SerializeField] CharacterAttack attack; // �L�����N�^�[�̍U�����Ǘ�����R���|�[�l���g
        [SerializeField] CharacterHp hp; // �L�����N�^�[��HP���Ǘ�����R���|�[�l���g
        [SerializeField] CharacterDead dead; // �L�����N�^�[�̎��S�������Ǘ�����R���|�[�l���g
        [SerializeField] SoundController soundController; // �T�E���h�R���g���[���[

        // �I�u�W�F�N�g���L���ɂȂ����Ƃ��ɌĂяo�����
        private void Awake()
        {
            // �L�����N�^�[�̊e�R���|�[�l���g�Ƀf�[�^��ݒ�
            move.MoveSpeed = data.MoveSpeed; // �ړ����x��ݒ�
            attack.damage = data.Damage; // �U���̃_���[�W��ݒ�
            hp.maxHP = data.HP; // �ő�HP��ݒ�
            hp.characterDead = dead; // ���S������ݒ�
            dead.SoundController = soundController; // �T�E���h�R���g���[���[��ݒ�
        }

        // �Œ�X�V���\�b�h�B�������Z�̍X�V�^�C�~���O�ŌĂяo�����
        private void FixedUpdate()
        {
            move.Move(); // �L�����N�^�[���ړ�
        }
    }
}