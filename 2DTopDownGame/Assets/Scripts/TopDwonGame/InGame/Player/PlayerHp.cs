using UnityEngine;

namespace InGame.Player
{
    public class PlayerHp : CharacterHp
    {
        public override void HP(int damage,GameObject target)
        {
            base.HP(damage, target); // �e�N���X��HP���\�b�h���Ăяo��

            if (currentHP <= 0)
            {
                FindObjectOfType<SceneController>().Result();
            }
        }
    }
}