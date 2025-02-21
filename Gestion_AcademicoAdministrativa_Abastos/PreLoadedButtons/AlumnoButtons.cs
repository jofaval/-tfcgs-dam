﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Gestion_AcademicoAdministrativa_Abastos.PreLoadedButtons
{
   public class AlumnoButtons
    {
        static public List<Button> CreateAlumnoView()
        {
            var buttonList = new List<Button>();

            var menuButtonStyle = (Style)Application.Current.Resources["MenuButton"];
            var numRow = 0;

            var HomeButton = new Button()
            {
                Name = "HomeButton",
                Content = "Home",
                Style = menuButtonStyle
            };
            buttonList.Add(HomeButton);
            Grid.SetRow(HomeButton, numRow);
            numRow++;

            var ChangePassButton = new Button()
            {
                Name = "ChangePassButton",
                Content = "Cambiar Contraseña",
                Style = menuButtonStyle
            };
            buttonList.Add(ChangePassButton);
            Grid.SetRow(ChangePassButton, numRow);
            numRow++;

            var FirstButton = new Button()
            {
                Name = "FirstButton",
                Content = "Buscador Profesorado",
                Style = menuButtonStyle
            };
            buttonList.Add(FirstButton);
            Grid.SetRow(FirstButton, numRow);
            numRow++;

            var SecondButton = new Button()
            {
                Name = "SecondButton",
                Content = "Horario",
                Style = menuButtonStyle
            };
            buttonList.Add(SecondButton);
            Grid.SetRow(SecondButton, numRow);
            numRow++;

            var ForthButton = new Button()
            {
                Name = "ForthButton",
                Content = "Reclamaciones",
                Style = menuButtonStyle
            };
            buttonList.Add(ForthButton);
            Grid.SetRow(ForthButton, numRow);
            numRow++;

            var NotasButton = new Button()
            {
                Name = "NotasButton",
                Content = "Calificaciones",
                Style = menuButtonStyle
            };
            buttonList.Add(NotasButton);
            Grid.SetRow(NotasButton, numRow);
            numRow++;

            var FifthButton = new Button()
            {
                Name = "FifthButton",
                Content = "Solicitudes",
                Style = menuButtonStyle
            };
            buttonList.Add(FifthButton);
            Grid.SetRow(FifthButton, numRow);
            numRow++;

            var LogOutButton = new Button()
            {
                Name = "LogOutButton",
                Content = "Salir",
                Style = menuButtonStyle
            };
            buttonList.Add(LogOutButton);
            Grid.SetRow(LogOutButton, numRow);
            numRow++;

            void AlumnoView_Click(object sender, RoutedEventArgs e)
            {
                if (sender is Button btnSender)
                {
                    var mainWindowPanel = XamlBridge.MainPanelInstance;
                    if (btnSender == FirstButton)
                    {
                        XamlFunctionality.ChangeWindowContent(mainWindowPanel, new BuscadorV2());
                    }
                    else if (btnSender == ChangePassButton)
                    {
                        var mainPanel = new ChangePassword().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                        XamlBridge.MainPanelInstance = mainPanel;
                    }
                    else if (btnSender == NotasButton)
                    {
                        var mainPanel = new Notas().MainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, mainPanel);

                        XamlBridge.MainPanelInstance = mainPanel;
                    }
                    else if (btnSender == SecondButton)
                    {
                        XamlFunctionality.ChangeWindowContent(mainWindowPanel, new Horario());
                    }
                    else if (btnSender == ForthButton)
                    {
                        XamlFunctionality.ChangeWindowContent(mainWindowPanel, new Reclamaciones());
                    }
                    else if (btnSender == FifthButton)
                    {
                        Notification.CreateNotification("Todavía no disponible. Lo sentimos");
                    }
                    else if (btnSender == HomeButton)
                    {
                        var backUpMainPanel = XamlBridge.BackUpMainPanel;

                        XamlFunctionality.ReplaceGrids(XamlBridge.MainPanelInstance, backUpMainPanel);

                        XamlBridge.MainPanelInstance = backUpMainPanel;
                    }
                    else if (btnSender == LogOutButton)
                    {
                        //XamlBridge.CloseEverything();
                        StaticButtonViews.LogOutFromMainWindow();
                    }
                }
            }

            foreach (var button in buttonList)
            {
                button.Click += new RoutedEventHandler(AlumnoView_Click);
            }

            return buttonList;
        }
    }
}
