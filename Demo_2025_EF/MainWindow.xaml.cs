// Подключаем пространства имён (namespaces), чтобы использовать классы из нужных библиотек
using Demo_2025_EF.Models;               // Модели проекта (Entity Framework): DemoContext, Product, ProductType и т.д.
using System.Text;                       // Работа со строками/кодировками (в этом файле сейчас не используется, можно убрать)
using System.Windows;                    // Базовые типы WPF: Window, RoutedEventArgs, Application и т.п.
using System.Windows.Controls;           // WPF-контролы: Button, ListBox, DataGrid и т.п.
using System.Windows.Data;               // Привязка данных (Binding) (в этом файле напрямую не используется, но часто нужно)
using System.Windows.Documents;          // Документы WPF (FlowDocument и т.п.) (не используется здесь)
using System.Windows.Input;              // Обработка ввода (команды, клавиатура, мышь) (не используется здесь)
using System.Windows.Media;              // Работа с графикой/цветами/кистями (не используется здесь)
using System.Windows.Media.Imaging;      // Изображения WPF (BitmapImage и т.п.) (не используется здесь)
using System.Windows.Navigation;         // Навигация (Frame/NavigationService) (не используется здесь)
using System.Windows.Shapes;             // Фигуры (Rectangle, Ellipse) (не используется здесь)
using System.Collections.ObjectModel;    // ObservableCollection<T> — коллекция, уведомляющая UI об изменениях
using Microsoft.EntityFrameworkCore;     // Entity Framework Core: Include, Load, DbContext, Local и т.п.

namespace Demo_2025_EF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// (Авто-комментарий WPF) — описание окна и связанного XAML.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Создаём объект контекста базы данных (DbContext).
        // DemoContext — ваш класс контекста EF Core, который содержит DbSet<Product> Products и другие таблицы.


        DemoContext db = new DemoContext();

        // Коллекция продуктов, которая будет привязана к элементу интерфейса (ProductsList).
        // ObservableCollection уведомляет WPF UI, когда элементы добавляются/удаляются,
        // поэтому список на экране обновляется автоматически.
        ObservableCollection<Product> products = new ObservableCollection<Product>();

        public MainWindow()
        {
            // Инициализация компонентов окна из XAML:
            // - создаёт и размещает контролы
            // - применяет стили
            // - подключает обработчики событий, указанные в XAML
            InitializeComponent();

            // Загружаем из БД сущности Product, и одновременно подгружаем связанный объект ProductType.
            //
            // Include(t => t.ProductType) говорит EF: "при загрузке продуктов также подтяни связанный тип продукта"
            // Это решает проблему "ленивой" загрузки (lazy loading), если она не настроена,
            // и предотвращает ситуацию, когда ProductType == null или будет грузиться отдельными запросами.
            //
            // Load() выполняет запрос в БД и помещает результаты в локальный трекер контекста (ChangeTracker).
            db.Products.Include(t => t.ProductType).Load();

            // db.Products.Local — это локальное представление сущностей Product, которые сейчас
            // отслеживаются контекстом (загружены/добавлены/и т.д.).
            //
            // ToObservableCollection() создаёт ObservableCollection, привязанную к Local:
            // - она содержит те же объекты Product
            // - изменения в контексте (например, Add/Remove) отображаются в Local,
            //   а через ObservableCollection это отражается в UI.
            //
            // По сути: теперь products — это "живая" коллекция, связанная с EF.
            products = db.Products.Local.ToObservableCollection();

            // Привязываем нашу коллекцию products к ItemsSource элемента списка на форме.
            // ProductsList — это контрол из XAML (например, ListView / ListBox / DataGrid),
            // у которого есть свойство ItemsSource.
            //
            // После этого UI будет отображать все элементы products.
            // Когда вы добавите/удалите Product в products — интерфейс обновится автоматически.
            ProductsList.ItemsSource = products;
        }

        // Обработчик нажатия на кнопку "Добавить продукт"
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            // Создаём новый объект Product в памяти (пока он НЕ в базе данных)
            // В этот объект будут введены значения в окне добавления.
            Product p = new Product();

            // Создаём окно добавления продукта.
            // DataContext = p означает, что элементы управления внутри окна (TextBox, ComboBox и т.д.)
            // смогут делать привязку к свойствам Product (например: Name, Price, ProductTypeId).
            //
            // Важный момент:
            // - Когда пользователь заполняет поля, он фактически заполняет объект p.
            // - Если окно закрывается с DialogResult=true, считаем, что ввод успешен.
            ProductAddWindow w = new ProductAddWindow() { DataContext = p };

            // Альтернативный вариант записи (эквивалентно):
            // w.DataContext = p;

            // ShowDialog() показывает окно модально:
            // - пока оно открыто, нельзя взаимодействовать с MainWindow
            // - возвращает bool? (nullable bool):
            //   true  => окно закрыто с DialogResult = true (обычно кнопка "Сохранить"/"ОК")
            //   false => закрыто с DialogResult = false
            //   null  => закрыто без установки DialogResult (например, крестик)
            if (w.ShowDialog() == true)
            {
                // Добавляем продукт в observable-коллекцию, которая привязана к UI.
                // UI сразу обновится и покажет новый продукт.
                products.Add(p);

                // Сохраняем изменения в базе данных.
              
                db.SaveChanges();
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).DataContext is Product p)
            {
                ProductAddWindow w = new ProductAddWindow();
                w.DataContext = p;
                
                if (w.ShowDialog() == true)
                {
                    db.SaveChanges();
                }
                
            }
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).DataContext is Product p)
            {
                products.Remove(p);
                db.SaveChanges();
            }
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as StackPanel).DataContext is Product p)
            {
                ProductAddWindow w = new ProductAddWindow();
                w.DataContext = p;

                if (w.ShowDialog() == true)
                {
                    db.SaveChanges();
                }

            }
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            CalcWindow w = new CalcWindow();
            w.ShowDialog();
        }
    }
}
