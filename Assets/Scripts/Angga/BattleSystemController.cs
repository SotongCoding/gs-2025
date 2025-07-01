using System.Collections;
using UnityEngine;

namespace SotongStudio
{
    public class BattleSystemController : MonoBehaviour
    {
        [SerializeField] private BattleSystemView _view;
        [SerializeField] private SeedButton _seed;
        private bool _isQTAOn;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _seed.OnButtonPressed += SeedSelected;

            _isQTAOn = false;
            
            _view.SetupBattle();
        }

        private void OnDestroy()
        {
            _seed.OnButtonPressed -= SeedSelected;
        }

        // Update is called once per frame
        void Update()
        {
            if (_isQTAOn)
            {
                QTACheck();
            }
        }

        public void FightButtonPressed()
        {
            _view.StartBattle();
            _view.SetQTA();
            _isQTAOn = true;
        }

        private void SeedSelected()
        {
            _view.SeedSelected();
        }

        private void QTACheck()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log("Player berhasil menyerang");
                StartCoroutine(EnemyTurn());
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Player gagal menyerang");
                StartCoroutine(EnemyTurn());
            }
        }

        IEnumerator EnemyTurn()
        {
            _isQTAOn = false;
            _view.EnemyTurn();
            yield return new WaitForSeconds(1f);
            _view.SetQTA();
            _isQTAOn = true;
        }
    }
}
