using Common;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [SerializeField] CharacterData data;
    [SerializeField] CharacterMove move;
    [SerializeField] CharacterAttack attack;
    [SerializeField] CharacterHp hp;
    [SerializeField] CharacterDead dead;
    [SerializeField] SoundController soundController;
    private void Awake()
    {
        move.MoveSpeed = data.MoveSpeed;
        attack.damage = data.Damage;
        hp.maxHP = data.HP;
        hp.characterDead = dead;
        dead.SoundController = soundController;
    }
    private void FixedUpdate()
    {
        move.Move();
    }
}
