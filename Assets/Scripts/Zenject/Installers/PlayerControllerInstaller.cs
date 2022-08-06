using UnityEngine;
using Zenject;

public class PlayerControllerInstaller : MonoInstaller
{

    [SerializeField]
    private EKV_PlayerController _playerController;

    public override void InstallBindings()
    {
        Container
            .Bind<EKV_PlayerController>()
            .FromInstance(_playerController)
            .AsSingle()
            .NonLazy();
    }
}