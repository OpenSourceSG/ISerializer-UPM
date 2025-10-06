using UnityEngine;
using Object = UnityEngine.Object;

namespace ShivanceGames.ISerializer.Sample
{
    public class Trainer : MonoBehaviour
    {
        [ISerialize(typeof(IPet))] [Tooltip("Assign Using Dropdown")]
        public Object Pet;
        private IPet _pet => Pet as IPet;

        private void Start()
        {
            if (_pet == null)
            {
                Debug.LogError($"{nameof(Trainer)} requires a {nameof(IPet)}");
                return;
            }

            _pet.Run();
        }
    }
}