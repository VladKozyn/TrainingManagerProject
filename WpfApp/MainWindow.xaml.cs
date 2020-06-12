using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using DomainLibrary;
using DomainLibrary.Domain;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        trainingDBEntities1 dataEntities = new trainingDBEntities1();
        public ObservableCollection<Grid> GridCollection { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            foreach(CyclingSession Cs in dataEntities.CyclingSessions)
            {
                dataGrid1.Items.Add(Cs);
            }
            foreach (RunningSession Rs in dataEntities.RunningSessions)
            {
                dataGrid2.Items.Add(Rs);
            }
        }

    }


}