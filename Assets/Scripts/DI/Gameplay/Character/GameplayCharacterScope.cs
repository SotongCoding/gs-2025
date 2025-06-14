using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace SotongStudio
{
    public class GameplayCharacterScope : ScopeInstallHelper
    {
        public override void Install(IContainerBuilder builder)
        {

            builder.Register<PlayerCharacter>(Lifetime.Singleton)
                   .As<IPlayerCharacter>();
            builder.Register<CharacterActionController>(Lifetime.Singleton).As<ICharacterActionControl>();
        }
    }
}
