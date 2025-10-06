using UnityEngine;

namespace ShivanceGames.ISerializer.Sample
{
    public class Dog : MonoBehaviour, IPet
    {
        public void Run()
        {
            Debug.Log("[Dog] Running.......");
        }
    }
}