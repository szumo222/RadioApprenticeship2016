# Raport Maker
Projects that was created while I was taking part in apprenticeship in Polish Radio Szczecin in 2016
This is console application Windows Form application that was made for merging dialy reports in txt format into one file.

## How it works
It is looking for all txt files in a folder. In case that this project was made for, folder contains only desired txt files, so be careful, and do not place other files there.

One signle file look like this:
```
<?xml version="1.0" encoding="UTF-16"?>
Data|Godz.aud.|Tytul audycji|Tytul utworu|Kompozytor|Autor tekstu|Tlumacz|Czas|Wykonawca|Producent|Wydawca|
2016-08-01|00:00|POŻYTECZNI|n_P_CZĘSTOTLIWOŚĆ_01|Agim Dżeljilji|PRS||0:0:20|Brzostyński, Aleksandrowicz, Warchoł|PRS / Szwaja W.||
2016-08-01|00:00|POŻYTECZNI|n_WH_wakacje_Z RS_08_m|Agim Dżeljilji|Agim Dżeljilji||0:0:3|Jacek Brzostyński|Agim Dżeljilji||
2016-08-01|00:00|POŻYTECZNI|CZEKAM...|Ania Dąbrowska|Ania Dąbrowska||0:3:17|ANIA|Ania Dąbrowska|SONY BMG|
2016-08-01|00:00|POŻYTECZNI|n_WH_TO JEST_05_mk|Agim Dżeljilji|Agim Dżeljilji||0:0:4|J. Brzostyński, A. Aleksandrowicz|Agim Dżeljilji||
...
```
Application read all lines from a one file, and from other read all lines except first two rows, so the output file will contains these lines only once.
```
<?xml version="1.0" encoding="UTF-16"?>
Data|Godz.aud.|Tytul audycji|Tytul utworu|Kompozytor|Autor tekstu|Tlumacz|Czas|Wykonawca|Producent|Wydawca|
```

## Usage
User click "Katalog odczytu plików" to choose folders that contains txt files, click "Katalog zapisu pliku" to choose folder where output file has to be saved, specify month in "Wybierz miesiąc", and click "Ok". When merging is finshed message box show up and informs that file has been saved.

<p align="center">
  <img src="https://i.ibb.co/w7w2z59/Raport-Maker-one.png"/>
</p>
