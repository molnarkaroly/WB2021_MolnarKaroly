# C# Windows Forms Gyors Jegyzet

## 1. Alapok és Projekt Létrehozása

### 1.1. Windows Forms Projekt Indítása

1.  Visual Studio-ban: `File` -> `New` -> `Project...`
2.  Keresd meg: "Windows Forms App (.NET Framework)" vagy "Windows Forms App" (a .NET Core/.NET 5+ verziókhoz).
3.  Válaszd ki a C# sablont, adj nevet a projektnek, és kattints a `Create` gombra.

### 1.2. Fontos Fájlok és Ablakok

-   **`Program.cs`**: A program belépési pontja. Általában tartalmazza:
    ```csharp
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // Az elsőként megjelenő Form
        }
    }
    ```
-   **`Form1.cs`**: Az alapértelmezett Form kódja (code-behind).
-   **`Form1.cs [Design]`**: A Form vizuális tervezőnézete. Itt tudsz vezérlőket (controls) elhelyezni és tulajdonságaikat beállítani.
-   **`Form1.Designer.cs`**: A tervező által generált kód. Általában nem kell manuálisan módosítani. Itt található az `InitializeComponent()` metódus, ami a Form és a vezérlők inicializálását végzi.
-   **Solution Explorer**: Megjeleníti a projekt fájljait és mappáit.
-   **Properties Window**: Megjeleníti a kiválasztott vezérlő vagy Form tulajdonságait.
-   **Toolbox**: Tartalmazza az elérhető vezérlőket, amiket a Form-ra húzhatsz.

## 2. Form (Ablak)

A Windows Forms alkalmazás alapvető vizuális eleme.

### 2.1. Form Tulajdonságok (Properties Window-ban vagy kódból)

-   **`Name`**: A Form neve a kódban (pl. `mainForm`).
-   **`Text`**: A Form címsorában megjelenő szöveg.
-   **`Size`**: A Form mérete (Width, Height).
-   **`StartPosition`**: A Form kezdeti pozíciója (pl. `CenterScreen`).
-   **`FormBorderStyle`**: A Form keretének stílusa (pl. `FixedSingle`, `Sizable`).
-   **`Icon`**: A Form ikonja.
-   **`BackColor`**: A Form háttérszíne.
-   **`BackgroundImage`**: Háttérkép.

### 2.2. Form Események

Néhány gyakori Form esemény:

-   **`Load`**: Akkor következik be, amikor a Form betöltődik, de még nem látható. Ideális inicializáláshoz.
-   **`Shown`**: Akkor következik be, amikor a Form először megjelenik.
-   **`FormClosing`**: Akkor következik be, mielőtt a Form bezárulna. Lehetőséget ad a bezárás megakadályozására (`e.Cancel = true;`).
-   **`FormClosed`**: Akkor következik be, miután a Form bezárult.

```csharp
// Form1.cs - Load eseménykezelő
private void Form1_Load(object sender, EventArgs e)
{
    this.Text = "Üdvözlő Ablak";
    // További inicializálás
}
```

## 3. Alapvető Vezérlők (Controls)

A Toolbox-ból húzhatók a Form-ra.

| Vezérlő          | Leírás                                   | Gyakori Tulajdonságok                  | Gyakori Esemény |
| :--------------- | :--------------------------------------- | :------------------------------------- | :-------------- |
| `Label`          | Szöveg megjelenítésére                   | `Text`, `Font`, `ForeColor`, `AutoSize`| N/A (ritkán)  |
| `TextBox`        | Felhasználói szövegbevitelre             | `Text`, `Multiline`, `ReadOnly`       | `TextChanged`   |
| `Button`         | Akciók indítására                       | `Text`, `Enabled`                       | `Click`         |
| `CheckBox`       | Be-/Kikapcsolható opció                 | `Text`, `Checked`                       | `CheckedChanged`|
| `RadioButton`    | Egy opció kiválasztása egy csoportból     | `Text`, `Checked`                       | `CheckedChanged`|
| `ComboBox`       | Legördülő lista                         | `Items`, `Text`, `SelectedIndex`, `SelectedItem` | `SelectedIndexChanged` |
| `ListBox`        | Lista elemek megjelenítésére             | `Items`, `SelectedIndex`, `SelectedItem`| `SelectedIndexChanged` |
| `PictureBox`     | Képek megjelenítésére                   | `Image`, `SizeMode`                   | `Click`         |
| `Timer`          | Időzített események kiváltására           | `Interval`, `Enabled`                 | `Tick`          |
| `MenuStrip`      | Főmenü létrehozására                     | `Items`                               | Menüelem `Click`|
| `StatusStrip`    | Állapotsor megjelenítésére                | `Items` (pl. `ToolStripStatusLabel`) | N/A             |
| `GroupBox`       | Vezérlők csoportosítására               | `Text`                                | N/A             |
| `Panel`          | Vezérlők csoportosítására (keret nélkül) | `BorderStyle`                         | N/A             |
| `DataGridView`   | Táblázatos adatok megjelenítésére       | `DataSource`, `Columns`                | `CellClick`     |

### 3.1. Vezérlők Tulajdonságainak Módosítása

-   **Tervező nézetben**: Válaszd ki a vezérlőt, majd a Properties Window-ban módosítsd az értékeket.
-   **Kódból**: Hivatkozz a vezérlő `Name` tulajdonságán keresztül.
    ```csharp
    // Form1.cs
    private void Form1_Load(object sender, EventArgs e)
    {
        label1.Text = "Hello WinForms!";
        textBox1.Text = "Írj ide...";
        button1.Enabled = false;
    }
    ```

## 4. Eseménykezelés (Events)

A felhasználói interakciókra (pl. gombnyomás, szövegváltozás) vagy rendszereseményekre adott válasz.

### 4.1. Eseménykezelő Létrehozása

1.  **Tervező nézetben**:
    *   Válaszd ki a vezérlőt.
    *   A Properties Window-ban kattints a villám ikonra (Events).
    *   Dupla kattintás a kívánt esemény nevére (pl. `Click` a `Button`-nál). Visual Studio automatikusan létrehozza az eseménykezelő metódust és hozzárendeli.
2.  **Kódból (ritkábban)**:
    ```csharp
    // Form konstruktorában vagy Load eseményében
    this.myButton.Click += new System.EventHandler(this.myButton_Click);

    // ... majd a metódus implementációja
    private void myButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Gombra kattintottál!");
    }
    ```

### 4.2. `sender` és `EventArgs`

-   `sender`: Az az objektum, amelyik kiváltotta az eseményt (pl. a megnyomott `Button`). Típuskényszerítéssel (`(Button)sender`) hozzáférhetsz a specifikus tulajdonságaihoz.
-   `e`: Az eseményhez kapcsolódó adatokat tartalmazza. Típusa az eseménytől függ (pl. `MouseEventArgs` a `MouseClick` eseménynél, ami tartalmazza az egér pozícióját).

```csharp
// Gomb kattintás eseménykezelője
private void submitButton_Click(object sender, EventArgs e)
{
    MessageBox.Show($"A '{((Button)sender).Text}' gombot nyomtad meg!");
    string userInput = nameTextBox.Text;
    if (!string.IsNullOrEmpty(userInput))
    {
        greetingLabel.Text = $"Üdv, {userInput}!";
    }
    else
    {
        MessageBox.Show("Kérlek, add meg a neved!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

## 5. Dialógusablakok (Dialogs)

Előre definiált ablakok speciális célokra.

-   **`MessageBox.Show()`**: Egyszerű üzenetek, figyelmeztetések, kérdések megjelenítésére.
    ```csharp
    // Információs üzenet
    MessageBox.Show("A művelet sikeres volt.", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);

    // Kérdés
    DialogResult result = MessageBox.Show("Biztosan törli?", "Megerősítés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
    if (result == DialogResult.Yes)
    {
        // Törlés...
    }
    ```
-   **`OpenFileDialog`**: Fájl megnyitása dialógus.
    ```csharp
    using (OpenFileDialog openFileDialog = new OpenFileDialog())
    {
        openFileDialog.Filter = "Szöveges fájlok (*.txt)|*.txt|Minden fájl (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string filePath = openFileDialog.FileName;
            // Fájl feldolgozása...
            textBoxFileContent.Text = System.IO.File.ReadAllText(filePath);
        }
    }
    ```
-   **`SaveFileDialog`**: Fájl mentése dialógus.
-   **`FolderBrowserDialog`**: Mappa kiválasztása dialógus.
-   **`ColorDialog`**: Színválasztó dialógus.
-   **`FontDialog`**: Betűtípus választó dialógus.

Minden dialógusnál a `.ShowDialog()` metódus jeleníti meg az ablakot, és `DialogResult` típussal tér vissza (pl. `OK`, `Cancel`).

## 6. Elrendezés (Layout)

Vezérlők pozicionálása és méretezése az ablak átméretezésekor.

-   **`Anchor`**: Rögzíti a vezérlő éleit a tartalmazó konténer (pl. Form) éleihez. Ha a konténer mérete változik, a rögzített távolságok megmaradnak.
-   **`Dock`**: A vezérlőt a tartalmazó konténer egyik oldalához (Top, Bottom, Left, Right) vagy a teljes rendelkezésre álló területhez (Fill) igazítja.
-   **`FlowLayoutPanel`**: A vezérlőket sorban vagy oszlopban rendezi, automatikusan tördelve, ha szükséges.
-   **`TableLayoutPanel`**: Rácsos elrendezést biztosít, sorokkal és oszlopokkal, cellákba helyezve a vezérlőket.

## 7. Navigáció Formok Között

### 7.1. Új Form Megjelenítése

```csharp
// Új form példányosítása
OtherForm otherForm = new OtherForm();

// Modális megjelenítés (blokkolja az előző formot)
otherForm.ShowDialog();

// Nem-modális megjelenítés (nem blokkolja)
// otherForm.Show();
```

### 7.2. Adatátadás Formok Között

1.  **Konstruktoron keresztül**:
    ```csharp
    // OtherForm.cs
    public OtherForm(string data)
    {
        InitializeComponent();
        labelData.Text = data;
    }

    // Form1.cs
    OtherForm otherForm = new OtherForm("Átadott adat");
    otherForm.ShowDialog();
    ```
2.  **Publikus tulajdonságon keresztül**:
    ```csharp
    // OtherForm.cs
    public string DisplayText { get; set; }
    private void OtherForm_Load(object sender, EventArgs e)
    {
        labelData.Text = DisplayText;
    }

    // Form1.cs
    OtherForm otherForm = new OtherForm();
    otherForm.DisplayText = "Másik adat";
    otherForm.ShowDialog();
    ```

## 8. Adatkötés (Data Binding)

Vezérlők tulajdonságainak összekötése adatforrásokkal (pl. objektumok, listák).

Egyszerű példa: `TextBox` `Text` tulajdonságának kötése egy objektum tulajdonságához.
```csharp
public class Person { public string Name { get; set; } }

// Form_Load-ban:
Person myPerson = new Person { Name = "Példa Béla" };
textBoxName.DataBindings.Add("Text", myPerson, "Name");
```
A `DataGridView` gyakran használ `DataSource` tulajdonságot listák vagy táblák megjelenítésére.

## 9. Hasznos Tippek

-   **`this` kulcsszó**: Az aktuális Form példányra hivatkozik.
-   **Nevezési Konvenciók**: Használj beszédes neveket a vezérlőkhöz (pl. `nameTextBox`, `submitButton`).
-   **Resources**: Képeket, ikonokat, stringeket érdemes a projekt erőforrásfájljaiban tárolni a könnyebb kezelhetőség érdekében.
-   **UI Thread**: A felhasználói felületet módosító műveleteknek mindig a fő UI szálon kell futniuk. Ha háttérszálról akarsz UI-t frissíteni, használd a `Control.Invoke` vagy `Control.BeginInvoke` metódusokat.
-   **Hiba Kezelés**: `try-catch` blokkok használata a felhasználói élmény javítására és az alkalmazás stabilitásának növelésére.

