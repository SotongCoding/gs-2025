using UnityEngine;

namespace SotongStudio
{
    // Controller bertanggung jawab mengatur logika dan input
    public class QuickActionController : MonoBehaviour
    {
        public QuickActionView view; // Referensi ke View (drag dari Inspector)

        private QuickActionModel currentAction;   // Data Quick Action aktif
        private int currentIndex = 0;             // Indeks input yang sedang dicek
        private float timer = 0f;                 // Timer waktu berjalan
        private bool isActive = false;            // Apakah Quick Action sedang berlangsung
        private bool isComplete = false;          // Apakah semua arah sudah diinput

        void Update()
        {
            
            timer -= Time.deltaTime;

            // Gagal jika waktu habis
            if (isActive && timer <= 0f)
            {
                EndQuickAction(false);
            }
            // Cek input arah
            else if ( isActive && !isComplete && Input.anyKeyDown)
            {
                CheckInput();
            }
            // Setelah semua panah berhasil ditekan, tunggu space
            else if (isComplete && Input.GetKeyDown(KeyCode.Space))
            {
                EndQuickAction(true);
            }

            // [Debug] Tekan A untuk memulai Quick Action baru
            if (Input.GetKeyDown(KeyCode.A))//testing
            {
                Debug.Log("terklik");
                StartQuickAction();
            }
            
        }

        // Memulai Quick Action baru
        void StartQuickAction()
        {
            currentAction = new QuickActionModel(5f, 5); // Durasi 5 detik, 5 panah
            currentIndex = 0;
            timer = currentAction.Duration;
            isActive = true;
            isComplete = false;

            view.ShowUI();
            view.DisplayDirections(currentAction.Directions);
        }

        // Mengecek apakah input pemain sesuai dengan arah yang dibutuhkan
        void CheckInput()
        {
            if (currentIndex >= currentAction.Directions.Count) return;

            Direction expected = currentAction.Directions[currentIndex];

            if (IsCorrectInput(expected))
            {
                // Input benar → ubah warna panah jadi merah
                view.HighlightArrow(currentIndex, Color.red);
                currentIndex++;

                // Jika semua arah selesai → tunggu space
                if (currentIndex >= currentAction.Directions.Count)
                {
                    isComplete = true;
                    Debug.Log("Semua arah benar! Tekan SPACE untuk menyelesaikan.");
                }
            }
            else
            {
                // Input salah → gagal
                EndQuickAction(false);
            }
        }

        // Mengecek apakah tombol yang ditekan benar
        bool IsCorrectInput(Direction dir)
        {
            return dir switch
            {
                Direction.Up => Input.GetKeyDown(KeyCode.UpArrow),
                Direction.Down => Input.GetKeyDown(KeyCode.DownArrow),
                Direction.Left => Input.GetKeyDown(KeyCode.LeftArrow),
                Direction.Right => Input.GetKeyDown(KeyCode.RightArrow),
                _ => false
            };
        }

        // Mengakhiri Quick Action
        void EndQuickAction(bool success)
        {
            isActive = false;
            isComplete = false;
            view.HideUI();

            if (success)
                Debug.Log("Quick Action Sukses!");
            else
                Debug.Log("Quick Action Gagal!");
        }
    }
}
