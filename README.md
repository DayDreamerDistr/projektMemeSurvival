# MemeSurvival

* kompaktní tutorial tvým prvním projektem
* pro doplnění znalostí C#: https://securoverse.com







### Collision

https://docs.godotengine.org/en/stable/tutorials/physics/physics\_introduction.html

* U všech nodes co dědí z CollisionObject2D můžeš najít v Properties odrážku Collision, s tabulkou čísel. Jedná se o Collision Layers.
* Collision Layer = vrstva, na které objekt koliduje s ostatními objekty.
* Collision Mask = specifikuje vrstvy, na kterých samotný objekt není přítomen, ale na které když narazí, tak s nimi stále koliduje.
* příklad: když zvolíme Collision Layer 1, ale necháme Mask prázdné, tak objekt bude zaznamenán ostatními objekty co mají v jejich Mask Layer 1, ale samotný objekt nebude s ničím kolidovat.
* Klepnutím pravým tlačítkem na jakýkoliv Layer ti ho umožní přejmenovat, to se hodí pro přehlednost.



### Input

https://docs.godotengine.org/en/stable/tutorials/inputs/index.html

* základně máš v Godotu nějaké systémové inputy (např. ui\_left, ui\_right apod.), ale v praxi se hodí vytvořit si vlastní, které si můžeš nastavit na jednu i víc kláves.
* Project > Project Settings > v horním menu odrážka Input Map
* Do políčka Add New Action napiš název a klikni na +Add
* vytvoří se ti nový záznam se zadaným názvem. Když klikneš na + vedle záznamu, můžeš vybrat, k jakému typu inputu (klávesa, tlačítko myši...) se má přiřadit.
* Pak stačí zmáčknout klávesu, kterou chceš přiřadit, a automaticky by ji to mělo navrhnout, pak už jen potvrdíš.



### Signals

https://docs.godotengine.org/en/4.4/getting\_started/step\_by\_step/signals.html

* Signály jsou velice užitečné, pokud potřebuješ spustit nějaký v reakci na nějakou událost, například pokud zasáhne střela hráče, tak si má ubrat životy.
* Vetšina nodes má vlastní signály, které se dají jednoduše propojit se skriptem.



### Shaders

https://docs.godotengine.org/en/4.5/tutorials/shaders/shader\_reference/index.html

* shader je lepší způsob modifikace textury než přes kód, protože je zpracován **paralelně** a používá GPU. Co to znamená?
* paralelní zpracování = úkona se zpracovává na několika vláknech najednou, využívá multithreading
* zatímco kód se zpracovává **synchronně** = akce se konají po sobě, dokud jedna neskončí, další nezačne (takže pokud jedna trvá dlouho, další se opozdí)
* použití GPU = mnohem rychlejší na zpracování grafiky než s CPU
* všechny Node co jsou potomci CanvasItem mají vlastnost mít vlastní material
* můžeme přidat ShaderMaterial, ke kterému už jen stačí přidat Shader = skript (.gdshader), píše se v jazyce podobném GLSL https://cs.wikipedia.org/wiki/OpenGL\_Shading\_Language





Úkoly

1. Nastavit správně masku Hitboxu
2. Input map
