# Wymagania
System służy do zarządzania obiegiem dokumentów, które wspierają system jakości (np. ISO, QEP) w przedsiębiorstwie. 
System powinien byś otwarty na rozbudowę w kierunku wspierania innych systemów jakości.
Podstawowym artefaktem w systemie jest Dokument, który zawiera treść mającą na calu pomóc pracownikom 
pracować nad zwiększaniem jakości produkcji.

Są różne rodzaje dokumentów: Księga jakości, Księga procedur, Instrukcje,..
Generalny przepływ dokumentu wygląda tak:
-	dokument jest tworzony przez managera jakości – jest wówczas w statusie Draft
-	dokument jest weryfikowany przez innego managera jakości – Verified
-	dokument jest publikowany
-	podczas publikacji określamy działy w firmie, które muszą się zapoznać z treścią dokumentu,
-	wszyscy pracownicy z tych działów muszą zostać powiadomieni o ukazaniu się dokumentu,
-	niektórzy pracownicy nie potrafią korzystać z komputerów, dla nich są drukowane kopie, które muszą przeczytać, manager takiego pracownika odnotowuje w systemie fakt, że dokument został przez niego przeczytany
-	dokumenty powinny być podpisane cyfrowo, aby zabezpieczyć się przez zmianą treści na wypadek pozwów
-	dokument wygasa (staje się nieaktualny) i trafia do archiwum
-	jest tworzona nowa wersja dokumentu

System powinien być zintegrowany z:
-	dowolnym system kadrowym przechowującym dane o pracownikach (np. adresy mail do wysyłki),
-	dowolnym systemem do masowych wydruków
-	dowolną biblioteką podpisów cyfrowych
-	System powinien być dostępny w formie:
-	Aplikacji web (pełna funkcjonalność)
-	Aplikacji mobilnej (czytanie dokumentów, potwierdzanie przeczytania przez managera w imieniu pracowników wykluczonych cyfrowo)
-	API web serwisów do integracji w przyszłości z innymi systemami

# Zadanie: Singleton
Stworzyć klasę globalnego rejestru błędów.

## Założenia:
-	Obiekt tej klasy powinien być tworzony dopiero gdy będzie potrzebny (może się zdarzyć tak, że w czasie życia aplikacji żadne błędy nie wystąpią)
-	Dostęp do obiektu może być współbieżny.

# Zadanie: Strategy
Stworzyć encję reprezentującą Dokument.
Wymagania:
-	Dokument podczas tworzenia ma automatycznie generowany numer – zależnie od ustawień systemowych 
  (pobieranych z pliku konfiguracyjnego aplikacji)- System może działać w trybie obsługi dokumentów ISO, QEP, itp.
-	Dokument podczas publikowania ma obliczany koszt wydruku jednej sztuki.
-	Wydruk czarno-biały, wydruk kolorowy. 
-	typ wydruku pobierany z pliku konfiguracyjnego aplikacji

Przetestować:
-	Tworzenie dokumentu
-	Operację publikowania na dokumencie (odpowiedni status dokumentu i odpowiednia cena)
-	Strategie obliczania ceny w ramach dokumentu
-	Strategie generowanie numeru w ramach dokumentu

# Zadanie: Factory idiom
Strategie ustawić w konstruktorze Dokumentu. Tworzenie strategii należy enkapsulować w Fabrykach.

## Założenia:
-	Zakładamy, że strategie są szczegółami implementacyjnymi Dokumentu i nie chcemy ujawniać ich istnienia poza Dokumentem.
-	W szczególności nie istnieje możliwość wybrania przez użytkownika żądanej strategii.

# Zadanie: Strategy i Decorator

Założenia dla cen:
-	Sposób obliczania ceny wydruku może zależeć od wielu czynników (np.: typ dokumentu, kolor)
-	Dla dokumentów typu „Księga jakości”  kosz zwiększa się o 30%
-	Jeżeli ilość stron jest większa niż 100, wówczas zwiększa to koszt początkowy o 40.
-	Czynniki te mogą zmieniać się dynamicznie, zatem struktura algorytmu obliczani powinna być „składana” również dynamicznie.

Założenia dla numerów
-	Generowanie numerów dokumentu zależy od nakładających się czynników
-	W wersji DEMO każdy numer ma przedrostek „demo”
-	Jeżeli z systemem pracuje audytor, wówczas każdy numer ma przyrostek „audit”

# Zadanie: Chain of Responsibility 

Zaimplementować mechanizm walidacji dokumentu podczas zmiany jego stanów:
-	weryfikacji
-	publikacji
Zmiana stanu poprzez metodę biznesową.

W zależności od statusu w jakim znajduje się dokument należy zastosować inne kryteria walidacji:

## W ISO:
-	Aby zweryfikować dokument musi mieć ustawiony tytuł
-	Aby opublikować dokument musi mieć ustawioną data wygaśnięcia.
## W QEP
-	Aby zweryfikować dokument musi mieć ustawionego autora i data wygaśnięcia
-	Aby opublikować dokument musi istnieć treść dokumentu

Odpowiedni walidator dobrać w zależności od statusu dokumentu.
**UWAGA**: kryteria walidacji w danym statusie będą inne dla różnych systemów jakości (np. weryfikacja w ISO wymaga daty i numeru a w QEP numeru i nazwy), należy zaprojektować rozwiązanie, które będzie uwzględniało łatwe modyfikacje przy wprowadzaniu obsługi nowych systemów jakości.
Zadanie: Chain of Responsibility 2
Dokonać refaktoryzacji poprzedniego  rozwiązania do postaci używającej Managera Walidacji.


# Zadanie: Builder 1
Dodać funkcjonalność eksportu Dokumentu do strumienia. Zaimplementować jeden z możliwych strumieni wyjściowych: strumień CSV o następującej strukturze:
numer,  tytuł, status, typ dokumentu, data wygaśnięcia, autora	

## Założenia:
-	Może istnieć wiele możliwych form wynikowych
-	Jedną z nich jest strumień bajtów
-	Inne to np.: XML, JSON, PDF, itp.

# Zadanie: Assembler
Stworzyć test jednostkowy Dokumentu, który sprawdza:¬¬
-	publikowanie dokumentu
-	niemożność dwukrotnego opublikowania dokumentu
-	niemożność zmiany tytułu opublikowanego dokumentu

# Zadanie: State
Zaimplementować maszynę stanów odpowiadającą przejściom statusów dokumentów wg schematu:
DRAFT->VERIFIED->PUBLISHED->ARCHIVE

Dodatkowe założenia:
-	z każdego statusu można przejść do statusu ARCHIVE
-	z ARCHIVE można przejść do DRAFT
-	z PUBLISHED można przejść do VERIFIED i DRAFT
-	z VERIFIED można przejść do DRAFT

Jeżeli zostanie wywołanie nielegalne przejście wówczas należy rzucić wyjątek.
Podczas przechodzenia pomiędzy statusami należy odnotować daty zajścia tych faktów

Refaktoryzacja:
Przenieść do maszyny stanów funkcjonalności:
-	obliczania kosztu
-	walidacji

# Zadanie: Template Method

Zaimplementować funkcjonalność kopiowania dokumentu w osobnej klasie DocumentCopier.
Generalna zasada działania kopiowania polega na:
-	przepisaniu kluczowych wartości: typ, tytuł, ilość stron
-	zainicjowaniu unikalnych wartości: numer
-	wyliczeniu wartości: dataWygaśnięcia, dataUtworzenia

## Założenie:
Kroki: generowanie numeru i wyliczenie daty wygaśnięcia są abstrakcyjne, ponieważ zależą od specyfiki konfiguracji itp., dlatego powinny znaleźć się poza ogólnym algorytmem.

# Zadanie: Adapter
Dodać symulację integracji z systemem firmy trzeciej, odpowiedzialnym za generowanie numerów dokumentów. System ten zwraca trzy łańcuchy znaków: numer główny, numer drugiego rzędu, numer wersji.
Format po integracji: x-y-z
Założenie:
Chcemy zachować spójność core’owych funkcjonalności.

# Zadanie: Wrapper
Dokonać refaktoryzacji reprezentacji kosztów wydruku. Koszt powinien być przechowywany w specjalnej klasie Money, która enkapsuluje:
-	walutę w jakiej jest przechowywana wartość (dodać metodę zwracającą wartość w zadanej walucie)
-	sposób reprezentacji
-	operacje na walutach

# Zadanie: Specification
Dodać serwis biznesowy oferujący funkcjonalność wyszukania na liście dokumentów tych z nich, które wymagają audytu.
Kryteria audytu mogą należeć do puli następujących kryteriów:
-	pewien określony status
-	pewien określony typ dokumentu
-	określona grupa autorów
-	dataUtworzenia mniejsza lub większa niż zadana
-	tytuł zawierający określone słowa

## Założenie:
-	Kryteria mogą być dowolnie kombinowane a pomiędzy nimi mogą zachodzić dowolne relacje logiczne.
-	To z jakich kryteriów składa się aktualny warunek może zależeć od aktualnie zalogowanego użytkownika, konfiguracji systemu (wdrożenia) lub ew. może być określone na GUI
Zadanie: Role Object
Zaimplementować model ról użytkownika:
-	Korektor dokumentów
-	Oceniający dokumenty
przy założeniu następujących typów użytkowników:
-	Audytor
-	Autor
-	Manager jakości

# Zadanie: Command
Stworzyć API w warstwie aplikacji, które pozwala operować na dokumentach przy pomocy poleceń. Zaimplementować polecenia:
-	Utwórz nowy dokument o zadanych parametrach, przez zadanego autora
-	Przypisz dokument do zadanych osób i opublikuj go
-	Przedłóż okres ważności dokumentu do zadanej daty

# Zadanie: Proxy
Założenie:
-	Integracja z podsystemem generującym numery dokumentów sprawia problemy, ponieważ jest on często niedostępny.
-	Nie mamy dostępu do kodu adaptera

Stworzyć klasę proxy, która próbuje łączyć się z serwisem. W razie niepowodzenia korzysta z własnego mechanizmu generowania numerów.

# Zadanie: Observer
Wzbogacić funkcjonalność maszyny stanów o możliwość rejestrowania słuchaczy zdarzeń biznesowych związanych ze zmianą statusów dokumentów.
Założenie:
-	Słuchacze mogą dodawać nowe funkcjonalności do systemu (np. mailing)
-	Zestaw wpiętych słuchaczy zależy do specyfiki wdrożenia systemu

# Zadanie: Facade
Przykryć funkcjonalność filtrowania dokumentów wymagających audytu wygodną fasdą, która zwraca dokumenty opublikowane, które wygasają w ciągu tygodnia i są autorstwa aktualnie zalogowanego użytkownik
