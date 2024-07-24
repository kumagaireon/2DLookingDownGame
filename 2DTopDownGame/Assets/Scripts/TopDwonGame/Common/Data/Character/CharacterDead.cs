using UnityEngine;
namespace Common.Data.Character
{
    /// <summary>
    /// �L�����N�^�[�̎��S�������Ǘ����钊�ۃN���X
    /// </summary>
    public abstract class CharacterDead : MonoBehaviour
    {
        public SoundController SoundController { get; set; }

        // �w�肳�ꂽ�^�[�Q�b�g�I�u�W�F�N�g���A�N�e�B�u�ɂ��郁�\�b�h
        public void Dead(GameObject target)
        {
            SoundController.Death();
            target.gameObject.SetActive(false);
        }
    }
}