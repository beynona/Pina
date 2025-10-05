using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public abstract class JoystickHandler : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    // Основные компоненты
    [SerializeField] private Image _joystickBackground;
    [SerializeField] private Image _joystick;
    [SerializeField] private Image _joystickArea;

    // Начальная позиция джостика
    private Vector2 _joystickBackgroundStartPosition;
        
    // Поле для направления движения
    protected Vector2 InputVector;
    
    // Выбор цвета джостика когда активный и когда неактивный
    [SerializeField] private Color inActiveJoystickColor;
    [SerializeField] private Color activeJoystickColor;


    private bool _joystickIsActive;

    void Start()
    {
        ClickEffect();

        _joystickBackgroundStartPosition = _joystickBackground.rectTransform.anchoredPosition;
    }
    
    // Когда мы водим пальцем или мышной по экрану
    public void OnDrag(PointerEventData eventData)
    {
        // Преобразует координаты нажатия в локальные координаты RectTransform
        // 1 параметр - RectTransform где мы и будем искать точку
        // 2 параметр - позиция щелчка мыши или нажатия
        // 3 параметр - каметра связанная с точкой экрана, если стоит overlayMode - камера не нужна
        // out - наши локальные координаты в замкнутом RectTransform
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform,eventData.position,null,out var joystickPosition))
        {
            // Для плавности передвижения джостика по всему бэкграунду
            // Данной операцией мы сводим данные координаты к отрезку -1 +1, если наш палец внутри бэкграунда
            var delta = _joystickBackground.rectTransform.sizeDelta;
            joystickPosition.x = (joystickPosition.x * 2 / delta.x);
            joystickPosition.y = (joystickPosition.y * 2 / delta.y);

            InputVector = new Vector2(joystickPosition.x, joystickPosition.y);

            // Если длина вектора больше 1, то нормализуем - приводим к единичному
            // Если меньше 1, то оставляем как есть
            InputVector = (InputVector.magnitude > 1f) ? InputVector.normalized : InputVector;

            var sizeDelta = _joystickBackground.rectTransform.sizeDelta;
            _joystick.rectTransform.anchoredPosition =
                new Vector2(InputVector.x * (sizeDelta.x / 2), InputVector.y * (sizeDelta.y / 2));
        }
    }

    // Когда мы нажимаем на экран
    public void OnPointerDown(PointerEventData eventData)
    {
        ClickEffect();

        // Перемещаем позицию бэкграунда в точку нажатия
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickArea.rectTransform, eventData.position,
                null, out var joystickBackgroundPosition))
        {
            _joystickBackground.rectTransform.anchoredPosition =
                new Vector2(joystickBackgroundPosition.x, joystickBackgroundPosition.y);
        }
    }

    // Вызывается когда мы отпускаем палец от экрана
    public void OnPointerUp(PointerEventData eventData)
    {
        // Деактивируем наш джостик и возвращаем бэкграунд в начальную позицию
        _joystickBackground.rectTransform.anchoredPosition = _joystickBackgroundStartPosition;
        
       ClickEffect();

        InputVector = Vector2.zero;
        _joystick.rectTransform.anchoredPosition = Vector2.zero;
    }

    private void ClickEffect()
    {
        if (!_joystickIsActive)
        { 
            // _joystick.color = activeJoystickColor;
            _joystickIsActive = true;
        }
        else
        {
            // _joystick.color = inActiveJoystickColor;
            _joystickIsActive = false;
        }
    }
}
