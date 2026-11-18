*   c39fbd7 fix: разрешен конфликт в README.md
|\  
| * 7df9ad4 feat: добавлен README.md в ветке feature/git-basics
* | eead8c2 docs: обновлен README.md в ветке main
|/  
* ba4f8ad Initial commit: добавлены файлы проекта Task
* 8dae22f Initial commit: добавлен README.md
## Задание №46. Git Stash

### 1. Список stash до демонстрации

stash@{0}: On feature/rebase-demo: safety: save project changes before task 46

### 2. Список stash после сохранения README.md

stash@{0}: On feature/rebase-demo: task 46: save README changes
stash@{1}: On feature/rebase-demo: safety: save project changes before task 46

### 3. Список stash после восстановления README.md

stash@{0}: On feature/rebase-demo: safety: save project changes before task 46

### Результат

Изменения README.md были сохранены командой git stash, затем выполнено переключение на main и обратно на feature/rebase-demo. Команда git stash pop успешно восстановила изменения README.md и удалила демонстрационную запись из stash.
Задание №47. Git Rebase -i (Squash)
История до объединения
ce899eb (HEAD -> feature/squash-demo) docs: combine four squash demo commits
2424e20 docs: добавлен граф коммитов в git-notes.md
c39fbd7 fix: разрешен конфликт в README.md
eead8c2 docs: обновлен README.md в ветке main

История после объединения
6c31882 (HEAD -> feature/squash-demo) docs: combine four squash demo commits
70c39a8 (feature/rebase-demo) docs: save git log after rebase
7a65b4a docs: add rebase demo file
23035a6 (origin/main, origin/HEAD, main) Merge pull request #1 from hIknowaru/feature/task-35

Результат
Четыре коммита успешно объединены в один с помощью git rebase -i HEAD~4 и команды squash.
## Задание №48. Git: аннотированные теги

### Создание тега
Создан аннотированный тег v1.0.0 с сообщением "Release v1.0.0".

### Проверка
Команда git tag показала:
v1.0.0

Команда git show v1.0.0 подтвердила:
- Тег: v1.0.0
- Сообщение: Release v1.0.0
- Тег указывает на стабильный коммит main: 386ff99.

### Отправка на GitHub
Выполнена команда git push origin v1.0.0.

Проверка git ls-remote --tags origin v1.0.0 подтвердила наличие тега в удалённом репозитории.
## Задание №49. Восстановление коммита через reflog

### 1. Создание тестового коммита
Создан файл reflog-demo.txt.

Команда:
git commit -m "test: add reflog recovery demo"

Хеш коммита: 1a7e852

### 2. Удаление коммита
Выполнена команда:
git reset --hard HEAD~1

### 3. Поиск коммита
Выполнена команда:
git reflog

Удалённый коммит найден в истории reflog:
1a7e852

### 4. Восстановление
Выполнена команда:
git reset --hard 1a7e852

### 5. Проверка
Выполнены команды:
git log --oneline -1
git status
git reflog

Коммит успешно восстановлен. Файл reflog-demo.txt возвращён.
Рабочая папка чистая.
Задание 50. Поиск ошибки с помощью git bisect
Цель: найти коммит, в котором появилась ошибка, используя команду git bisect.
Выполнение:
Создана отдельная ветка feature/bisect-demo.
Создан файл BisectDemo.cs с рабочей функцией AddTwo, которая прибавляет 2 к числу.
Созданы промежуточные коммиты.
В коммите 5903c41 намеренно допущена ошибка: number + 2 заменено на number - 2.
Созданы последующие контрольные коммиты.
Запущен поиск:
git bisect start
git bisect bad
git bisect good 0582bd2
Проверяемые версии отмечались командами git bisect good и git bisect bad.
После поиска Git определил первый плохой коммит.
Результат:
Найден первый плохой коммит: 5903c41 — bug: break AddTwo calculation.
Git вывел сообщение:
5903c41d4aeefd591be8b94b1ba622ba97fb6736 is the first 'bad' commit.
Журнал поиска: git bisect log.
Завершение: выполнена команда git bisect reset, возвращающая HEAD к последнему коммиту исходной ветки поиска.
Вывод: с помощью бинарного поиска Git удалось определить коммит, в котором появилась ошибка, не проверяя вручную каждый коммит.