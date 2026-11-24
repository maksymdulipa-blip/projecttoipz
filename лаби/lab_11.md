**Практична робота №11  
Архітектура та структура програмного проєкту**

Виконали: Радченко Дамір, Дуліпа Максим, Дідіцький Максим

Проєкт: двовимірна аркадна гра на Unity (C#)

Мета: визначити компоненти гри та їх взаємодію.

## 1. Структура

Assets/ — сценарії C#, зображення, звуки та Pipe.prefab.

Assets/Scenes/ — MainMenu.unity і SampleScene.unity.

Packages/ — залежності Unity; ProjectSettings/ — налаштування. Library/ та obj/ — згенеровані файли.

## 2. Компоненти

| Клас               | Відповідальність                       |
|--------------------|----------------------------------------|
| BirdScript         | Рух автомобіля, межі камери, зіткнення |
| LogicScript        | Рахунок, Game Over, перезапуск         |
| MainMenu           | Старт гри та вихід                     |
| PauseMenuScript    | Пауза, продовження, меню               |
| PipeSpawnerScript  | Створення перешкод                     |
| PipeMoveScript     | Рух і видалення перешкод               |
| PipeMiddleScript   | Очки за прохід                         |
| AudioManagerScript | Музика та ефекти                       |

## 3. Архітектурна схема

MainMenu → SampleScene

BirdScript → Rigidbody2D → рух автомобіля

PipeSpawnerScript → Pipe.prefab → PipeMoveScript

BirdScript → LogicScript → Game Over

PipeMiddleScript → LogicScript → текст рахунку

BirdScript / PipeMiddleScript → AudioManagerScript

PauseMenuScript → Time.timeScale / SceneManager

## 4. Обґрунтування

Компонентна архітектура Unity дозволяє окремо змінювати рух, інтерфейс та звук. Сцени відокремлюють меню від ігрового процесу. Префаб дає змогу багаторазово створювати однакові перешкоди.

## Висновок

Визначено фактичну структуру проєкту та зв’язки між його компонентами.
