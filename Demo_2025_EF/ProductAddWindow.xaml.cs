// Подключаем модели вашего проекта (Entity Framework): DemoContext, ProductType и др.
using Demo_2025_EF.Models;

// Базовые пространства имён .NET
using System;                            // Общие типы (DateTime, Exception и т.п.) — здесь напрямую не используется
using System.Collections.Generic;        // Коллекции (List<T> и т.п.) — здесь напрямую не используется
using System.Linq;                       // LINQ: ToList(), Where(), Select() — используется для ToList()
using System.Text;                       // Работа со строками — здесь не используется
using System.Threading.Tasks;            // Асинхронность — здесь не используется

// WPF пространства имён
using System.Windows;                    // Window, RoutedEventArgs, DialogResult и т.п.
using System.Windows.Controls;           // Контролы WPF (ComboBox/ListBox/Button и т.п.)
using System.Windows.Data;               // Binding (привязки) — здесь напрямую не используется
using System.Windows.Documents;          // Документы WPF — не используется
using System.Windows.Input;              // Ввод/команды — не используется
using System.Windows.Media;              // Цвета/кисти — не используется
using System.Windows.Media.Imaging;      // Картинки — не используется
using System.Windows.Shapes;             // Фигуры — не используется

namespace Demo_2025_EF
{
    /// <summary>
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// Этот комментарий создаётся автоматически: окно добавления продукта (форма ввода).
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        // Создаём контекст базы данных.
        // Он нужен здесь, чтобы получить список типов продуктов (ProductTypes) для выбора в UI.
        //
        // ⚠ Важно:
        // Здесь создаётся НОВЫЙ контекст, отдельный от контекста в MainWindow.
        //    Это нормально для чтения справочника (типы), но если бы вы тут сохраняли Product,
        //    то могли бы возникать проблемы с отслеживанием сущностей в разных DbContext.

        DemoContext db = new DemoContext();

        public ProductAddWindow()
        {
            // Загружаем элементы интерфейса из XAML: создаём контролы и привязки.
            InitializeComponent();

            // Заполняем элемент управления ListType (скорее всего ComboBox или ListBox)
            // данными из таблицы ProductTypes.
            //
            // db.ProductTypes — DbSet<ProductType> (таблица типов товаров)
            // ToList() выполняет запрос к базе данных ПРЯМО СЕЙЧАС и возвращает обычный List<ProductType>.
            //
            // ItemsSource — источник элементов для списка/комбобокса.
            // После этой строки пользователь увидит список типов и сможет выбрать один из них.
            //
            // ⚠ Почему ToList() здесь важен:
            // - Без ToList() это был бы IQueryable, и запрос мог бы выполниться позже
            //   (например, когда UI попытается перечислить элементы). С ToList() вы явно
            //   выполняете запрос сразу в конструкторе окна.
            //
            // ⚠ Потенциальный нюанс UX:
            // - Если типов очень много или БД медленная, окно может открываться заметно дольше.
            //   Тогда лучше делать асинхронную загрузку (await db.ProductTypes.ToListAsync()).
            ListType.ItemsSource = db.ProductTypes.ToList();
        }

        // Обработчик кнопки "Добавить" / "ОК" (скорее всего пользователь подтвердил ввод данных).
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // DialogResult используется ТОЛЬКО у модальных окон (показанных через ShowDialog()).
            //
            // Установка DialogResult = true:
            // - автоматически закрывает окно
            // - возвращает в вызывающий код (MainWindow) значение true из ShowDialog()
            //
            // Именно поэтому в MainWindow есть проверка:
            // if (w.ShowDialog() == true) { ... }
            //
            // Важно: здесь мы НЕ сохраняем продукт в БД.
            // Мы просто говорим: "пользователь нажал ОК, считаем данные валидными/подтверждёнными".
            // Сам объект Product заполняется через DataContext и привязки в XAML.
            DialogResult = true;
        }
    }
}
