using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.codes
{
    public class TileStatusManager : MonoBehaviour, ITileManager
    {
        [SerializeField]
        Tilemap _tilemap;
        Tilemap _tilemap2;
        [SerializeField]
        TileBase _invertedTile;
        private bool _isPhase0 = true;
        // Use this for initialization
        void Start()
        {
            _tilemap2 = Instantiate(_tilemap, transform);
            if (_tilemap.CompareTag("Fire"))
            {
                _tilemap2.tag = "Ice";
            }
            else _tilemap2.tag = "Fire";
            foreach (var pos in _tilemap.cellBounds.allPositionsWithin)
            {
                var tileBase = _tilemap.GetTile(pos);
                if (tileBase != null)
                {
                    _tilemap2.SetTile(pos, _invertedTile);
                }
            }
            _tilemap2.gameObject.SetActive(false);
        }
        public void ChangeStatus()
        {
            _isPhase0 = !_isPhase0;
            _tilemap.gameObject.SetActive(_isPhase0);
            _tilemap2.gameObject.SetActive(!_isPhase0);
        }
    }
}