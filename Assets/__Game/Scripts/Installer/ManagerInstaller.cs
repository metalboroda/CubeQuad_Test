using UnityEngine;
using Zenject;

namespace CubeQuad
{
  public class ManagerInstaller : MonoInstaller
  {
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private UIManager _uiManager;

    public override void InstallBindings()
    {
      Container.Bind<InputManager>().FromInstance(_inputManager).AsSingle();
      Container.Bind<UIManager>().FromInstance(_uiManager).AsSingle();
    }
  }
}