# Equipment Rental System
### **💻 C# / .NET Console Application**
## 📌 Opis projektu

Projekt przedstawia prosty system wypożyczalni sprzętu napisany w języku C#.  
Aplikacja działa jako Console Application i demonstruje podstawowe operacje  
zarządzania użytkownikami, sprzętem oraz wypożyczeniami.

---

## 🎯 Funkcjonalności

System umożliwia:

- dodawanie użytkowników (Student, Employee)
- dodawanie sprzętu (Laptop, Projector, Camera)
- wyświetlanie wszystkich sprzętów wraz ze statusem
- wyświetlanie dostępnego sprzętu
- wypożyczanie sprzętu
- zwrot sprzętu (z naliczaniem kary)
- oznaczanie sprzętu jako niedostępnego
- wyświetlanie aktywnych wypożyczeń użytkownika
- wyświetlanie przeterminowanych wypożyczeń
- generowanie raportu końcowego

---

## ⚙️ Reguły biznesowe

- Student może mieć maksymalnie 2 aktywne wypożyczenia
- Employee może mieć maksymalnie 5 aktywnych wypożyczeń
- Kara wynosi 5 PLN za każdy dzień opóźnienia
- Sprzęt ze statusem `Unavailable` lub `Rented` nie może być wypożyczony

---

## 🧱 Architektura projektu

Projekt został podzielony na warstwy:

### Domain
Zawiera modele biznesowe:
- Equipment (abstrakcyjna)
- Laptop, Projector, Camera
- User (abstrakcyjna)
- Student, Employee
- Rental

### Services
Zawiera logikę biznesową:
- UserService
- EquipmentService
- RentalService
- RentalPolicy (limity)
- PenaltyCalculator (kary)
- ReportService (raporty)

### Data
- DataStore – przechowuje dane w pamięci

### Common
- OperationResult – obsługa wyników operacji

### Program.cs
- scenariusz demonstracyjny aplikacji

---

## 🧠 Kohezja, coupling i odpowiedzialności klas

### Kohezja (spójność klas)

Każda klasa odpowiada za jeden, konkretny obszar:
- UserService – zarządzanie użytkownikami
- EquipmentService – zarządzanie sprzętem
- RentalService – obsługa wypożyczeń
- RentalPolicy – zasady limitów wypożyczeń
- PenaltyCalculator – obliczanie kar
- ReportService – generowanie raportów

---

### Coupling (powiązania między klasami)

- serwisy komunikują się przez jasno określone metody
- Program.cs nie zawiera logiki biznesowej
- reguły biznesowe są wydzielone do osobnych klas

---

### Odpowiedzialności klas (SRP)

- modele (Domain) przechowują dane
- serwisy (Services) realizują logikę biznesową  
- Common obsługuje operacje
- DataStore przechowuje dane
- Program.cs odpowiada za uruchomienie aplikacji

---

## 🧩 Uzasadnienie podziału projektu

Podział projektu na warstwy:

- oddzielenie danych od logiki biznesowej
- zwiększenie czytelności kodu
- ułatwienie rozbudowy systemu

---

## ▶️ Uruchomienie

1. Otwórz projekt w Riderze
2. Zbuduj projekt (Build)
3. Uruchom aplikację (Run)

---

## 📊 Scenariusz demonstracyjny

Program automatycznie pokazuje:

- dodanie danych
- poprawne wypożyczenie
- błędne operacje (limit, niedostępność)
- zwrot w terminie
- zwrot po terminie (z karą)
- raport końcowy

---

## 🛠️ Technologie

- C#
- .NET
- Rider

---

## 👤 Autor
Grzegorz Wojewódzki

Projekt wykonany jako zadanie uczelniane.