﻿using Controller;
using Model;
using Model.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace Gestion_AcademicoAdministrativa_Abastos
{
    /// <summary>
    /// Lógica de interacción para BuscadorV2.xaml
    /// </summary>
    public partial class BuscadorV2 : Window
    {
        public List<object> UserRoleList { get; set; }
        public List<object> ContainerList { get; set; }
        public int SelectedIndex { get; set; }
        public int Step { get; set; }

        public BuscadorV2()
        {
            UserRoleList = new List<dynamic>();
            Step = 15;
            InitializeComponent();
            var selectedView = XamlBridge.ViewEnum;
            if (selectedView.Equals(ViewsEnum.PROFESOR))
            {
                ContainerList = DataRetriever.GetInstance().GetListByUser(selectedView, XamlBridge.CurrentUser.Persona1.Trabajador.Profesor).ToList();
            }
            else
            {
                ContainerList = DataRetriever.GetInstance().GetListByUser(selectedView).ToList();
            }
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            TxtStep.Text = Step.ToString();
            Console.WriteLine(Step);
            var joiner = Constants.StringJoiner;
            var currentUserPerson = XamlBridge.CurrentUser.Persona1;

            var name = TxtSearch.Text;
            var ignoreMayus = IgnoreMayus.IsChecked;
            var exactMatch = ExactMatch.IsChecked;

            var saved = ContainerList
                .Cast<dynamic>();
                //.Where(person => DataIntegrityChecker.FullyCheckIfContainsString(person.Nombre, name, ignoreMayus, exactMatch));

            UserRoleList.Clear();
            foreach (var savedItem in saved)
            {
                Console.WriteLine(savedItem);
                UserRoleList.Add(savedItem);
            }

            LabelNumRows.Content = UserRoleList.Count;

            LoadPageData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var correcto = false;
            if (sender == ButtonPrevious)
            {
                correcto = SelectedIndex > 0;
                if (correcto)
                {
                    SelectedIndex--;
                }
            }
            else if (sender == ButtonNext)
            {
                correcto = (SelectedIndex * Step) < UserRoleList.Count - Step;
                if (correcto)
                {
                    SelectedIndex++;
                }
            }
            if (correcto)
            {
                LoadPageData();
            }
        }

        private void LoadPageData()
        {
            var startIndex = SelectedIndex * Step;
            LabelStartIndex.Content = startIndex;
            var endIndex = startIndex + Step;
            LabelEndIndex.Content = endIndex;

            XamlFunctionality.FillDataGrid(DataGridResult, UserRoleList
                .Where((elemn, index) => index >= startIndex && index < endIndex)
                .ToList());
        }

        private void TxtStep_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Constants.RegexOnlyNumber.IsMatch(e.Text);
        }

        private void TxtStep_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox senderAsTextBox)
            {
                var content = senderAsTextBox.Text;
                if (!content.Equals(string.Empty))
                {
                    var parsedValue = int.Parse(content);
                    Step = parsedValue;
                    if (parsedValue > 0)
                    {
                        var count = UserRoleList.Count - 1;
                        var indexWithParsedValue = SelectedIndex * parsedValue;
                        if (indexWithParsedValue >= count)
                        {
                            var fixedValue = (count / parsedValue) - 1;
                            SelectedIndex = fixedValue;
                        }
                    }
                    LoadPageData();
                }
            }
        }

        private void QueryEntry_Click(object sender, RoutedEventArgs e)
        {
            Notification.CreateNotificaion(sender.GetType().ToString());
        }
    }
}
