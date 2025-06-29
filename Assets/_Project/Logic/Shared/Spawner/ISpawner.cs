using UnityEngine;

namespace _Project.Logic.Shared.Spawner
{
    public interface ISpawner
    {
        /// <summary>
        /// Instantiates the given spawnable prefab at the position of the specified spawn point,
        /// using the identity rotation.
        /// </summary>
        /// <typeparam name="T">
        /// The type of the spawnable, which must be a MonoBehaviour and implement ISpawnable.
        /// </typeparam>
        /// <param name="spawnable">
        /// The prefab instance to spawn.
        /// </param>
        /// <param name="spawnPoint">
        /// The Transform whose position will be used as the spawn location.
        /// </param>
        void Spawn<T>(T spawnable, Transform spawnPoint) where T : MonoBehaviour, ISpawnable;
    }
}