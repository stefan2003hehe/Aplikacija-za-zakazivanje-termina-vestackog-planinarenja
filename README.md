# Aplikacija za Zakazivanje Termina Veštačkog Planinarenja

Ova web aplikacija je razvijena kao seminarski rad iz predmeta **Razvoj softvera otvorenog koda**. Cilj aplikacije je digitalizacija procesa zakazivanja termina za veštačko penjanje, pružajući efikasan sistem za korisnike, trenere i administratore.

---

## Funkcionalnosti

### Korisnik
* **Registracija i prijava** na sistem.
* **Pregled dostupnih trenera** i njihovih profila.
* **Zakazivanje termina** uz automatsku proveru raspoloživosti.
* **Istorija termina**: Pregled svih prošlih i zakazanih aktivnosti.
* **Štampanje potvrde** o zakazanom terminu.

### Trener
* **Prijava na sistem** i upravljanje ličnim profilom.
* **Lični raspored**: Pregled svih zakazanih termina sa klijentima.
* **Adresar**: Pregled liste korisnika i kolega trenera.
* **Finansije**: Praćenje radnih sati i zarade.

### Administrator
* **Upravljanje sistemom**: Potpuna kontrola nad korisnicima, trenerima i terminima (CRUD).
* **Napredna pretraga**: Filtriranje podataka po različitim kriterijumima.
* **Izveštaji**: Parametarska štampa podataka (npr. filtriranje po polu).

---

## Korišćene tehnologije

* **Frontend:** ASP.NET Web Forms
* **Backend:** C# (.NET Framework)
* **Baza podataka:** Microsoft SQL Server
* **Dijagrami:** PlantUML
* **IDE:** Visual Studio 2022
* **Upravljanje bazom:** SQL Server Management Studio (SSMS)

---

## Instalacija i pokretanje

### 1. Kloniranje repozitorijuma
```bash
git clone [https://github.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja.git](https://github.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja.git)
```

### 2. Podešavanje baze podataka
1. Otvorite folder `BazaPodataka`.
2. Pokrenite SQL skriptu unutar `Baza.txt` u **SQL Server Management Studio (SSMS)**.
3. Skripta će automatski kreirati bazu, tabele, poglede i sve neophodne stored procedure.

### 3. Konfiguracija konekcije
U fajlu `Web.config` prilagodite connection string vašoj lokalnoj instanci SQL Servera:

```xml
<add name="NasaKonekcija" 
     connectionString="Data Source=VAŠ_SERVER; Initial Catalog=vestackoplaninarenje; Integrated Security=True; TrustServerCertificate=True;" 
     providerName="System.Data.SqlClient"/>
```

### 4. Pokretanje
1. Otvorite `.sln` fajl u **Visual Studio 2022**.
2. Pritisnite `F5` ili kliknite na dugme **Start** za pokretanje u browseru.

---

## Dijagrami

| Use Case Dijagram | Dijagram Klasa |
| :---: | :---: |
| ![Use Case](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/image27.JPG) | ![Klasa](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/image28.JPG) |

| ER Dijagram Baze | Dijagram Sekvenci |
| :---: | :---: |
| ![ER](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/image30.png) | ![Sekvenca](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/image29.png) |

---

## Testni nalozi

Nakon pokretanja SQL skripte, možete koristiti sledeće naloge za testiranje:

| Uloga | Korisničko ime | Lozinka |
| :--- | :--- | :--- |
| **Administrator** | `admin` | `admin123` |
| **Trener** | `jovanT` | `trener123` |
| **Korisnik** | `marko95` | `marko123` |

---

## Poslovna logika (XML)

Pravila sistema su eksternalizovana u `PoslovnaLogika.xml` radi lakše izmene bez rekompilacije koda:
* Maksimalni broj termina po korisniku/treneru dnevno.
* Minimalna dozvoljena satnica trenera.
* Maksimalno trajanje jednog termina.

---

## Screenshotovi aplikacije

| Početna stranica | Prijava korisnika | Zakazivanje termina |
| :---: | :---: | :---: |
| ![Početna](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/image8.png) | ![Prijava](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/Picture4.png) | ![Zakazivanje](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/Picture5.png) |

| Admin panel | Trener raspored | Štampa |
| :---: | :---: | :---: |
| ![Admin](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/admin-panel.png) | ![Trener](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/trener-raspored.png) | ![Štampa](https://raw.githubusercontent.com/stefan2003hehe/Aplikacija-za-zakazivanje-termina-vestackog-planinarenja/refs/heads/main/media/stampa.png) |

---

## Autori

* **Merća Bojan** (SI 47/22)
* **Stefan Šipka** (SI 50/22)
* **Veljko Milošev** (SI 30/22)


**Tehnički fakultet "Mihajlo Pupin", Zrenjanin**
*Univerzitet u Novom Sadu, 2026.*
