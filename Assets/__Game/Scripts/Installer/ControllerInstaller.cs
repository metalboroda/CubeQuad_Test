using UnityEngine;
using Zenject;

namespace CubeQuad
{
  public class ControllerInstaller : MonoInstaller
  {
    [SerializeField] private GameController _gameController;
    [SerializeField] private LevelController _sceneController;
    [SerializeField] private PlayerPrefsController _playerPrefsController;

    public override void InstallBindings()
    {
      Container.Bind<GameController>().FromInstance(_gameController).AsSingle();
      Container.Bind<LevelController>().FromInstance(_sceneController).AsSingle();
      Container.Bind<PlayerPrefsController>().FromInstance(_playerPrefsController).AsSingle();
    }
  }
}