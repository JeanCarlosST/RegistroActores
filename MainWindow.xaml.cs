using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;

namespace RegistroActores
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Actor actor;
        public MainWindow()
        {
            InitializeComponent();
            actor = new Actor();
            this.DataContext = actor;
        }

        private void BuscarButton_Click(object render, RoutedEventArgs e){
            
            Context context = new Context();

            var found = context.Actors.Find(Convert.ToInt32(ActorIDTextBox.Text));

            if(found != null){
                actor = found;
                NombresTextBox.Text = actor.Nombres;
                SalariosTextBox.Text = Convert.ToString(actor.Salario);
            }   

            context.Dispose();
        }
        public void GuardarButton_Click(object render, RoutedEventArgs e){
            
            Context context = new Context();

            actor.Nombres = NombresTextBox.Text;
            actor.Salario = Convert.ToDecimal(SalariosTextBox.Text);

            context.Actors.Add(actor);
           
            int changes = context.SaveChanges();

            if(changes > 0)
            {
                MessageBox.Show("Guardado");
            }

            NombresTextBox.Text = "";
            SalariosTextBox.Text = "";

            context.Dispose();
        }
    }

}
