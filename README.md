# Joc Tetris | Proiect pe echipe Informatică

## Componența echipei:
* **Botezan Vlad** - Core Components Developer
* **Andreea Savoș** - OOP Specialist & Application Architect
* **Ionel Timiș** - Logic Method Specialist & Coding Monkey
* **Andrei Muntean** - Coding Monkey

## Tema aleasă:
**Tetris** este printre cele mai populare jocuri pe calculator din lume. Alegerea de a-l implementa a venit în urma faptului că implementarea lui nu este deloc ușoară, iar **noi am vrut o provocare** care să ne ajute să ne dezvoltăm abilitățile de programare, atât indivdual cât și într-o echipă. Numele repository-ului nostru **study-adventure** deoarece am privit această experientă ca pe o aventură în domeniul cunoașterii.

## Organizarea echipei
### Lucrul în echipă, roluri individuale
Primele două ore de informatică au fost alocate structurii logice a viitoarei aplicații, reușind să înțelegem felul în care OOP-ul poate fi de folos într-o astfel de situație.
Am folosit abilitățile fiecăruia la nivelul maxim posibil.
### Primele linii de cod
Clasa care stă la baza proiectului nostru este **clasa Square**, care a fost implementată de Vlad Botezan încă din prima oră destinată codării.
### Provocări apărute în timpul implementării
Prima și cea mai mare provocare care a apărut a fost problema formei piesei active, care este generată aleator. Problema a fost semnalată de Andrei și rezolvată de Andreea, prin folosirea unei clasa abstracte numită **Piece**, care să fie moștenită de toate celelate tipuri de piese.
### Problema Rotirii piesei active
Porblema a fost semnalată încă din stadiul de proiectare, însă a rămas nerezolvată până cănd Ionel a reușit să găsească o formulă matematică care a dus la rezolvarea acestei probleme.

## Specificații Hardware și Software necesare
Aplicația a fost proiectată pentru Windows 10. A fost testată cu succes și pe WIndows 8, însă nu au fost efectuate teste extinse.

## Descierea Logică a aplicației
Aplicația implementează următoarele componente:
* o **tablă** ce conține pătrate (obiecte de tip Square) pe care se desfășoară jocul
* **o piesa activă** pe care utilizatorul poate să o rotească și să o miște dreapta stânga
* **piese inactive** aflate pe tabla de joc
* un **sistem de scor** care adaugă un punct și elimină rândul/rândurile complet(e) din tablă care a/au generat scorul.

**Pentru începerea jocului este necesară apăsarea butonului START**

## Clase remarcabile
### Clasa Square
Se ocupă de partea vizuală, fiind cea care generează un pătrat declarat logic la nivel de matrice pe ecran și schimbă culoarea acestuia.

```csharp
public void SetPosition(int i, int j)
       {
           if (i * j > 0)
           {
               _x = Game.X_BOARD + _width * (j - 1);
               _y = Game.Y_BOARD + _width * (i - 1);
           }
       }
```

```csharp
private void Draw()
       {
           Pen p = new Pen(c);
           g.DrawRectangle(p, _x + 1, _y + 1, _width - 2, _width - 2);
           SolidBrush brush = new SolidBrush(c);
           g.FillRectangle(brush, _x + 1, _y + 1, _width - 2, _width - 2);
       }
```
```csharp
public void SetColor(Color color)
       {
           c = color;
           Draw();
       }
```

### Clasa Piece
Este o **clasă abstractă** care conține doar antetele metodelor care trebuie implementate de clasele de tip Piesă

```csharp
       public abstract bool CanMove(int ii, int jj);
       public abstract void Move(int ii, int jj);
       public abstract void Solidify();
       public abstract void RotateClockwise();
```

### Clasele TPiece, LPiece etc...
Sunt clase care moștenesc clasa Piece. Conțin particularizări de implementare a fiecărui tip de piesă.

#### Metoda de rotire
Rotește piesa în sensul acelor de ceasoric prin folosirea unui punct fix și rotirea celorlalte după formula:

>  noul i primește vechiul j
>  
> noul j primește **minus** vechiul i

coordonatele sunt date în funcție de punctul fix al pisei

```csharp
public override void RotateClockwise()
      {
          int c_i = _i[2];
          int c_j = _j[2];
          int[] bk_i = new int[4];
          int[] bk_j = new int[4];
          for (int i = 0; i < 4; ++i)
          {
              bk_i[i] = _i[i];
              bk_j[i] = _j[i];
              _i[i] = (bk_j[i] - c_j) + c_i;
              _j[i] = -(bk_i[i] - c_i) + c_j;
          }


          if (CanMove(0, 0))
          {
              for (int i = 0; i < 4; ++i)
              {
                  game.squares[bk_i[i], bk_j[i]].SetColor(Color.LightGray);
              }

              for (int i = 0; i < 4; ++i)
              {
                  game.squares[_i[i], _j[i]].SetColor(color);
              }
          }
          else
          {
              for (int i = 0; i < 4; ++i)
              {
                  _i[i] = bk_i[i];
                  _j[i] = bk_j[i];
              }
          }
        }
```
#### Metoda CanMove()
Verifică dacă mutarea piesei curente este posibilă în raport cu piesele deja considerate fixe.  

#### Metoda Solidify()
Este o metodă care transformă o piesă activă într-o piesă inactivă. Este apelată în momentul în care piesa „aterizează” pe o piesă fixă.

#### Metoda Move()
Este complementară metodei *CanMove* și execută mutarea piesei. (mutarea dpdv. vizual).

### Clasa Game
Este cea mai importantă clasă din joc deoarece aici se află declarate toate *constantele care sunt folosite la generarea celorlalte componente*. De asemenea, aici se mai:
* verifică dacă jocul s-a terminat
* generează o nouă piesă aleatoriu
* se verifică dacă se poate marca un punct și totodată elimină linia care a generat punctul

## Alte detalii remarcabile:
* **proiectul este open-source și este disponibil la adresa: github.com/netfree/study-adventure**. Invităm pe oricine să aducă înbunătățiri.

## Descrierea folosirii aplicatiei
Pentru a porni jocul, este necesara apăsarea butonului **start**. După apăsarea butonui start, piesa activă se poate muta stânga și dreapta cu tastele A respectiv D. Coborârea poate fi accelerată folosind tasta S, iar rotirea în sensul acelor de ceasornic se realizează cu tasta W. În momentul terminării jocului, mesajul „TZEAPĂ” este afișat în mod ontinuu pentru a accentua caracterul de pierzător al utilizatorului. Ieșirea se efectuează cu combinația ALT-F4.
