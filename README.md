# AnimArch
Repozitár tímu ArchMages19.
## GitHub metodika
Pravidlá práce s GitHub:  
1. V prípade, že člen tímu chce spraviť merge do upstream/master musí vytvoriť pull request, ktorý musí nechať skontrolovať iným členom tímu

2. Commit musí obsahovať správu, ktorá jasne vyjadruje zmysel daného commitu a čo sa zmení po aplikovaní daného commitu [Návod](https://chris.beams.io/posts/git-commit/)

3. Master vetva v lokalnom repozitári, by mala byť vždy zhodná s upstream/master vetvou

## GitHub príkazi
Pristup do vzdialených repozitárov:
```
git remote -v                                   - zobrazí názvi a url adresi vzdialených repozitárov
git remote add <name_of_remote> <url_of_remote> - pridá prepojenie vzdialeného repozitára s menom <name_of_remote> pod url adresov <url_of_remote>
git remote remove <name_of_remote>              - zmazé prepojenie vzdialeného repozitára s menom <name_of_remote>
git clone <repo_url>                            - stiahne všetko zo vzdialeného repozitára s url <repo_url> do lokálneho repozitára
```
Správa vetiev:
```
git branch                    - zobrazí lokálne vetvi
git branch -a                 - zobrazí všetky vetvi
git branch -D <branch_name>   - odstráni vetvu s menom <branch_name>
git checkout <branch_name>    - aktivuje vetvu s menom <branch_name>
git checkout -b <branch_name> - vytvori novu vetvu s menom <branch_name> a aktivuje ju
```
Správa localného repozitára:
```
git status                             - zobrazí aktuálny stav lokalného repozitára oproti origin (viac info)
git checkout                           - zobrazí aktuálny stav lokalného repozitára oproti origin
git diff                               - zobrazi rozdieli lokalného repozitára oproti origin
git diff <branch_name>                 - zobrazi rozdieli lokalného repozitára oproti vetve s menom <branch_name>
git diff <branch_name1> <branch_name2> - zobrazi rozdieli vetvi s menom <branch_name1> s vetvom s menomn <branch_name2>
```
Správou kódu lokálneho repozitára:
```
git add <file_path>              - pridá subor do listu, ktoré budú commitnuté
git restore --staged <file_path> - odstráni súbor z listu, ktoré majú byť commitnuté
git checkout <file_path>         - obnový súbor do pôvodného stavu
git commit -m "<message>"        - commitne súbory, ktoré sa nachádzaju v liste súborov, ktoré sa maju commitnúť, commit bude obsahovať správu <message>
git push                         - posle aktuálnu vetvu do tej istej vetvi, ale vo vdialenóm repozitáre
git push -u origin <branch_name> - vytvorí novú vetvu vo vzdialenom repozitári s menon <branch_name> a posle tam aktuálnu vetvu
git pull                         - stiahne aktuálnu vetvu zo vzdialeného repozitára
git pull <branch_name>           - stiahne vetvu s menom <branch_name> zo vzdialeného repozitára
git stash                        - uloži zmeny do stash
git stash pop                    - vyberie posledné užené znemy zo stash a aplikuje ich
```

## GitHub príklady
Stiahnutie najnovšiej verzie kódu, upravenie kódu, aktualizovanie vzdialeného repozitára a vyžiadanie pull requestu.
```
git checkout master
git pull upstream/master
git checkout -b <feature/meno_novej_feature>
"Vykonanie zmien v kóde + pridanie nového súboru
git add --all
git commit -m "<Správa ktorá vyjadruje čo daný commit zmení v kóde>"
git push -u origin <feature/meno_novej_feature>
"Vytvorenie pull requestu na GitHub stránke, pre vetvu <feature/meno_novej_feature>"
```
