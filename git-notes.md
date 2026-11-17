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