using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.codes
{
    public class HidingTileStatusManager : MonoBehaviour, ITileManager
    {
        [SerializeField]
        Tilemap _tilemap;
        // Use this for initialization
        private void Start()
        {
            if (_tilemap.CompareTag("Ice"))
            {
                _tilemap.gameObject.SetActive(false);
            }
        }
        public void ChangeStatus()
        {
            _tilemap.gameObject.SetActive(!_tilemap.gameObject.activeSelf);
        }
    }
}