using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellAction : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler
{
    private enum CellType
    {
        Empty,
        X,
        O
    }
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite xSprite;
    [SerializeField] private Sprite oSprite;
    private CellType _cellType = CellType.Empty;
    public int CellTypeValue => (int) _cellType;
    private Image _image;
    private GameManager _gameManager;
    private void Awake()
    {
        _image = GetComponent<Image>();
        _gameManager = FindObjectOfType<GameManager>();
        _image.color = Color.white;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_gameManager.IsGameOver)
            return;
        _image.color = _cellType == CellType.Empty ? Color.green : Color.red;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_gameManager.IsGameOver)
            return;
        
        _image.color = Color.white;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (_gameManager.IsGameOver  || _cellType != CellType.Empty)
            return;
        _cellType = _gameManager.CurrentPlayer == 0 ? CellType.X : CellType.O;
        _image.sprite = _cellType == CellType.X ? xSprite : oSprite;
        _gameManager.EndTurn();
    }
    public void ResetCell()
    {
        _cellType = CellType.Empty;
        _image = GetComponent<Image>();
        _image.sprite = defaultSprite;
    }
    
}
