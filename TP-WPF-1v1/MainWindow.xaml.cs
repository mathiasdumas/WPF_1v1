using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TP_WPF_1v1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Opponent Raton { get; set; }
        public Opponent Roger { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            Raton = new Opponent("Le roi des ratons maudit");
            Roger = new Opponent("Roger, le gardien du parc");
            DataContext = this;
        
        }

        private void Raton_Attack_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SomeoneIsDead())
            {
                result.Text = "Le combat est terminé !";
            } else
            {
                Roger.HealthPoints -= 10;
                if (!IsDead(Roger))
                {
                    botte.Visibility = Visibility.Hidden;
                    result.Text = "Raton griffe Roger !";
                    griffe.Visibility = Visibility.Visible;
                }
                else
                {
                    result.Text = "Roger est MORT !";
                }
            }       
        }

        private void Roger_Attack_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SomeoneIsDead())
            {
                result.Text = "Le combat est terminé !";
            }
            else
            {
                Raton.HealthPoints -= 10;
                if (!IsDead(Raton))
                {
                    griffe.Visibility = Visibility.Hidden;
                    result.Text = "Roger savate Raton !";
                    botte.Visibility = Visibility.Visible;
                }
                else
                {
                    result.Text = "Raton est MORT !";
                }
            }
            
        }

        private bool IsDead(Opponent opponent)
        {
            return opponent.HealthPoints <= 0;
        }

        private bool SomeoneIsDead()
        {
            return Raton.HealthPoints <= 0 || Roger.HealthPoints <= 0;
        }
    }
}