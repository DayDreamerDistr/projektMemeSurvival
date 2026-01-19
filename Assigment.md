#### Cíl výsledné hry

* Player se hýbe pomocí WASD.
* Enemies se spawnují průběžně a běží na Player.
* Enemy ubírá Playerovi HP + dává knockback.
* Player míří zbraní myší a střílí bullets.
* Bullet ubírá enemy HP, enemy krátce blikne červeně (shader).
* Skóre roste za zabité enemy.
* Po smrti Playera se ukáže Game Over menu + tlačítko Try Again.



#### Pojmy

* Editor = Godot
* Node = jednotlivý objekt v tvém projektu (characterbody, sprite, collisionshape…)
* scéna = ukládáš je jako soubory, obvykle více Nodes s nějakou extra logikou a setnutými parametry (Player, BasicEnemy, World…)





## Úkoly

##### Úkol #0 - Input mapping, ověření funkcionality

* Ověř, že všechno co doposud máme funguje
* namapuj hráči Input pro pohyb všemi směry - nezapomeň upravit akce ve skriptu



##### Úkol #1 - HP a damage hráči

* momentálně se Enemies lepí na hráče, ale nic mu nedělají. To hned změníme.
* Ve skriptu hráče přidej proměnné:
* Typu int pro Health, rovnou nastav startovní hodnotu
* Typu bool pro IsDead, indikace jestli je hráč ještě aktivní nebo mrtvý



* Je potřeba metoda co se bude volat když si má hráč ubrat životy - Přidej metodu TakeDamage s 1 vstupním parametrem, který bude určovat množství damage
* přidej do metody snížení HP
* nenechá HP spadnout pod 0 - jednoduchý if



* Chceme aby hráč viděl kolik má HP - V editoru do Player scény přidej Label
* Umísti ho tak, aby byl vidět (pro test klidně nad/pod postavu)
* Jelikož je to child node playera, bude se hýbat společně s ním
* Pro přehlednost se hodí si label nějak pojmenovat (třeba HPLabel)
* Napoj label ve skriptu
* Přidej do metody TakeDamage aktualizaci textu s HP (vlastnost labelu Text)



* Nápověda:
* Label můžeš napojit do kódu přes \[Export] (přiřadíš v editoru)



##### Úkol #2 - BasicEnemy útočí

* Hráč má připravenou metodu TakeDamage, ale nikdy se nevolá
* V BasicEnemy Scéně:
* Přidej child node Area2D a pojmenuj třeba Hitbox
* Pod Hitbox přidej CollisionShape2D
* Nastav shape tak, aby dával smysl
* Nastav v properties Hitboxu v odrážce "Collision" Layer a Mask (nápověda v README, sekce Collision) 
* Připoj signal body\_entered z Hitbox do enemy skriptu
* Vytvoř metodu se jménem signálu (private void stačí), nezapomeň na vstupní parametr (lze najít v editoru u signálu)
* udělej podmínku, že body je Player - nechceme útočit na ostatní enemies
* zavolej hráči TakeDamage(damage)
