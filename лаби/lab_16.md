**Практична робота №16  
Автоматизоване тестування**

Виконали: Радченко Дамір, Дуліпа Максим, Дідіцький Максим

Проєкт: двовимірна аркадна гра на Unity (C#)

Мета: підготувати автоматизовані перевірки логіки гри.

## 1. Підхід

Для Unity 2019.1.12f1 можна використати Unity Test Runner і NUnit. Тести нижче є прикладом окремого тестового класу; код гри не змінено, тестовий файл не додано до репозиторію.

## 2. Приклад тестів (C#)

using NUnit.Framework;

using UnityEngine;

using UnityEngine.UI;

public class LogicTests {

\[TestCase(0, 1, 1)\]

\[TestCase(5, 2, 7)\]

\[TestCase(5, 0, 5)\]

\[TestCase(0, -1, -1)\]

public void Score(int start, int delta, int expected) {

var go = new GameObject();

var ui = new GameObject("Score", typeof(RectTransform), typeof(CanvasRenderer), typeof(Text));

try {

var logic = go.AddComponent\<LogicScript\>();

logic.scoreText = ui.GetComponent\<Text\>();

logic.playerScore = start;

logic.addScore(delta);

Assert.AreEqual(expected, logic.playerScore);

Assert.AreEqual(expected.ToString(), logic.scoreText.text);

} finally {

Object.DestroyImmediate(ui);

Object.DestroyImmediate(go);

}

}

}

## 3. Аналіз

Чотири параметризовані сценарії перевіряють збільшення рахунку, нульову зміну та негативне значення. Останній демонструє, що addScore не обмежує від’ємний рахунок. Для запуску потрібно налаштувати тестову збірку з доступом до LogicScript і Unity UI. Результат виконання не підтверджено.

## Висновок

Підготовлено чотири автоматизовані сценарії без зміни вихідного коду. Запуск тестів потребує Unity.
