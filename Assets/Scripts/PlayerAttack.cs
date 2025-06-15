using UnityEngine;
using SotongStudio; // Penting: untuk mengakses ITurnControl dan TurnService

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private TurnService _turnService; 
    private int _lastTurnActed=-999; 
    
    // Untuk deteksi tahan tombol magic
    private float _magicHoldTime = 0f;
    private float _requiredHoldDuration = 1f; 
    private bool _isHoldingMagic = false;
    

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

        // Magic Attack (Y) – tahan tombol
        if (Input.GetKeyDown(KeyCode.Y))
        {
            _magicHoldTime = 0f;
            _isHoldingMagic = true;
        }

        if (Input.GetKey(KeyCode.Y) && _isHoldingMagic)
        {
            _magicHoldTime += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Y) && _isHoldingMagic)
        {
            _isHoldingMagic = false;

            if (_lastTurnActed == _turnService.TurnAmount)
            {
                return;
            }

            if (_magicHoldTime >= _requiredHoldDuration)
            {
                TryAttack(AttackType.Magic);
            }
            else
            {
                Debug.Log("Magic attack canceled: hold duration too short.");
            }
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