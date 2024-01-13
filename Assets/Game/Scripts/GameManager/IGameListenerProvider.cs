using System.Collections.Generic;

namespace ZombieShooter
{
    public interface IGameListenerProvider
    {
        IEnumerable<IGameListener> ProvideListeners();
    }
}