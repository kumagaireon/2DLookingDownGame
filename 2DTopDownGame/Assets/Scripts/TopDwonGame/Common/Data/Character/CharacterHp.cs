using UnityEngine;

namespace Common.Data.Character
{
    /// <summary>
    /// キャラクターのHPを管理するクラス
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

        // ダメージを受けたときにHPを減少させるメソッド
        public virtual void HP(int damage, GameObject target)
        {
            // ダメージを受けた後のHPを計算し、0から最大HPの範囲に制限
            currentHP = Mathf.Clamp(currentHP - damage, 0, maxHP);

            // HPが変わったことを通知するイベントを発生
            OnHPChanged?.Invoke(currentHP);

            // HPが0以下になった場合、死亡処理を実行
            if (currentHP <= 0)
            {
                characterDead.Dead(target);
            }
        }
    }
}