using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Common.Data
{
    public class CharacterHp : MonoBehaviour
    {
        public enum CharacterType
        {
            Player,
            Enemy
        }
        [SerializeField] CharacterData character;
        public int currentHP;
        public int maxHP;
        public CharacterType Type;

        public delegate void HPChanged(int currentHP);
        public event HPChanged OnHPChanged;
        CharacterDead CharacterDead;
        private void Awake()
        {
            if (Type == CharacterType.Player)
                currentHP = maxHP = character.PlayerHP;
            else if (Type == CharacterType.Enemy)
                currentHP = maxHP = character.EnemyHP;
            CharacterDead = GetComponentInChildren<CharacterDead>();
        }

        // ダメージを受けるメソッド
        public void TakeDamage(int damage)
        {
            currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);
            OnHPChanged?.Invoke(currentHP);

            if (currentHP == 0)
            {
                CharacterDead.Dead();
                if (Type == CharacterType.Player)
                {
                    FindObjectOfType<SceneController>().Result();
                }
            }
        }
    }
}