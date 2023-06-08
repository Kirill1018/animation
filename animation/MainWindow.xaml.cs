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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace animation
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        DoubleAnimation DoubleAnimation, animation, animate;//объекты анимации
        Storyboard Storyboard;
        TransformGroup TransformGroup;
        RotateTransform RotateTransform;
        ScaleTransform ScaleTransform;
        private void flashing_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation = new DoubleAnimation();
            DoubleAnimation.From = 1.0;
            DoubleAnimation.To = 0.0;//прозрачность
            DoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            DoubleAnimation.AutoReverse = true;
            Storyboard = new Storyboard();
            Storyboard.Children.Add(DoubleAnimation);
            Storyboard.SetTargetProperty(DoubleAnimation, new PropertyPath("(MediaElement.Opacity)"));
            Storyboard.SetTarget(DoubleAnimation, MediaElement);
            Storyboard.Begin();
        }

        private void pulsation_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation = new DoubleAnimation();
            DoubleAnimation.From = 300;
            DoubleAnimation.To = 150;
            DoubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            DoubleAnimation.AutoReverse = true;
            Storyboard = new Storyboard();
            Storyboard.Children.Add(DoubleAnimation);
            Storyboard.SetTargetProperty(DoubleAnimation, new PropertyPath("(MediaElement.Width)"));
            Storyboard.SetTarget(DoubleAnimation, MediaElement);
            Storyboard.Begin();
        }

        private void rotation_Click(object sender, RoutedEventArgs e)
        {
            double cent_x = MediaElement.ActualWidth / 2, cent_y = MediaElement.ActualHeight / 2, time = 2, scale_from = 1, scale_to = 4;//действительные ширина и высота, количество анимаций и масштаб
            TransformGroup = new TransformGroup();
            RotateTransform = new RotateTransform()
            {
                CenterX = cent_x,
                CenterY = cent_y
            };
            TransformGroup.Children.Add(RotateTransform);
            ScaleTransform = new ScaleTransform()
            {
                CenterX = cent_x,
                CenterY = cent_y
            };
            TransformGroup.Children.Add(ScaleTransform);
            DoubleAnimation = new DoubleAnimation
            {
                From = 0,//исходное положение
                To = 720,
                Duration = TimeSpan.FromSeconds(time)
            };
            RotateTransform.BeginAnimation(RotateTransform.AngleProperty, DoubleAnimation);
            animation = new DoubleAnimation()
            {
                From = scale_from,
                To = scale_to,
                Duration = TimeSpan.FromSeconds(time / 2),
                AutoReverse = true
            };
            ScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, animation);
            animate = new DoubleAnimation
            {
                From = scale_from,
                To = scale_to,
                Duration = TimeSpan.FromSeconds(time / 2),
                AutoReverse = true
            };
            ScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animate);
        }

        private void pendulum_Click(object sender, RoutedEventArgs e)
        {

        }

        private void flattening_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}