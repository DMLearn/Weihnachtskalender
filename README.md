# Weihnachtskalender
Diese XAML Anwendung wird in der einfachsten Struktur aufgebaut, wobei die gesamte Business Logik im Code-Behind abgelegt wird. Das Projekt dient für mich als Übung, welches ich im Rahmen eines [Udemy](https://www.udemy.com) Kurses absolviere. 


Funktionalität:
---------------
1) Beim Start des Programms wird das aktuelle Datum von einem NTP-Server aus dem [NTP Poll Project](http://www.pool.ntp.org/zone/de) abgefragt. Ist dies nicht möglich, wird das Datum der lokalen Maschine ermittelt.

2) Die Ermittlung des aktuellen Datums soll anschließend genutzt werden, dass nur die Fenster im Kalender geöffnet werden können die nicht in der Zukunft liegen. 

3) Die Information ob ein Kalendertürschen bereits geöffnet war, wird in einer .xml Datei abgelegt. Der Unterscheid zwischen einem geöffneten und geschlossenem Türschen wird graphisch kennbar gemacht.

4) Das Hauptfesnter hat insgesamt die einzelnen 24 Türschen für die einzelnen Tage. Eine Textbox mit dem aktuellen Datum und einem schicken Weihnachtsmann im Hintergrung :-)
