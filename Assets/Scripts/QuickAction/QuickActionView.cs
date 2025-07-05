using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SotongStudio
{
    // View bertanggung jawab untuk menampilkan UI Quick Action
    public class QuickActionView : MonoBehaviour
    {
        [Header("UI References")]
        public Transform uiContainer;              // Tempat meletakkan panah
        public GameObject quickActionUI;           // Panel Quick Action

        [Header("Arrow Prefabs")]
        public GameObject arrowUpPrefab;
        public GameObject arrowDownPrefab;
        public GameObject arrowLeftPrefab;
        public GameObject arrowRightPrefab;

        private List<GameObject> activeArrows = new(); // List panah aktif

        // Menampilkan panel UI
        public void ShowUI()
        {
            quickActionUI.SetActive(true);
        }

        // Menyembunyikan panel UI
        public void HideUI()
        {
            quickActionUI.SetActive(false);
        }

        // Menampilkan panah sesuai urutan arah
        public void DisplayDirections(List<Direction> directions)
        {
            // Bersihkan panah lama
            foreach (Transform child in uiContainer)
                Destroy(child.gameObject);

            activeArrows.Clear();

            // Instantiate panah baru dan simpan
            foreach (Direction dir in directions)
            {
                GameObject prefab = GetArrowPrefab(dir);
                if (prefab != null)
                {
                    GameObject arrow = Instantiate(prefab, uiContainer);
                    activeArrows.Add(arrow);
                }
            }
        }

        // Mengubah warna panah tertentu
        public void HighlightArrow(int index, Color color)
        {
            if (index < activeArrows.Count)
            {
                Image img = activeArrows[index].GetComponent<Image>();
                if (img != null)
                    img.color = color;
            }
        }

        // Mengembalikan prefab sesuai arah
        private GameObject GetArrowPrefab(Direction dir)
        {
            return dir switch
            {
                Direction.Up => arrowUpPrefab,
                Direction.Down => arrowDownPrefab,
                Direction.Left => arrowLeftPrefab,
                Direction.Right => arrowRightPrefab,
                _ => null,
            };
        }
    }
}
