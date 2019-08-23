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
    class TasksViewModel : DependencyObject
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
            DependencyProperty.Register("SubjectFilter", typeof(string), typeof(TasksViewModel), new PropertyMetadata("", FilterTextChanged));
        public string KlassFilter
        {
            get { return (string)GetValue(KlassFilterProperty); }
            set { SetValue(KlassFilterProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FilterText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KlassFilterProperty =
            DependencyProperty.Register("KlassFilter", typeof(string), typeof(TasksViewModel), new PropertyMetadata("", FilterTextChanged));


        public  ICollectionView Items
        {
            get { return (ICollectionView)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(ICollectionView), typeof(TasksViewModel), new PropertyMetadata(null));
        public ICollectionView ItemsUsrKlass
        {
            get { return (ICollectionView)GetValue(UsrKlassProperty); }
            set { SetValue(UsrKlassProperty, value); }
        }
        public static readonly DependencyProperty UsrKlassProperty = DependencyProperty.Register("UsrKlassProperty", typeof(ICollectionView), typeof(TasksViewModel), new PropertyMetadata(null));

        public ICollectionView ItemsUsrSubjects
        {
            get { return (ICollectionView)GetValue(UsrSubjectsProperty); }
            set { SetValue(UsrSubjectsProperty, value); }
        }
        public static readonly DependencyProperty UsrSubjectsProperty =
            DependencyProperty.Register("UsrSubjectsProperty", typeof(ICollectionView), typeof(TasksViewModel), new PropertyMetadata(null));

        public ICollectionView ItemsTaskFiles
        {
            get { return (ICollectionView)GetValue(ItemsTaskFilesProperty); }
            set { SetValue(ItemsTaskFilesProperty, value); }
        }
        public static readonly DependencyProperty ItemsTaskFilesProperty =
            DependencyProperty.Register("ItemsTaskFilesProperty", typeof(ICollectionView), typeof(TasksViewModel), new PropertyMetadata(null));




        public TasksViewModel()
        {
            StartWindow.Data.TeacherUsr.GetTeacherUsr(id);
            Items = CollectionViewSource.GetDefaultView(StartWindow.Data.Tasks.GetTasks());
            Items.Filter = FilterTasks;
            ItemsUsrKlass = CollectionViewSource.GetDefaultView( StartWindow.Data.TeacherUsr.Klass);
            ItemsUsrSubjects = CollectionViewSource.GetDefaultView( StartWindow.Data.TeacherUsr.Subjects);
            ItemsTaskFiles = CollectionViewSource.GetDefaultView(StartWindow.Data.NewTask.TaskFiles);
            TaskFilesViewBuff = ItemsTaskFiles;
        }
        public static ICollectionView RefrashItems()
        {
            return CollectionViewSource.GetDefaultView(Data.Tasks.GetTasks());
        }



        public ICollectionView CurrentTaskItem
        {
            get { return (ICollectionView)GetValue(CurrentTaskItemProperty); }
            set { SetValue(CurrentTaskItemProperty, value); }
        }
        public static readonly DependencyProperty CurrentTaskItemProperty =
            DependencyProperty.Register("CurrentTaskItemProperty", typeof(ICollectionView), typeof(TasksViewModel), new PropertyMetadata(null));
        public static Data.Tasks CurrentTask;
        public static ICollectionView RefrashCurrentTask(Data.Tasks CurrentTaskBuff)
        {
            CurrentTask = CurrentTaskBuff;
            return CollectionViewSource.GetDefaultView(new List<Data.Tasks> {CurrentTask} );
        }
        public ICollectionView CurrentTaskAnswersItem
        {
            get { return (ICollectionView)GetValue(CurrentTaskAnswersProperty); }
            set { SetValue(CurrentTaskAnswersProperty, value); }
        }
        public static readonly DependencyProperty CurrentTaskAnswersProperty =
            DependencyProperty.Register("CurrentTaskAnswersProperty", typeof(ICollectionView), typeof(TasksViewModel), new PropertyMetadata(null));
        public static ICollectionView RefrashCurrentTaskAnswers()
        {
            return CollectionViewSource.GetDefaultView(Data.Answer.GetAnswers());
        }

        bool FilterTasks(object obj)
        {
            bool result = true;
            StartWindow.Data.Tasks current = obj as StartWindow.Data.Tasks;
            if(current== null)
            {
                result = false;
            }
            if (SubjectFilter!="" && current.Subject != SubjectFilter)
            {
                result = false;
            }
            try
            {
                if (current.TeacherID != Data.TeacherUsr.ID)
                {
                    result = false;
                }
            }
            catch { }
            if (KlassFilter != "" && current.Klass != KlassFilter)
            {
                result = false;
            }
            return result;
        }

        private static void FilterTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as TasksViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.FilterTasks;
            }
        }
    }
}
