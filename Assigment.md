#### Cíl výsledné hry

* Player se hýbe pomocí WASD.
* Enemies se spawnují průběžně a běží na Player.
* Enemy ubírá Playerovi HP + dává knockback.
* Player míří zbraní myší a střílí bullets.
* Bullet ubírá enemy HP, enemy krátce blikne červeně (shader).
* Skóre roste za zabité enemy.
* Po smrti Playera se ukáže Game Over menu + tlačítko Try Again.



#### Důležité

* Editor = Godot
* Node = jednotlivý objekt v tvém projektu (characterbody, sprite, collisionshape…)
* scéna = ukládáš je jako soubory, obvykle více Nodes s nějakou extra logikou a setnutými parametry (Player, BasicEnemy, World…)
* Po každém úkolu hru otestuj, že funguje jak má!





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



**Nápověda:**

* Label můžeš napojit do kódu přes \[Export] (přiřadíš v editoru)
* Pokud chceš aby se HP zobrazilo hned od začátku, můžeš pro nastavení HPLabel využít metodu **public override void \_Ready()** - volá se jednou při inicializaci node



##### Úkol #2 - BasicEnemy útočí

* Hráč má připravenou metodu TakeDamage, ale nikdy se nevolá.
* V BasicEnemy Scéně:
* Přidej child node Area2D a pojmenuj třeba Hitbox
* Pod Hitbox přidej CollisionShape2D
* Nastav shape tak, aby dával smysl
* Nastav v properties Hitboxu v odrážce "Collision" Layer a Mask (nápověda v README, sekce Collision)
* Připoj signal body\_entered z Hitbox do enemy skriptu
* Vytvoř metodu se jménem signálu (private void stačí), nezapomeň na vstupní parametr (lze najít v editoru u signálu)
* Udělej podmínku, že body je Player - nechceme útočit na ostatní enemies
* Zavolej hráči TakeDamage(damage)



**Nápověda:**

* Vstupní parametr signálu je body, což je Node která vstoupila do hitboxu, body bude tím pádem player, ale abychom mohli zavolat jeho vnitřní metody, je třeba programu dát najevo, že body je player - provést explicitní konverzi typu. ([Datové typy](https://securoverse.com/csharp/data-types/data-types-overview))



##### Úkol #3 - Smrt hráče

* Hráč dostává damage, ale když mu klesne HP na 0 tak se nic nestane.
* je to jednoduché, stačí přidat podmínku do TakeDamage, že když je HP 0, tak se IsDead nastaví na true.
* Aby se hráč nemohl už pohybovat když je mrtvý, přidej na začátek PhysicsProcess check na IsDead, pokud je true => return



##### Úkol #4 - Knockback hráče

* Přidáme si i nějaký knockback co hráč dostane při zásahu Enemy.
* Nejjednodušší způsob bude zase vytvořit metodu ve skriptu hráče, kterou prostě zavoláme při zásahu. Zkus na to přijít sám, je to skoro stejné jako TakeDamage.
* Knockback můžeš udělat například tak, že hráči přidáš Velocity v opačném směru než je Enemy.



**Nápověda:**

* Velocity nemůžeš jen tak nastavit kdekoliv, protože se zpracovává pouze při MoveAndSlide.
* Tip: udělej si pro aplikaci knockbacku proměnnou, kterou pak přidáš k Velocity těsně před zavoláním MoveAndSlide.



##### Úkol #5 - Game over screen

* Teď můžou Enemies krásně hráče šikanovat, ale chtělo by to i nějaké menu pro Game over.
* Na UI se zpravidla využívá CanvasLayer - vykresluje se nezávisle na herní scéně. ([CanvasLayer](https://docs.godotengine.org/en/stable/tutorials/2d/canvas_layers.html))
* V editoru vytvoř novou scene typu CanvasLayer. Pojmenuj ji HUD.
* Přidej Control jako child, pojmenuj to GameOver. To bude naše screen pro smrt a restart.
* Pod GameOver přidej ColorRect, Label a Button.
* U ColorRect můžeš v menu nahoře uprostřed vidět ikonku kotvy a vedle toho takové zelené kolečko (Anchor preset). Rozbal nabídku kolečka a zvol plný bílý čtverec (Full rect). To způsobí, že se ColorRect roztáhne přes celou obrazovku.
* ColorRect má property Color, Tak tam nastav libovolnou barvu. Hodí se ji udělat částečně průhlednou (A hodnota).
* Dál nastav u labelu ať je uprostřed obrazovky (opět zelené kolečko, vyber vhodnou možnost). Dej Labelu text "Game over". v label settings můžeš zvolit new LabelSettings, na které když pak poklepeš tak se ti zobrazí možnosti editace fontu apod.
* Na závěr ještě zvol u button Anchor preset na Bottom Wide, a dej mu text "Try Again".
* Font size buttonu můžeš nastavit v odrážce Theme Overrides > Font Sizes.



* Vytvoř nový skript pro HUD.
* přidej mu pomocí \[Export] proměnnou obsahující GameOver node (typ proměnné Control)
* V metodě \_Ready nastav viditelnost GameOver na false (\_gameOver.Visible)
* Pak vytvoř metodu jménem PlayerDied, kde jenom nastav viditelnost GameOver na true.
* Ještě je třeba spojit button pro TryAgain. Přidej signál pro pressed() z button do HUD a přidej ve skriptu signálovou metodu.
* V metodě napiš jediný řádek: **GetTree().ChangeSceneToFile("res://Scenes/world.tscn");**
* Co to je? To jednoduše načte root node znovu, což udělá to samé jako kdybychom hru vypli a zapli, efektivně tak hru restartujeme.



##### Úkol #6 - Zbraň

* hráč se potřebuje proti Enemies nějak bránit!
* Vytvoř novou scene s Node2D, kterou pojmenuj Gun.
* Nebudeme to mít nějak složité, přidej pak jenom Sprite2D pro texturu (nějakou si nakresli).
* Přidej skript ke zbrani. Už je vytvořený, najdeš ho ve Scripts pod jménem Gun.cs.
* 
* Budeme potřebovat pár proměnných: floaty ShootingDelay a timeSinceLastShot, a ještě string BulletScenePath, kam rovnou přiřadíš cestu k Bullet scene, kterou vytvoříš za chvíli.
* V metodě process zavolej na začátku Godotí funkci jménem LookAt(*pozice*). Tato funkce natočí Gun tak, aby se dívala na pozici, kterou zadáme jako vstupní parametr. No a jasně, že jako pozici tam dáme pozici myši (GetGlobalMousePosition).
* Dále chceme nějaký delay mezi výstřely, ať hráč nemá minigun. K tomu vytvoříme improvizovaný timer (efektivnější než Timer node, protože je úspornější pro paměť). K tomu použijeme timeSinceLastShot, který bude postupně narůstat dokud se nesplní podmínka. Pak ho zase vynulujeme a vyresetujeme tak timer.
* Na závěr chceme v \_Process kontrolovat, jestli hráč zmáčkl akci na shoot a taky jestli delay mezi výstřely byl dostatečný. Ke kontrole inputu slouží třída Input. Přidej do podmínky: Input.IsActionJustPressed("shoot"). Ještě je třeba namapovat shoot v Input Map v editoru na levé tlačítko myši (nebo cokoliv čím má hráč střílet).
* Metodu shoot jsem už vypracoval, přečti si komentáře abys pochopil co se tam děje.
* Ještě musíme přidat Bullet Scene aby vše fungovalo.
* aby hráč nemohl používat zbraň po smrti, přidej kontrolu jestli je hráč IsDead na začátku \_Process. Nápověda: potřebuješ referenci na Player node.



##### Úkol #7 - Náboje

* Vytvoř si novou scene - Bullet. Udělej Bullet typu Area2D, to nám stačí.
* Přidej mu collider a sprite. Zkus mu určit takovou velikost, aby vypadal jako bullet z pistole, ne jako cannon ball XD.
* Přidej bulletu skript. Ke skriptu připoj signál body\_entered z té samé Node. (takže signál samo na vlastní skript)
* Přidej do bulletu proměnné pro damage, směr letu a rychlost náboje.
* Skoč do enemy skriptu, kde vytvoříš metodu TakeDamage. Můžeš ji udělat prakticky stejnou jako u hráče.
* Vytvoř metodu pro signál na body\_entered a získej body ze vstupního parametru. Udělej kontrolu, že body je Enemy, přetypuj a zavolej enemy.TakeDamage.
* Jako poslední přidej na konec signálu QueueFree(); - To odstraní bullet, protože už narazil do Enemy.
* Teď ještě přejdi v Editoru do filesystému (tam kde máš zobrazenou strukturu projektu) a klikni pravým tlačítkem na bullet.tscn a zvol Copy Path. To zkopíruje cestu ke scéně. Přiřaď to k BulletScenePath proměnné ve skriptu Gun.cs.



##### Úkol #8 - Střílení

* Když voláš u spoustu Nodes \_Process a \_PhysicsProcess, tak to může být pro engine náročné. Proto si ve World přidáme Node2D, kterou pojmenujeme BulletController. Dej si pozor aby to bylo child pouze root node, ne třeba Playera.
* K BulletController připoj skript. Je již vytvořený, Scripts > BulletController.
* Jen si prohlédni co tam dělám, není to nic složitého.
* Nyní je třeba ještě spawnout Bullet při výstřelu.
* Ve skriptu Gun.cs již máme připravenou metodu shoot. Přidej proměnnou \_bulletController a v \_Ready odkomentuj přiřazení node.
* Následně odkomentuj všechen kód (ne komentáře) v metodě Shoot a zkus pochopit co tam dělám.
* Teď by mělo střílení fungovat. Vyzkoušej.



##### Úkol #9 - Damage indicator

* Bylo by fajn aby měl hráč nějaký response na to když enemy dostane zásah.
* Když půjdeš do Scene BasicEnemy, klikneš na Sprite2D a přejdeš k properties, tak tam můžeš najít odrážku material.
* Přidej nový ShaderMaterial a klikni na něj, aby si zobrazil jeho vlastnosti.
* Ještě musíš přidat samotný shader. Zvol Load a vyber jediný shader v našem projektu (Shaders > BasicEnemy.gdshader)
* Teď je třeba ve skriptu Enemy přidat metodu pro spuštění Shaderu. Už tam je, tak si přečti co se tam děje, kdybys nevěděl co je async tak mi radši napiš.
* Teď už jenom metodu FlashRed zavolej pokaždé když dostane Enemy zásah (nápověda: Bullet.cs)
