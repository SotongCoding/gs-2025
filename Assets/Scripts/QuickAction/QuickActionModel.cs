using System.Collections.Generic;

namespace SotongStudio
{
    // Enum arah untuk input panah
    public enum Direction { Up, Down, Left, Right }

    // Model menyimpan data logika Quick Action
    public class QuickActionModel
    {
        public float Duration { get; set; }             // Durasi total Quick Action
        public int ButtonAmount { get; set; }           // Jumlah input yang dibutuhkan
        public List<Direction> Directions { get; private set; } // Arah input yang dibutuhkan

        // Konstruktor, generate input arah secara acak
        public QuickActionModel(float duration, int buttonAmount)
        {
            Duration = duration;
            ButtonAmount = buttonAmount;
            Directions = new List<Direction>();

            // Generate arah random
            for (int i = 0; i < ButtonAmount; i++)
            {
                Direction randomDir = (Direction)UnityEngine.Random.Range(0, 4);
                Directions.Add(randomDir);
            }
        }
    }
}