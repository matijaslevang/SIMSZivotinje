Projekat iz predmeta Specifikacija i modeliranje softvera za SIIT

Aplikacija za proizvoljno udruzenje za zastitu zivotinja (kucnih ljubimaca)

- uloge: admin, volonteri, clanovi, gosti
- pomoc: hrana, privremeno zbrinjavanje, udomljavanje, prevoz zivotinja, novac

Korisnik (svako sem Gosta)- funkcionalnosti:
- prijava (id, lozinka)/odjava
- izmena licnih podataka

Admin - funkcionalnosti:
- kreira entitet Udruzenja
- kreira 1. volontera i sav dalji posao prepusta njemu (i ostalim buducim volonterima)

Volonteri - funkcionalnosti:
- dodaju objavu o zivotinji (CRUD) (kroz formu)
- odlucuju ko ce postati novi volonter (član šalje zahtev za postajanje volontera, ostali volonteri glasaju)
- odlučuju kog volontera izbaciti (glasanjem gde jedan volonter predlozi nekog korisnika, ostali glasaju)
- primaju zahteve za objave od clanova i odlucuje da li ih objaviti
- ocenjuju/komentarisu clanove
- komentarisu/lajkuju objavu
- importuju izvod iz banke na dnevnom nivou u app kako ne bi morali rucno da se bave time
- vide kod kog je koja zivotinja udomljena (dodatni podatak u okviru objave) - mozda prikazati spisak svih (ne)udomljenih zivotinja
- mogu da ocene iskustvo sa tom osobom
- opciono: kreiraju crnu listu korisnika (npr. oni sa ocenom 1-2)
- imaju mogućnost samoizbacivanja (ne zelim vise da budem volonter)
- odobravaju zahteve za registraciju korisnika
- mogu da šalju poruke svima
* Uglavnom nema brisanja, ali ima promena statusa poput blokiranja
- mogu da logicko obrisu objave (npr. ako neko troluje)

Objava/zahtev na aplikaciji:
Atributi:
- vrsta (pas, macka...)
- rasa (opciono)
- zdravstveno stanje (zdrava, bolesna, fali noga...)
- godina rodjenja (ne mora precizno)
- isUdomljena (ako je udomljena i dalje ostaje objava, postoji mogucnost odustanka od udomljenja)
- snimci/slike (opciono)
- boja
- starost ako moze da se ustanovi po proceni
- lokacija gde je nadjena ili gde se trenutno nalazi
- skriveni deo od korisnika: podaci o autoru objave
- status zahteva: ODOBRENA/ODBIJENA

Gosti - funkcionalnosti:
- pregled i pretraga objava (moze svaki korisnik)
- registracija (salje se zahtev)

Clan (registrovani) - funkcionalnosti:
- salju zahtev volonteru za objavu (ili za izmenu postojece objave)
- šalju zahtev za pomoć:
  1. anonimne donacije za lecenje zivotinje (npr. kad su na lecenju na veterinarskoj ustanovi)
  2. udomljavanje
  3. privremeno zbrinjavanje (korisnik sam oznacava u kom periodu zeli da se stara o zivotinji)
- mogu da ocene zivotinju na cuvanju: brojcano 1-5 ili komentar
- dodaju ocenu i komenatar na objavu o zivotinji, da bi buduci vlasnik imao dodatne info
- podnosi zahtev za postajanje volontera
- salju privatnu poruku volonterima 
- salju privatnu poruku anonimnom autoru objave



Udruzenje
Atributi:
- naziv
- kontakt (email, telefon, insta)
- adresa
- racun u banci za uplate sa 18 cifara (funkcionalnost uplacivanja nije podrzana ovom aplikacijom, nego preko mBankinga npr.)
* Javno se vide sve uplate i isplate
* Preko polja za svrhu uplate se specificira zivotinja za koju se donira novac
* Mi pokrivamo jedno udruzenje   

