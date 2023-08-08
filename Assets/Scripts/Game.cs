using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public Transform[] pinPositions; // Массив позиций для пинов
    public Transform[] buttonPositions; // Массив позиций для кнопок
    public GameObject[] pins; // Массив пинов
    public GameObject[] buttons; // Массив кнопок
    public float pinSpeed = 5f; // Скорость движения пинов
    public float buttonSpeed = 5f; // Скорость движения кнопок
    public float hackTime = 10f; // Время для взлома замка

    private bool isHacking = false; // Флаг для проверки, идет ли взлом
    private float currentTime = 0f; // Текущее время взлома

    private bool[] isPinMoving; // Флаги для пинов, указывающие на то, идет ли движение пина
    private bool[] isButtonMoving; // Флаги для кнопок, указывающие на то, идет ли движение кнопки

    // Инициализация
    void Start()
    {
        isPinMoving = new bool[pins.Length];
        isButtonMoving = new bool[buttons.Length];
        for (int i = 0; i < pins.Length; i++)
        {
            isPinMoving[i] = false;
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            isButtonMoving[i] = false;
        }
    }

    // Проверка условия победы
    bool CheckWinCondition()
    {
        for (int i = 0; i < pins.Length; i++)
        {
            if (pins[i].transform.position != pinPositions[i].position)
            {
                return false;
            }
        }
        return true;
    }

    // Обработка нажатий кнопок
    void Update()
    {
        if (!isHacking)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StartCoroutine(MovePin(0, 0));
            }
            else if (Input.GetKeyUp(KeyCode.Alpha1))
            {
                StopCoroutine(MovePin(0, 0));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                StartCoroutine(MovePin(1, 1));
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                StopCoroutine(MovePin(1, 1));
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                StartCoroutine(MovePin(2, 2));
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                StopCoroutine(MovePin(2, 2));
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isHacking)
        {
            isHacking = true;
            StartCoroutine(HackLock());
        }
    }

    // Корутина для движения пина
    IEnumerator MovePin(int index, int buttonIndex)
    {
        isButtonMoving[buttonIndex] = true;
        float moveDistance = pinSpeed * Time.deltaTime;

        while (true)
        {
            if (isButtonMoving[buttonIndex])
            {
                pins[index].transform.Translate(Vector3.up * moveDistance);

                if (pins[index].transform.position.y >= pinPositions[index].position.y)
                {
                    pins[index].transform.position = pinPositions[index].position;
                    isPinMoving[index] = false;
                    isButtonMoving[buttonIndex] = false;
                    yield break;
                }
            }
            else
            {
                isPinMoving[index] = false;
                yield break;
            }
            yield return null;
        }
    }

    // Корутина для взлома замка
    IEnumerator HackLock()
    {
        while (currentTime < hackTime)
        {
            if (!isHacking)
            {
                yield break;
            }

            currentTime += Time.deltaTime;

            if (CheckWinCondition())
            {
                Debug.Log("Замок взломан!");
                yield break;
            }

            yield return null;
        }

        if (!CheckWinCondition())
        {
            Debug.Log("Время истекло, замок не взломан!");
        }
    }
}