using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityUtils;

namespace Systems.Persistence {
    [Serializable] 
    public class GameData { 
        public string Name;
        public PlayerData playerData;
    }
        
    public interface ISaveable  {
        SerializableGuid Id { get; set; }
    }
    
    public interface IBind<TData> where TData : ISaveable {
        SerializableGuid Id { get; set; }
        void Bind(TData data);
    }
    
    public class SaveLoadSystem : PersistentSingleton<SaveLoadSystem> {
        const string FILE_NAME = "game_data";
        
        [SerializeField] public GameData gameData;

        IDataService dataService;

        protected override void Awake() {
            base.Awake();
            dataService = new FileDataService(new JsonSerializer());
            LoadGame(FILE_NAME);
            Bind<HqController, PlayerData>(gameData.playerData);
        }

        
        void Start() => NewGame();

        void OnEnable() => SceneManager.sceneLoaded += OnSceneLoaded;
        void OnDisable() => SceneManager.sceneLoaded -= OnSceneLoaded;
        
        void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
            if (scene.name == "Menu") return;
            
            Bind<HqController, PlayerData>(gameData.playerData);
        }
        
        void Bind<T, TData>(TData data) where T : MonoBehaviour, IBind<TData> where TData : ISaveable, new() {
            var entity = FindObjectsByType<T>(FindObjectsSortMode.None).FirstOrDefault();
            if (entity != null) {
                if (data == null) {
                    data = new TData { Id = entity.Id };
                }
                entity.Bind(data);
            }
        }

        void Bind<T, TData>(List<TData> datas) where T: MonoBehaviour, IBind<TData> where TData : ISaveable, new() {
            var entities = FindObjectsByType<T>(FindObjectsSortMode.None);

            foreach(var entity in entities) {
                var data = datas.FirstOrDefault(d=> d.Id == entity.Id);
                if (data == null) {
                    data = new TData { Id = entity.Id };
                    datas.Add(data); 
                }
                entity.Bind(data);
            }
        }

        public void NewGame(string gameName = FILE_NAME) {
            PlayerData playerData = new PlayerData();
            playerData.LoadBaseStats();

            gameData = new GameData {
                Name = gameName,
                playerData = playerData
            };
        }
        
        public void SaveGame() {
            Debug.Log(gameData.playerData.GetStatUpgradeTimes(StatType.Health));
            dataService.Save(gameData);
        }

        public void LoadGame(string gameName) {
            gameData = dataService.Load(gameName);

            if (gameData == null) {
                Debug.Log($"Load '{gameName}' failed, create new game.");
                NewGame();
                return;
            }
        }
        
        public void ReloadGame() => LoadGame(gameData.Name);

        public void DeleteGame(string gameName) => dataService.Delete(gameName);
    }
}