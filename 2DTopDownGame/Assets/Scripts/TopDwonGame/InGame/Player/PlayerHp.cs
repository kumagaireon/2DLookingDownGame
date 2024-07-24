using UnityEngine;

namespace InGame.Player
{
    public class PlayerHp : CharacterHp
    {
        public override void HP(int damage,GameObject target)
        {
            base.HP(damage, target); // 親クラスのHPメソッドを呼び出す

            if (currentHP <= 0)
            {
                FindObjectOfType<SceneController>().Result();
            }
        }
    }
}