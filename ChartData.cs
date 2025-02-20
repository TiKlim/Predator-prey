using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView.Painting;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;

namespace PredatorPrey2
{
    internal class ChartData
    {
        // Статические переменные, которые представляют параметры модели
        private static double alphaValue;
        private static double betaValue;
        private static double epsilonValue;
        private static double omegaValue;
        private static double preyCountValue1;
        private static double predatorCountValue1;
        private static double preyCountValue2;
        private static double predatorCountValue2;
        private static double preyCountValue3;
        private static double predatorCountValue3;
        private static List<double> preyList = new();
        private static List<double> predatorList = new();

        private List<ObservablePoint> values = new();


        // Свойства, через которые другим частям программы можно получить доступ к значениям параметров модели
        public double Alpha => alphaValue;
        public double Beta => betaValue;
        public double Epsilon => epsilonValue;
        public double Omega => omegaValue;
        public double PreyQuantity1 => preyCountValue1;
        public double PredatorQuantity1 => predatorCountValue1;
        public double PreyQuantity2 => preyCountValue2;
        public double PredatorQuantity2 => predatorCountValue2;
        public double PreyQuantity3 => preyCountValue3;
        public double PredatorQuantity3 => predatorCountValue3;

        // Конструктор и инициализация статичесикх переменных в нём
        public ChartData(double alpha, double beta, double epsilon, double omega, double preyCount1, double predatorCount1, double preyCount2, double predatorCount2, double preyCount3, double predatorCount3)
        {
            alphaValue = alpha;
            betaValue = beta;
            epsilonValue = epsilon;
            omegaValue = omega;
            preyCountValue1 = preyCount1;
            predatorCountValue1 = predatorCount1;
            preyCountValue2 = preyCount2;
            predatorCountValue2 = predatorCount2;
            preyCountValue3 = preyCount3;
            predatorCountValue3 = predatorCount3;

            Phase = [
                new LineSeries<ObservablePoint>
                {
                    Values = InitializePhaze(),
                    Stroke = new SolidColorPaint(new SKColor(33, 150, 243), 4),
                    Fill = null,
                    GeometrySize = 0
                }
            ];

            InitializeGraph();

            Graph = [
                new LineSeries<double> { Values = preyList },
                new LineSeries<double> { Values = predatorList }
            ];
        }

        // Массивы ISeries, которые содержат данные для графиков
        public ISeries[] Phase { get; set; } =
            [
                new LineSeries<ObservablePoint>{}
            ];
        public ISeries[] Graph { get; set; } =
            [
                new LineSeries<ObservablePoint>{}
            ];


        private void PointsInserting(double quantityPrey, double quantityPred)
        {
            // Список с начальными значениями жертв и хищников
            List<ObservablePoint> chartGeneration = new();

            chartGeneration.Add(new ObservablePoint()
            {
                X = quantityPrey,
                Y = quantityPred
            });

            // Рассчёт новых значений
            for (int i = 0; i < 150; i++)
            {
                double preyCountFirst = Math.Round((double)((epsilonValue - alphaValue * chartGeneration[i].Y) * chartGeneration[i].X + chartGeneration[i].X), 2);
                chartGeneration.Add(new ObservablePoint()
                {
                    X = preyCountFirst,
                    Y = Math.Round((double)((omegaValue * preyCountFirst - betaValue) * chartGeneration[i].Y + chartGeneration[i].Y), 2)
                });
            }

            // Добавляем сгенерированные значения в список для построения графиков
            values.AddRange(chartGeneration);
        }

        // Инициализация графика №1
        private List<ObservablePoint> InitializePhaze()
        {
            values.Clear();

            PointsInserting(preyCountValue1, predatorCountValue1);
            PointsInserting(preyCountValue2, predatorCountValue2);
            PointsInserting(preyCountValue3, predatorCountValue3);
            return values;
        }

        // Инициализация графика №2
        private void InitializeGraph()
        {
            predatorList.Clear();
            preyList.Clear();
            foreach (ObservablePoint point in values)
            {
                preyList.Add((double)point.X);
                predatorList.Add((double)point.Y);
            }
        }
    }
}