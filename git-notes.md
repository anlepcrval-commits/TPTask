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