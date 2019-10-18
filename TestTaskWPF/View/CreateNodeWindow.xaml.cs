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
using TestTaskWPF.Models;

namespace TestTaskWPF.View
{
    /// <summary>
    /// Логика взаимодействия для CreateNodeWindow.xaml
    /// </summary>
    public partial class CreateNodeWindow : Window
    {

        TaskNode task = new TaskNode();

        public TaskNode TaskNode { get; set; }

        public event EventHandler TaskPropertyChanged;


        bool start = false;
        bool finish = false;

        public CreateNodeWindow()
        {
            InitializeComponent();
            this.DataContext = task;        
        }


        protected void OnTaskPropertyChanged()
        {
            TaskPropertyChanged?.Invoke(this, EventArgs.Empty);
        }


        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

            if(task.Title==null || task.Title == "")
            {
                MessageBox.Show("Не заполнен заголовок!");
                return;
            }


            int count_status = 0;

            foreach (CheckBox chbox in FindVisualChildren<CheckBox>(ChboxList))
            {
                if (chbox.IsChecked == false)
                {
                    count_status++;
                }
               
            }

            if (count_status == 3)
            {
                MessageBox.Show("Не выбрано состояние задачи!");
                
            }

            else
            {
                if (!start)
                {
                    task.DateStart = (DateTime)Start.DisplayDate.Date;
                }
                if (!finish)
                {
                    task.DateFinish = (DateTime)End.DisplayDate.Date;
                }

                DateTime date = DateTime.Now;
                task.DateCreate = date;


                TaskNode = task;
            

                OnTaskPropertyChanged();
            }       
        }

        private void Start_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = Start.SelectedDate;
            task.DateStart = selectedDate.Value.Date;

            start = true;     
        }

        private void End_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime? selectedDate = End.SelectedDate;
            task.DateFinish = selectedDate.Value.Date;
            finish = true;        
        }

        private void ChboxStart_Checked_1(object sender, RoutedEventArgs e)
        {
            task.IsStart = true;
            ChboxFinish.IsChecked = false;
            ChboxProgress.IsChecked = false;
        }

        private void ChboxProgress_Checked(object sender, RoutedEventArgs e)
        {
            task.IsProgress = true;
            ChboxFinish.IsChecked = false;
            ChboxStart.IsChecked = false;
        }

        private void ChboxFinish_Checked(object sender, RoutedEventArgs e)
        {
            task.IsFinish = true;
            ChboxStart.IsChecked = false;
            ChboxProgress.IsChecked = false;

            DateTime date = DateTime.Now;
            task.DateFinish = date.Date;
        }
    
        // возвращает коллекцию заданных для поиска children
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

       
    }
}
