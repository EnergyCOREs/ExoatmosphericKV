using UnityEngine;
using Zenject;

public class MainCameraInstaller : MonoInstaller
{

    [SerializeField]
    private EKV_Camera _mainCamera;

    public override void InstallBindings()
    {
        Container
            .Bind<EKV_Camera>()
            .FromInstance(_mainCamera)
            .AsSingle()
            .NonLazy();
    }
}