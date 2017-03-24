# Houbaři

Vážení účastníci úterního cvičení z programování,

Soutěžní úloha je nachystána tak, jak jsme ji v úterý společně navrhli. Vaším úkolem je připravit umělou inteligenci pro houbaře. 

Abyste vytvoříli nového houbaře, oddědíte od třídy `HoubarovoChovani` a naimplementujete virtuální funkci `pohyb()`. Houbaře dále musíte přidat do seznamu hráčů v souboru [Program.cs](Program.cs). Dobrý začátek Vám poskytnou soubory [NahodnyHrac.cs](Hraci/NahodnyHrac.cs) a [HladovyHrac.cs](Hraci/HladovyHrac.cs).

Houbař vidí všechny stromy a ploty, ovšem vlky a houby vidí jen do vzdálenosti čtyř políček.

Tato úloha je bodovaná. Podmínky jsou následující:
- **+10 bodů**: Houbař přežije 500 epoch a sebere alespoň 12 hub (deadline 7. 4. 2017)
- **+5 bodů**: Čest, sladkou odměnu a pět dalších bodů získá vítězný tým na úterní soutěži

Na houbařích můžete pracovat jak sami, tak společně v týmech. V každém případě budu od každého z Vás vyžadovat podrobné vysvětlení napsaného kódu.

Doporučuji si rozdělit práci v týmech na několik dílčích úkolů. Jeden člen týmu může programovat útěk před vlky, druhý člen dojití k houbě, další člen mapování prostoru apod. Následně je třeba dohromady všechny části doladit a zaintegrovat.

Zdrojový kód celého simulátoru si můžete stáhnout jako [zip](https://github.com/FloopCZ/houbari/archive/master.zip) archiv. Po rozbalení archivu ve Visual Studiu vyberte `File -> Open -> Project/Solution` a otevřete soubor `Houbari.csproj` nebo `Houbari.sln`. Potom stačí kliknout na `Start` a zvětšit okno konsole tak, abyste viděli celou hrací plochu.
