using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace BevasarloLista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Elemek { get; set; } = new ObservableCollection<string>();
        private List<string> groceryItems = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(GroceryTextBox.Text))
            {
                Elemek.Add(GroceryTextBox.Text);
                GroceryListBox.ItemsSource = Elemek;
                GroceryTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter a grocery item.");
            }
        }

        private void KeyDownEnter(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Enter))
            {
                AddButton_Click(sender, e);
            }
        }

        private void DeleteEveryButton_Click(object sender, RoutedEventArgs e)
        {
            Elemek.Clear();
        }

        private void DeleteButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (GroceryListBox.SelectedItem is string item)
            {
                Elemek.Remove(item);
            }
        }
    }
}