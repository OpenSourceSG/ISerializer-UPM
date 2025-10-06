using UnityEngine;

namespace ShivanceGames.ISerializer.Sample
{
    public class Cat : MonoBehaviour, IPet
    {
        public void Run()
        {
            Debug.Log("[Cat] Running.....");
        }
    }
}