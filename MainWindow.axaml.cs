using Avalonia.Controls;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Drawing.Geometries;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PredatorPrey2
{
    public partial class MainWindow : Window
    {
        // Тестовые значения
        private static ChartData chartChart = new ChartData(0.65, 0.011, 0.007, 0.2, 100, 90, 100, 60, 100, 30);

        // Конструктор
        public MainWindow()
        {
            InitializeComponent();
            getStarted.Click += GetStarted_Click;
            back.Click += Back_Click;
            gridData.DataContext = chartChart;
            eTB.KeyUp += ETB_KeyUp;
            aTB.KeyUp += ATB_KeyUp;
            BTB.KeyUp += BTB_KeyUp;
            bTB.KeyUp += BTB_KeyUp1;
            x01TB.KeyUp += X01TB_KeyUp;
            y01TB.KeyUp += Y01TB_KeyUp;
            x02TB.KeyUp += X02TB_KeyUp;
            y02TB.KeyUp += Y02TB_KeyUp;
            x03TB.KeyUp += X03TB_KeyUp;
            y03TB.KeyUp += Y03TB_KeyUp;
        }

        // Определение 
        private void Y03TB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void X03TB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void Y02TB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void X02TB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void Y01TB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void X01TB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void BTB_KeyUp1(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void BTB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void ATB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        private void ETB_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e) => SetData();

        // Загрузка данных, введённых пользователем и их обработка
        private void SetData()
        {
            try
            {
                ChartData chartData = new ChartData(Convert.ToDouble(aTB.Text), 
                    Convert.ToDouble(BTB.Text), 
                    Convert.ToDouble(eTB.Text), 
                    Convert.ToDouble(bTB.Text),
                    Convert.ToDouble(x01TB.Text), 
                    Convert.ToDouble(y01TB.Text),
                    Convert.ToDouble(x02TB.Text), 
                    Convert.ToDouble(y02TB.Text),
                    Convert.ToDouble(x03TB.Text), 
                    Convert.ToDouble(y03TB.Text));
                gridData.DataContext = chartData;

            }
            catch 
            {
                warning.IsVisible = true;
            }
        }

        // Кнопки
        private void Back_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            mainBorder.IsVisible = true;
        } 

        private void GetStarted_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            mainBorder.IsVisible = false;
        }
    }
}