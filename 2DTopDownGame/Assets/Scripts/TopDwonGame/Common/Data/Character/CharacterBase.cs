using Common;
using UnityEngine;
namespace Common.Data.Character
{
    /// <summary>
    /// キャラクターの基本的な設定と動作を管理するクラス
    /// </summary>
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField] CharacterData data; // キャラクターのデータ
        [SerializeField] CharacterMove move; // キャラクターの移動を管理するコンポーネント
        [SerializeField] CharacterAttack attack; // キャラクターの攻撃を管理するコンポーネント
        [SerializeField] CharacterHp hp; // キャラクターのHPを管理するコンポーネント
        [SerializeField] CharacterDead dead; // キャラクターの死亡処理を管理するコンポーネント
        [SerializeField] SoundController soundController; // サウンドコントローラー

        // オブジェクトが有効になったときに呼び出される
        private void Awake()
        {
            // キャラクターの各コンポーネントにデータを設定
            move.MoveSpeed = data.MoveSpeed; // 移動速度を設定
            attack.damage = data.Damage; // 攻撃のダメージを設定
            hp.maxHP = data.HP; // 最大HPを設定
            hp.characterDead = dead; // 死亡処理を設定
            dead.SoundController = soundController; // サウンドコントローラーを設定
        }

        // 固定更新メソッド。物理演算の更新タイミングで呼び出される
        private void FixedUpdate()
        {
            move.Move(); // キャラクターを移動
        }
    }
}