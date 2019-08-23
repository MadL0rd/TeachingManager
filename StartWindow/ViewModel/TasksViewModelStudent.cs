using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;

namespace StartWindow.ViewModel
{
    class TasksViewModelStudent : DependencyObject
    {
        private static string id;

        public static void SetUsrID(string IDBuff)
        {
            id = IDBuff;
        }
        public static ICollectionView TaskFilesViewBuff;
        public string SubjectFilter
        {
            get { return (string)GetValue(SubjectFilterProperty); }
            set { SetValue(SubjectFilterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SubjectFilterProperty =
            DependencyProperty.Register("SubjectFilter", typeof(string), typeof(TasksViewModelStudent), new PropertyMetadata("", FilterTextChanged));
        public  ICollectionView Items
        {
            get { return (ICollectionView)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(ICollectionView), typeof(TasksViewModelStudent), new PropertyMetadata(null));
        public ICollectionView ItemsUsrSubjects
        {
            get { return (ICollectionView)GetValue(UsrSubjectsProperty); }
            set { SetValue(UsrSubjectsProperty, value); }
        }
        public static readonly DependencyProperty UsrSubjectsProperty =
            DependencyProperty.Register("UsrSubjectsProperty", typeof(ICollectionView), typeof(TasksViewModelStudent), new PropertyMetadata(null));

        public ICollectionView ItemsAnswerFiles
        {
            get { return (ICollectionView)GetValue(ItemsAnswerFilesProperty); }
            set { SetValue(ItemsAnswerFilesProperty, value); }
        }
        public static readonly DependencyProperty ItemsAnswerFilesProperty =
            DependencyProperty.Register("ItemsAnswerFilesProperty", typeof(ICollectionView), typeof(TasksViewModel), new PropertyMetadata(null));

        public ICollectionView ItemAnswer
        {
            get { return (ICollectionView)GetValue(ItemAnswerProperty); }
            set { SetValue(ItemAnswerProperty, value); }
        }
        public static DependencyProperty ItemAnswerProperty =
            DependencyProperty.Register("ItemAnswerProperty", typeof(ICollectionView), typeof(TasksViewModelStudent), new PropertyMetadata(null));



        public TasksViewModelStudent()
        {
            StartWindow.Data.StudentUsr.GetStudentUsr(id);
            Items = CollectionViewSource.GetDefaultView(StartWindow.Data.Tasks.GetTasks());
            Items.Filter = FilterTasks;
            ItemsUsrSubjects = CollectionViewSource.GetDefaultView(StartWindow.Data.StudentUsr.Subjects);
            ItemsAnswerFiles = CollectionViewSource.GetDefaultView(StartWindow.Data.NewTaskAnswer.AnswerFiles);
            TaskFilesViewBuff = ItemsAnswerFiles;


        }

        bool FilterTasks(object obj)
        {
            bool result = true;
            StartWindow.Data.Tasks current = obj as StartWindow.Data.Tasks;
            if(current== null)
            {
                result = false;
            }
            if (current.SchoolID != Data.StudentUsr.SchoolID)
            {
                result = false;
            }
            if (current.KlassID != Data.StudentUsr.KlassID)
            {
                result = false;
            }
            if (SubjectFilter!="" && current.Subject != SubjectFilter)
            {
                result = false;
            }
            return result;
        }

        private static void FilterTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as TasksViewModelStudent;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterTasks;
            }
        }
    }
}
