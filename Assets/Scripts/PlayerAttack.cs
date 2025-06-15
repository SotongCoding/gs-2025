using UnityEngine;
using SotongStudio; // Penting: untuk mengakses ITurnControl dan TurnService

public class PlayerAttack : MonoBehaviour
{
    // Referensi ke sistem kontrol giliran
    [SerializeField] private TurnService _turnService; // Drag and drop TurnService GameObject di Inspector

    // Variabel untuk kontrol satu aksi per giliran
    private int _lastTurnActed=-999; // Melacak giliran terakhir player beraksi

    private void Awake()
    {
        // Pastikan _turnService terisi
        if (_turnService == null)
        {
            _turnService = FindObjectOfType<TurnService>();
            if (_turnService == null)
            {
                Debug.LogError("TurnService not found in the scene! Please add one or assign it.");
            }
        }
        
    }

    void Update()
    {
        if (_turnService == null) return; // Jangan lakukan apa-apa jika TurnService tidak ada
        
        // Serangan Pedang (tombol X)
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Cek apakah player sudah beraksi di giliran ini
            if (_lastTurnActed == _turnService.TurnAmount)
            {
                return; // Keluar dari Update, tidak ada input yang diproses
            }
            TryAttack(AttackType.Sword);
        }

        // Serangan Sihir (tombol Y)
        if (Input.GetKeyDown(KeyCode.Y))
        {
            // Cek apakah player sudah beraksi di giliran ini
            if (_lastTurnActed == _turnService.TurnAmount)
            {
                return; // Keluar dari Update, tidak ada input yang diproses
            }
            TryAttack(AttackType.Magic);
        }
    }

    // Enum untuk tipe serangan
    private enum AttackType { Sword, Magic }

    // Metode untuk mencoba melakukan serangan
    private void TryAttack(AttackType type)
    {
        int currentTurn = _turnService.TurnAmount;

        Debug.Log($"Player attempts to attack with {type} at Turn: {currentTurn}");

        // Lakukan serangan
        if (type == AttackType.Sword) //AttackType.Sword
        {
            Debug.Log("Executing Sword Attack ");
        }
        else // AttackType.Magic
        {
            Debug.Log("Executing Magic Attack ");
        }

        // Tandai bahwa player sudah beraksi di giliran ini
        _lastTurnActed = currentTurn;
        Debug.Log($"Player has acted this turn (Turn: {currentTurn}). No more actions this turn.");
    }
    
}