using VContainer;

namespace SotongStudio.SharedData.PlayerCollection
{
    public static class PlayerCollectionBuilder
    {
        public static void RegisterPlayerCollection(this IContainerBuilder builder)
        {
            builder.Register<PlayerInfoPlayerCollection>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
