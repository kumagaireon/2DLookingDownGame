using System;
using UnityEngine;
namespace TopDownGame.Common.Data
{
    public enum CharacterType
    {
        None = 0,
        Player,
        Enemy,
    }
  /*  [Union(0, typeof(CharacterDataEntity))]*/

    public interface ICharacterDataEntity : IDataEntity
    {
        CharacterType Type { get; }
        float MovementSpeed { get; }
        float JumpPower { get; }
    }

   /* [MessagePackObject(true)]*/

    public struct CharacterDataEntity : ICharacterDataEntity,
      IEquatable<CharacterDataEntity>
    {
        public Guid Id { get; }
        public string Name { get; }
        public CharacterType Type { get; }
        public float MovementSpeed { get; }
        public float JumpPower { get; }

        public CharacterDataEntity(Guid id, string name, CharacterType type, float movementSpeed, float jumpPower)
        {
            Id = id;
            Name = name;
            Type = type;
            MovementSpeed = movementSpeed;
            JumpPower = jumpPower;
        }
        public override bool Equals(object obj)
       => obj is CharacterDataEntity other && Equals(other);

        public bool Equals(CharacterDataEntity other)
        => Id.Equals(other.Id)
            && Name == other.Name
            && Type == other.Type
            && Mathf.Approximately(MovementSpeed, other.MovementSpeed)
            && Mathf.Approximately(JumpPower, other.JumpPower);
        public override int GetHashCode()
        => HashCode.Combine(Id, Name, Type, MovementSpeed, JumpPower);

        public override string ToString()
        => $"CharacterDataEnetity {{ Id = {Id},Name = {Name.ToString()}Type = {Type.ToString()},MovemmentSpeed={MovementSpeed},JumpPower={JumpPower}";
    }
}
