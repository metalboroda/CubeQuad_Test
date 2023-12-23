using UnityEngine;
using Zenject;

namespace CubeQuad
{
  public class ControllerInstaller : MonoInstaller
  {
    [SerializeField] private GameController _gameController;
    [SerializeField] private SceneController _sceneController;

    public override void InstallBindings()
    {
      Container.Bind<GameController>().FromInstance(_gameController).AsSingle();
      Container.Bind<SceneController>().FromInstance(_sceneController).AsSingle();
    }
  }
}