﻿using UnityEngine;
using Utils;

namespace Managers
{
    [RequireComponent(typeof(GameObjectsManager))]
    [RequireComponent(typeof(InputManager))]
    [RequireComponent(typeof(TargetingManager))]
    [RequireComponent(typeof(InteractionManager))]
    public class GameManager : MonoBehaviour, IInitilizable, IUnInitializeble
    {
        // static instance of GameManager which allows it to be accessed by any other script
        public static GameManager Instance;

        public GameObjectsManager GameObjectsManager => this.gameObject.GetComponent<GameObjectsManager>();
        public InputManager InputManager => this.gameObject.GetComponent<InputManager>();
        public TargetingManager TargetingManager => this.gameObject.GetComponent<TargetingManager>();
        public InteractionManager InteractionManager => this.gameObject.GetComponent<InteractionManager>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                if (Instance != this)
                {
                    // this enforces our singleton pattern, meaning there can only ever be one instance of a GameManager
                    Destroy(gameObject);
                }
            }

            Initialize();
        }
        private void OnDestroy()
        {
            UnInitialize();
        }

        public void Initialize()
        {
            GameObjectsManager.Initialize();
            InteractionManager.Initialize();
        }
        public void UnInitialize()
        {
            InteractionManager.UnInitialize();
            GameObjectsManager.UnInitialize();
        }
    }
}
