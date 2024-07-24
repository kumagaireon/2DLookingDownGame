using TopDownGame.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace TopDownGame.Common.Application
{
/*    [CreateAssetMenu(fileName = "character_master_data_table",
            menuName = "TopDownGame/Master Data/aaaaa Master Data")]*/
    /*public class CharacterMasterDataTable : ScriptableObject
    {
        [Serializable]
        public struct aaaaa
        {
            public string Name;
            public CharacterType Type;
            public float MovementSpeed;
            public float JumpPower;
        }
        [SerializeField] List<aaaaa> characters;

        public List<aaaaa> Characters => characters;
    }

    [CustomEditor(typeof(CharacterMasterDataTable))]
    class CharacterMasterDataTableEditor : Editor
    {
        static readonly string path
            = System.IO.Path.Combine(UnityEngine.Application.streamingAssetsPath,
                "character_data.bin");
     */
    /*   public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Gererate MasterData"))
            {
                var dataTable = target as CharacterMasterDataTable;

                var characters = dataTable.Characters.Select(x =>
                new CharacterDataEntity(Guid.NewGuid(),
                x.Name, x.CharacterType, x.MovementSpeed, x.JumpPower)).ToList();

                IDataStore<ICharacterDataEntity> dataStore
                    = new BinaryDataStore<ICharacterDataEntity>(path);

                characters.ForEach(x => dataStore.Store(x, autoStore: false));
                dataStore.Store(null, autoStore: true);
            }

            if (GUILayout.Button("Show MasterData"))
            {
                var dataTable = target as CharacterMasterDataTable;
                IDataStore<ICharacterDataEntity> dataStore
                    = new BinaryDataStore<ICharacterDataEntity>(path);

                dataStore.Load();
                dataStore.Entites.ForEach(Debug.Log);
            }
        }*//*
    }*/
}