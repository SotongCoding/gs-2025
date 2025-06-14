using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public class GameplaySceneScope : SceneScope
    {
        [SerializeField]
        private TurnService _turnService;

        protected override void AddRegistration(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayController>(Lifetime.Singleton);
            builder.RegisterInstance(_turnService).As<ITurnControl>();
        }
    }
}
