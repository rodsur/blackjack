# Blackjack
Dette projekt er en simpel implementering af kort spillet Blackjack. Kravspecifikation.md uddyber hvad omfanget er for projektet samt begrænsniner. Projektet er skrevet i C# og kræver dotnet 10.

## byg og kørsel
For at bygge og teste projektet skal man køre følgende kommando fra projektets rod:
```
dotnet build
dotnet test
```
Herefter kan du køre projektet entet ved at navigere via konsollen eller stifinder: 
```
cd Blackjack/bin/debug/net10.0
./Blackjack.exe
``` 
Jeg foreslår at køre projektet fra en terminal da programmet stopper efter scoring og derfor ikke bliver på skærmen med mindre der er kørt fra terminal.
## Mangler
Der er stadig enkelte småting der afviger fra kravspecifikationen, så som den manglende mulighed for at starte et nyt spil efter afslutning.