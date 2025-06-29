using Zenject;
using _Project.Logic.Shared.Spawner;

namespace _Project.Configs.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        // ReSharper disable Unity.PerformanceAnalysis
        public override void InstallBindings()
        {
            Container.Bind<ISpawner>().To<Spawner>().AsSingle();
        }
    }
}