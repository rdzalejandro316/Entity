using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {

                using (var a = new SDXCatering_Emp010Entities())
                {
                    var query = (from st in a.CtMae_Empleados
                                     //where st.EmpleadoCodigo == "1033796537"
                                 select st).Take(5);

                    //var o = a.CtMae_Empleados.SqlQuery("select * From CtMae_Empleados where EmpleadoCodigo='1033796537'");

                    foreach (var item in query)
                    {
                        //MessageBox.Show(item.EmpleadoCodigo);
                        //MessageBox.Show(item.EmpleadoNombres);
                    }
                    gridA.ItemsSource = query.ToList();
                    //a.CtMae_Empleados.Local.ToBindingList();

                    //MessageBox.Show(o.ToString());
                }

            }
            catch (Exception w)
            {
                MessageBox.Show("e44o4:" + w);
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var empleado = (CtMae_Empleados)gridA.SelectedItem;
                //MessageBox.Show(a.EmpleadoCodigo);
                //empleado.EmpleadoNombres = "cambiado";
                using (var context = new SDXCatering_Emp010Entities())
                {
                    context.Entry(empleado).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                    load();
                }
            }
            catch (Exception w)
            {
                MessageBox.Show("error al actualizar:" + w);
            }

        }

        private void BtnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {                

                using (var context = new SDXCatering_Emp010Entities())
                {
                    var empleado = new CtMae_Empleados
                    {
                        Cedula = "4",
                        EmpleadoCodigo = "4",
                        EmpleadoNombres = "otro empleado",
                        EmpleadoApellidos = "otro empleado",
                        EmpresaCodigo = "1307",
                        PuntoVentaCodigo= "03",
                        CargoId = 1
                    };

                    context.CtMae_Empleados.Add(empleado);
                    context.SaveChanges();
                    load();
                }                

            }
            catch (Exception w)
            {
                MessageBox.Show("error al insertar:" + w);
            }
        }

        private void BtnDelte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new SDXCatering_Emp010Entities())
                {
                    var empleado = (CtMae_Empleados)gridA.SelectedItem;
                    //context.CtMae_Empleados.Remove(empleado);
                    context.Entry(empleado).State = System.Data.Entity.EntityState.Deleted;
                    context.SaveChanges();
                    load();
                }
            }
            catch (Exception w)
            {

                MessageBox.Show("error al eliminar:" + w);
            }
        }

        private void BtnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                load();
            }
            catch (Exception w)
            {
                MessageBox.Show("error al realizar el select:" + w);
            }
        }


        public void load()
        {
            try
            {
                using (var a = new SDXCatering_Emp010Entities())
                {
                    var query = (from st in a.CtMae_Empleados
                                 select st).Take(5);
                    
                    gridA.ItemsSource = query.ToList();
                }
            }
            catch (Exception w)
            {
                MessageBox.Show("error al cargar:"+w);
            }
        }


    }
}
