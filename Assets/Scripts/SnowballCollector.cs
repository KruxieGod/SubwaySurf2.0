using UnityEngine;
public class SnowballCollector : MonoBehaviour
{
    [SerializeField] private CounterSnowballsUI _counterSnowballsUI;
    [SerializeField] private int _countSnowballs = 5;
    private int _lastSnowballs = 0;

    public bool CanThrow()
        => _lastSnowballs - 1 >= 0;

    public void Throw()
    {
        _lastSnowballs--;
        _counterSnowballsUI.CountSnowballsText.SetText(_lastSnowballs.ToString());
    }

    private void AddThrow(ObstacleType type,GameObject gameObj) // добавить бросок
    {
        if (type != ObstacleType.Snowball)  // проверяем на то , снежок ли это 
            return;
        if (_lastSnowballs < _countSnowballs) // если кол-во собранных снежков меньше дозволенного кол-ва , то мы объект при столкновении отрубаем
            gameObj.SetActive(false);
        _lastSnowballs = Mathf.Clamp( ++_lastSnowballs,0, _countSnowballs); // ограничиваем
        _counterSnowballsUI.CountSnowballsText.SetText(_lastSnowballs.ToString()); // ставим текст на интерфейс
    }

    private void Awake()
    {
        _counterSnowballsUI.CountSnowballsText.SetText(_lastSnowballs.ToString()); // спавнится коллектор на нащем игроке и мы ставим на интерфесе 0
        var collider = GetComponent<Collider>();
        if (!DataColliders.OnObstacleActions.ContainsKey(collider)) // проверяем есть ли коллайдер
            DataColliders.OnObstacleActions.Add(collider, AddThrow); // добавляем метод при столкновении
        else
            DataColliders.OnObstacleActions[collider] += AddThrow; // добавляем метод при столкновении
    }
}