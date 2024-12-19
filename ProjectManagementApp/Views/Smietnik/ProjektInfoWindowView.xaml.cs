﻿using ProjectManagementApp.Models.EntitiesForView;
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
using System.Windows.Shapes;

namespace ProjectManagementApp.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ProjektInfoWindowView.xaml
    /// </summary>
    public partial class ProjektInfoWindowView : Window
    {
        public ProjektInfoWindowView(string projectName, string projectDescription, List<RyzykaProjketuForAllView> risks)
        {
            InitializeComponent();
            ProjectNameText.Text = projectName;
            ProjectDescriptionText.Text = projectDescription;
            RisksDataGrid.ItemsSource = risks;

        }
    }
}